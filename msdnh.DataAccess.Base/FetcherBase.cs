using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Globalization;
using System.Threading;
using System.Xml;
using System.Configuration;

namespace msdnh.DataAccess.Base
{
    public class FetcherBase : DataAccessBase
    {
        public FetcherBase()
        {
            TypeOfBase = BaseType.Fetcher;
            //ConnectionString = WinningHabitsConfiguration.ReadOnlyConnectionString;
            ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }


        # region DataTable Fill

        protected int Fill(DataTable dataTable, String strSelectCommand)
        {
            _SqlCommand = strSelectCommand;
            return Fill(dataTable, dataTable.TableName);

        }

        protected int Fill(DataTable dataTable)
        {
            try
            {
                OpenConnection();
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataTable.Columns.Count == 0)
                    _daBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                return _daBase.Fill(dataTable);
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
        protected int Fill(DataSet dataSet, String srcTable, String strSelectCommand)
        {
            _SqlCommand = strSelectCommand;
            return Fill(dataSet, srcTable);

        }

        protected int Fill(DataSet dataSet, String srcTable)
        {
            try
            {
                OpenConnection();
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataSet.Tables[srcTable] == null)
                    _daBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                int rowcount = _daBase.Fill(dataSet, srcTable);

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
        /// This fill should be used primarily for typed datasets and commands returning multiple results
        /// with TableMappings defined. There is some use for this on non-typed datasets, but it's not ideal.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        protected int Fill(DataSet dataSet)
        {
            try
            {
                OpenConnection();
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                if (dataSet.Tables[0] == null)
                    _daBase.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                int rowcount = _daBase.Fill(dataSet);

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

        protected int ExecuteNonQuery()
        {
            try
            {
                OpenConnection();
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                return _daBase.SelectCommand.ExecuteNonQuery();
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

        protected object ExecuteScalar()
        {
            try
            {
                OpenConnection();
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                return _daBase.SelectCommand.ExecuteScalar();
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

        public void AddMapping(String TableName)
        {
            if (TableMappings.Count == 0)
                TableMappings.Add("Table", TableName);
            else
                TableMappings.Add("Table" + TableMappings.Count, TableName);
        }

        private void ParseXml(DataSet dataSet)
        {
            String strLanguage = "en-us";
            try
            {
                if ( HttpContext.Current.Request.QueryString["lang"] != null)
                {
                    strLanguage = HttpContext.Current.Request.QueryString["lang"].ToString().ToLower();
                }
                else
                {
                    if (HttpContext.Current.Session["CurrentCulture"] != null)
                        strLanguage = HttpContext.Current.Session["CurrentCulture"].ToString().ToLower();
                }
            }
            catch { }

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow row in dataSet.Tables[dt.TableName].Rows)
                {
                    foreach (DataColumn c in row.Table.Columns)
                    {
                        if (c.DataType == System.Type.GetType("System.String"))
                        {
                            if (row[c.ColumnName].ToString().ToLower().StartsWith("<root>"))
                            {
                                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                xmlDoc.LoadXml(row[c.ColumnName].ToString());

                                // multilingual
                                System.Xml.XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("CultureInfo");
                                foreach (System.Xml.XmlNode xmlNode in xmlNodes)
                                {
                                    System.Xml.XmlAttributeCollection xmlAttributes = xmlNode.Attributes;
                                    if (xmlAttributes["language"].Value.ToLower() == strLanguage.ToLower())
                                        row[c.ColumnName] = System.Web.HttpUtility.HtmlDecode(xmlNode.InnerText);
                                }
                                if (row.RowState == System.Data.DataRowState.Unchanged)
                                {
                                    // language not supported - default to "en-US" and write log error
                                    //SystemFramework.ApplicationLog.WriteError("Language " + locale + " not found in the xml data : " + row[c.ColumnName].ToString());

                                    // get default culture [en-US]
                                    foreach (System.Xml.XmlNode xmlNode in xmlNodes)
                                    {
                                        System.Xml.XmlAttributeCollection xmlAttributes = xmlNode.Attributes;
                                        if (xmlAttributes["language"].Value.ToLower() == "en-us")
                                            row[c.ColumnName] = System.Web.HttpUtility.HtmlDecode(xmlNode.InnerText);
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
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                //Will close connection when done with reader
                return _daBase.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);

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
                _daBase.SelectCommand.CommandText = _SqlCommand;
                _daBase.SelectCommand.CommandType = _SqlCommandType;
                return _daBase.SelectCommand.ExecuteXmlReader();
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


        private String PrintAllErrs(DataSet myDataSet)
        {
            StringBuilder _ColandRowErr = new StringBuilder();
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
                        foreach (DataRow drerr in rowsInError)
                        {
                            _ColandRowErr.Append("RowError:" + drerr.RowError);
                        }
                        // Print the error of each column in each row.
                        for (int i = 0; i < rowsInError.Length; i++)
                        {
                            foreach (DataColumn myCol in myTable.Columns)
                            {
                                if (rowsInError[i].RowError != String.Empty)
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


    }
}
