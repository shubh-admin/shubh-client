using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Xml;

namespace msdnh.DataAccess.Base
{
    /// <summary>
    /// </summary>
    public class FetcherBase : DataAccessBase
    {
        /// <summary>
        /// </summary>
        public FetcherBase()
        {
            TypeOfBase = BaseType.Fetcher;
            //ConnectionString = WinningHabitsConfiguration.ReadOnlyConnectionString;
            ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected int ExecuteNonQuery()
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                return DaBase.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception se)
            {
                BaseError(se);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected object ExecuteScalar()
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                return DaBase.SelectCommand.ExecuteScalar();
            }
            catch (Exception se)
            {
                BaseError(se);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void AddMapping(string TableName)
        {
            if (TableMappings.Count == 0)
                TableMappings.Add("Table", TableName);
            else
                TableMappings.Add("Table" + TableMappings.Count, TableName);
        }

        private void ParseXml(DataSet dataSet)
        {
            var strLanguage = "en-us";
            try
            {
                if (HttpContext.Current.Request.QueryString["lang"] != null)
                {
                    strLanguage = HttpContext.Current.Request.QueryString["lang"].ToLower();
                }
                else
                {
                    if (HttpContext.Current.Session["CurrentCulture"] != null)
                        strLanguage = HttpContext.Current.Session["CurrentCulture"].ToString().ToLower();
                }
            }
            catch
            {
            }

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow row in dataSet.Tables[dt.TableName].Rows)
                {
                    foreach (DataColumn c in row.Table.Columns)
                    {
                        if (c.DataType == Type.GetType("System.String"))
                        {
                            if (row[c.ColumnName].ToString().ToLower().StartsWith("<root>"))
                            {
                                var xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(row[c.ColumnName].ToString());

                                // multilingual
                                var xmlNodes = xmlDoc.GetElementsByTagName("CultureInfo");
                                foreach (XmlNode xmlNode in xmlNodes)
                                {
                                    var xmlAttributes = xmlNode.Attributes;
                                    if (xmlAttributes["language"].Value.ToLower() == strLanguage.ToLower())
                                        row[c.ColumnName] = HttpUtility.HtmlDecode(xmlNode.InnerText);
                                }
                                if (row.RowState == DataRowState.Unchanged)
                                {
                                    // language not supported - default to "en-US" and write log error
                                    //SystemFramework.ApplicationLog.WriteError("Language " + locale + " not found in the xml data : " + row[c.ColumnName].ToString());

                                    // get default culture [en-US]
                                    foreach (XmlNode xmlNode in xmlNodes)
                                    {
                                        var xmlAttributes = xmlNode.Attributes;
                                        if (xmlAttributes["language"].Value.ToLower() == "en-us")
                                            row[c.ColumnName] = HttpUtility.HtmlDecode(xmlNode.InnerText);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (dataSet.HasChanges())
                dataSet.AcceptChanges();
        }

        protected SqlDataReader ExecuteReader()
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                //Will close connection when done with reader
                return DaBase.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception se)
            {
                BaseError(se);
                return null;
            }
        }

        protected XmlReader ExecuteXmlReader()
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                return DaBase.SelectCommand.ExecuteXmlReader();
            }
            catch (Exception se)
            {
                BaseError(se);
                return null;
            }
            //			finally
            //			{
            //				CloseConnection();
            //			}
        }


        private string PrintAllErrs(DataSet myDataSet)
        {
            var _ColandRowErr = new StringBuilder();
            DataRow[] rowsInError;

            if (myDataSet != null)
            {
                foreach (DataTable myTable in myDataSet.Tables)
                {
                    // Test if the table has errors. If not, skip it.
                    if (myTable.HasErrors)
                    {
                        // Get an array of all rows with errors.
                        rowsInError = myTable.GetErrors();
                        foreach (var drerr in rowsInError)
                        {
                            _ColandRowErr.Append("RowError:" + drerr.RowError);
                        }
                        // Print the error of each column in each row.
                        for (var i = 0; i < rowsInError.Length; i++)
                        {
                            foreach (DataColumn myCol in myTable.Columns)
                            {
                                if (rowsInError[i].RowError != string.Empty)
                                {
                                    _ColandRowErr.Append(myCol.ColumnName + " " +
                                                         rowsInError[i].GetColumnError(myCol));
                                }
                            }
                            // Clear the row errors
                            rowsInError[i].ClearErrors();
                        }
                    }
                }
            }
            return _ColandRowErr.ToString();
        }

        # region DataTable Fill

        protected int Fill(DataTable dataTable, string strSelectCommand)
        {
            _SqlCommand = strSelectCommand;
            return Fill(dataTable, dataTable.TableName);
        }

        protected int Fill(DataTable dataTable)
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataTable.Columns.Count == 0)
                    DaBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                return DaBase.Fill(dataTable);
            }
            catch (Exception se)
            {
                BaseError(se, PrintAllErrs(dataTable.DataSet));
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        # endregion

        # region DataSet Fill

        protected int Fill(DataSet dataSet, string srcTable, string strSelectCommand)
        {
            _SqlCommand = strSelectCommand;
            return Fill(dataSet, srcTable);
        }

        protected int Fill(DataSet dataSet, string srcTable)
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataSet.Tables[srcTable] == null)
                    DaBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                var rowcount = DaBase.Fill(dataSet, srcTable);

                // scan all string columns for xml data
                if (rowcount > 0 && EnableParseXml)
                    ParseXml(dataSet);

                return rowcount;
            }
            catch (Exception se)
            {
                // build error information:
                BaseError(se, PrintAllErrs(dataSet));
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        ///     This fill should be used primarily for typed datasets and commands returning multiple results
        ///     with TableMappings defined. There is some use for this on non-typed datasets, but it's not ideal.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        protected int Fill(DataSet dataSet)
        {
            try
            {
                OpenConnection();
                DaBase.SelectCommand.CommandText = _SqlCommand;
                DaBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataSet.Tables[0] == null)
                    DaBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                var rowcount = DaBase.Fill(dataSet);

                // scan all string columns for xml data
                if (rowcount > 0 && EnableParseXml)
                    ParseXml(dataSet);

                return rowcount;
            }
            catch (Exception se)
            {
                BaseError(se, PrintAllErrs(dataSet));
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        # endregion
    }
}