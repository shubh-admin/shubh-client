using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace msdnh.DataAccess.Base
{
    /// <summary>
    /// </summary>
    public class ModifierBase : DataAccessBase
    {
        /// <summary>
        /// </summary>
        public ModifierBase()
        {
            //
            // TODO: Add constructor logic here
            //
            TypeOfBase = BaseType.Modifier;
            ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        /// <summary>
        /// </summary>
        /// <param name="aDataSet"></param>
        /// <param name="anAdapter"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        [Obsolete("Set the ErrorMessage property instead of using this function.", false)]
        protected bool Update(DataSet aDataSet, SqlDataAdapter anAdapter, string strError)
        {
            _ErrorMessage = strError;
            return Update(aDataSet, anAdapter);
        }

        protected bool Update(DataSet dataSet, SqlDataAdapter dataAdapter)
        {
            return Update(dataSet, null, dataAdapter);
        }

        protected bool Update(DataSet dataSet, string srcTable, SqlDataAdapter dataAdapter)
        {
            try
            {
                if (dataAdapter.UpdateCommand == null && dataAdapter.InsertCommand == null &&
                    dataAdapter.DeleteCommand == null)
                {
                    new SqlCommandBuilder(dataAdapter);
                }
                OpenConnection();
                if (dataAdapter.SelectCommand != null)
                    dataAdapter.SelectCommand.Connection.ConnectionString = ConnectionString;

                if (dataAdapter.UpdateCommand != null)
                    dataAdapter.UpdateCommand.Connection.ConnectionString = ConnectionString;

                if (dataAdapter.InsertCommand != null)
                    dataAdapter.InsertCommand.Connection.ConnectionString = ConnectionString;

                if (dataAdapter.DeleteCommand != null)
                    dataAdapter.DeleteCommand.Connection.ConnectionString = ConnectionString;

                if (srcTable != null && srcTable != string.Empty)
                    dataAdapter.Update(dataSet, srcTable);
                else
                    dataAdapter.Update(dataSet);
                if (!dataSet.HasErrors)
                    return true;
                else
                    return false;
            }
            catch (Exception se)
            {
                BaseError(se);
                return false;
            }
            finally
            {
                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }
        }

        protected bool Update(DataTable dataTable, SqlDataAdapter anAdapter)
        {
            return Update(dataTable.DataSet, dataTable.TableName, anAdapter);
        }


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

        # region un-typed datasets and datatables

        [Obsolete(
            "Must Set SqlCommand to auto-generate your insert, update and delete statements -- Only use for un-typed datasets!!!",
            false)]
        protected bool Update(DataSet dataSet, string srcTable)
        {
            try
            {
                if (_SqlCommand != string.Empty)
                {
                    DaBase.SelectCommand.CommandText = _SqlCommand;
                    new SqlCommandBuilder(DaBase);
                }

                OpenConnection();
                DaBase.Update(dataSet, srcTable);
                if (!dataSet.HasErrors)
                    return true;
                else
                    return false;
            }
            catch (Exception se)
            {
                BaseError(se);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        [Obsolete(
            "Must Set SqlCommand to auto-generate your insert, update and delete statements -- Only use for un-typed datatable!!!",
            false)]
        protected bool Update(DataTable dataTable)
        {
            try
            {
                if (_SqlCommand != string.Empty)
                {
                    DaBase.SelectCommand.CommandText = _SqlCommand;
                    new SqlCommandBuilder(DaBase);
                }

                OpenConnection();
                DaBase.Update(dataTable);
                if (!dataTable.HasErrors)
                    return true;
                else
                    return false;
            }
            catch (Exception se)
            {
                BaseError(se);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        # endregion
    }
}