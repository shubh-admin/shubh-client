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
    public class ModifierBase : DataAccessBase
    {
        public ModifierBase()
        {
            //
            // TODO: Add constructor logic here
            //
            TypeOfBase = BaseType.Modifier;
            ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        
        }

        [Obsolete("Set the ErrorMessage property instead of using this function.", false)]
        protected bool Update(DataSet aDataSet, SqlDataAdapter anAdapter, String strError)
        {
            _ErrorMessage = strError;
            return Update(aDataSet, anAdapter);
        }

        # region un-typed datasets and datatables

        [Obsolete("Must Set SqlCommand to auto-generate your insert, update and delete statements -- Only use for un-typed datasets!!!", false)]
        protected bool Update(DataSet dataSet, String srcTable)
        {
            try
            {
                if (_SqlCommand != String.Empty)
                {
                    _daBase.SelectCommand.CommandText = _SqlCommand;
                    new SqlCommandBuilder(_daBase);
                }

                OpenConnection();
                _daBase.Update(dataSet, srcTable);
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

        [Obsolete("Must Set SqlCommand to auto-generate your insert, update and delete statements -- Only use for un-typed datatable!!!", false)]
        protected bool Update(DataTable dataTable)
        {
            try
            {
                if (_SqlCommand != String.Empty)
                {
                    _daBase.SelectCommand.CommandText = _SqlCommand;
                    new SqlCommandBuilder(_daBase);
                }

                OpenConnection();
                _daBase.Update(dataTable);
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

        protected bool Update(DataSet dataSet, SqlDataAdapter dataAdapter)
        {
            return Update(dataSet, null, dataAdapter);
        }

        protected bool Update(DataSet dataSet, String srcTable, SqlDataAdapter dataAdapter)
        {
            try
            {

                if (dataAdapter.UpdateCommand == null && dataAdapter.InsertCommand == null && dataAdapter.DeleteCommand == null)
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

                if (srcTable != null && srcTable != String.Empty)
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

    }

}
