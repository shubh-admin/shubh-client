using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Web.Security;


namespace msdnh.DataAccess.Base
{
    public class DataAccessBase : IDisposable
    {
        public DataAccessBase()
        {
            //
            // TODO: Add constructor logic here
            //
            _daBase = new SqlDataAdapter();
            _daBase.SelectCommand = new SqlCommand();
            _SqlCommandType = CommandType.Text;
            _EnableParseXml = true;
        }

        ~DataAccessBase()
        {
            Dispose(false);
        }

        internal SqlDataAdapter _daBase;
        private String _ConnectionString;
        private String _InitialConnectionString = String.Empty;
        internal String _SqlCommand = String.Empty;
        internal String _ErrorMessage = String.Empty;
        internal CommandType _SqlCommandType = CommandType.Text;
        internal String _UseDB = String.Empty;
        internal bool _EnableParseXml;
        private int NUM_TRIES = 1;
        private int MAX_TRIES = 0;

        internal enum BaseType { Fetcher, Modifier };
        internal BaseType TypeOfBase;

        # region properties

        internal String ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                if (_ConnectionString != null && _ConnectionString != String.Empty)
                    _ConnectionString = value;
                else
                {
                    _InitialConnectionString = value;
                    _ConnectionString = value;
                }
            }
        }

        protected String SqlCommand
        {
            get
            {
                return _SqlCommand;
            }
            set
            {
                if (_UseDB != String.Empty && !value.StartsWith(_UseDB) && _SqlCommandType != CommandType.StoredProcedure)
                    _SqlCommand = _UseDB + value;
                else
                    _SqlCommand = value;
            }
        }

        [Obsolete("Temporary fix until statements are converted to use parameters", false)]
        protected String ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
            }
        }

        protected CommandType SqlCommandType
        {
            get
            {
                return _SqlCommandType;
            }
            set
            {
                _SqlCommandType = value;
            }

        }

        protected SqlParameterCollection Parameters
        {
            get
            {
                return _daBase.SelectCommand.Parameters;
            }

        }

        protected System.Data.Common.DataTableMappingCollection TableMappings
        {
            get
            {
                return _daBase.TableMappings;
            }

        }

        protected Int32 MaxPoolSize
        {
            get
            {
                if (MAX_TRIES > 0)
                {
                    return MAX_TRIES;
                }
                else
                {
                    string strMaxPoolSize = ReturnConnectionStringParameter(_ConnectionString, "Max Pool Size");

                    if (strMaxPoolSize != string.Empty)
                        MAX_TRIES = Convert.ToInt32(strMaxPoolSize);
                    else
                        MAX_TRIES = 2;

                    return MAX_TRIES;
                }
            }
        }

        protected bool EnableParseXml
        {
            get
            {
                return _EnableParseXml;
            }
            set
            {
                _EnableParseXml = value;
            }
        }

        # endregion

        internal void OpenConnection()
        {

            if (_daBase.SelectCommand.Connection == null)
            {
                _daBase.SelectCommand.Connection = new SqlConnection(_ConnectionString);
                OpenValidConnection();
            }
            else
            {
                switch (_daBase.SelectCommand.Connection.State)
                {
                    case ConnectionState.Closed:
                    case ConnectionState.Broken:
                        if (_daBase.SelectCommand.Connection.ConnectionString.ToLower() != _ConnectionString.ToLower())
                            _daBase.SelectCommand.Connection.ConnectionString = _ConnectionString;
                        OpenValidConnection();
                        break;
                    default:
                        if (_daBase.SelectCommand.Connection.ConnectionString.ToLower() != _ConnectionString.ToLower())
                        {
                            _daBase.SelectCommand.Connection.Close();
                            _daBase.SelectCommand.Connection.ConnectionString = _ConnectionString;
                            OpenValidConnection();
                        }
                        break;
                }
            }

            _daBase.SelectCommand.CommandTimeout = 0;
        }


        internal void OpenValidConnection()
        {
            try
            {
                _daBase.SelectCommand.Connection.Open();
            }
            catch (SqlException sqle)
            {
                CloseConnection();

                if (NUM_TRIES < MaxPoolSize)
                {
                    OpenValidConnection();
                    NUM_TRIES += 1;
                }
                else
                {
                    BaseError(sqle);
                }
            }
        }

        internal void CloseConnection()
        {
            _daBase.SelectCommand.CommandText = String.Empty;
            _daBase.SelectCommand.Parameters.Clear(); ;
            _daBase.TableMappings.Clear();
            _SqlCommandType = CommandType.Text;

            if (_daBase.SelectCommand.Connection != null)
            {
                _daBase.SelectCommand.Connection.Close();
            }
        }

        internal void BaseError(Exception fe, String strBonus)
        {
            if (_ErrorMessage == String.Empty)
            {
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(2);
                MethodBase methodBase = stackFrame.GetMethod();
                strBuilder.Append("DataAccess Call: " + methodBase.Name + "\r\n");
                if (TypeOfBase == BaseType.Fetcher)
                    strBuilder.Append("SqlCommand: " + SqlCommand + "\r\n");
                strBuilder.Append("Parameters:\r\n");
                for (int i = 0; i < Parameters.Count; i++)
                {
                    strBuilder.Append(Parameters[i].ToString()).Append(" = ").Append(Parameters[i].Value).Append("\r\n");
                }
                strBuilder.Append("\r\n" + strBonus);
                
               //ApplicationLog.WriteError(ApplicationLog.FormatException(fe, strBuilder.ToString()));
            }
            else
            {
                //ApplicationLog.WriteError(ApplicationLog.FormatException(fe, _ErrorMessage + "\r\n" + strBonus));
            }
        }

        internal void BaseError(Exception fe)
        {
            BaseError(fe, String.Empty);
        }

        protected void ChangeDataBase(String strDatabaseName)
        {


            if (TypeOfBase == BaseType.Fetcher)
            {
                _UseDB = "use " + strDatabaseName + "; ";
                if (SqlCommand != String.Empty && !SqlCommand.StartsWith(_UseDB) && SqlCommandType != CommandType.StoredProcedure)
                    SqlCommand = _UseDB + SqlCommand;
            }
            else
            {
                if (_ConnectionString.ToLower().IndexOf("database=" + strDatabaseName) == -1)
                {

                    if (_InitialConnectionString != null)
                    {
                        //_ConnectionString = _InitialConnectionString.ToLower().Replace("database=wh", "database=" + strDatabaseName);
                        _ConnectionString = _InitialConnectionString.Replace("database=".ToLower() + ReturnConnectionStringParameter(_InitialConnectionString, "database"), "database=" + strDatabaseName);
                    }
                    else
                    {
                        //ConnectionString = _ConnectionString.ToLower().Replace("database=wh", "database=" + strDatabaseName);
                        ConnectionString = _ConnectionString.Replace("database=".ToLower() + ReturnConnectionStringParameter(_ConnectionString, "database"), "database=" + strDatabaseName);

                    }
                }
            }


            //			if (_InitialConnectionString == null || _InitialConnectionString == String.Empty)
            //				ConnectionString = _InitialConnectionString;
            //			_UseDB = "use " + strDatabaseName + "; ";
            //			if (_SqlCommand != String.Empty && _SqlCommand.IndexOf(_SqlCommand, 0, _UseDB.Length-1) < 0 && _SqlCommandType != CommandType.StoredProcedure)
            //				_SqlCommand = _UseDB + _SqlCommand;
        }

        protected void ChangeConnection(String strConnectionString)
        {
            /*
             * TODO: Fix when we have 2 connection strings
             * We should no longer pass in the connection string - it should be handled 
             * exclusively in base
             * */

            if (ReturnConnectionStringParameter(_InitialConnectionString, "data source").Trim().ToLower().Equals(ReturnConnectionStringParameter(strConnectionString, "data source").Trim().ToLower()))
            {
                ChangeDataBase(ReturnConnectionStringParameter(strConnectionString, "database"));
            }
            else
            {
                _ConnectionString = strConnectionString;
            }
        }

        protected void ResetConnection()
        {
            if (_InitialConnectionString != null && _InitialConnectionString != _ConnectionString)
            {
                _ConnectionString = _InitialConnectionString;
            }
        }

        protected String ReturnConnectionStringParameter(String strConnectionString, String strKey)
        {
            String strValue = String.Empty;
            string[] aryConnection = strConnectionString.Split(Convert.ToChar(";"));
            foreach (String strParam in aryConnection)
            {
                if (strParam.Length > (strKey.Length + 1) && strParam.ToLower().Substring(0, strKey.Length + 1) == (strKey.ToLower() + "="))
                    strValue = strParam.Substring(strKey.Length + 1, strParam.Length - strKey.Length - 1);
            }
            return (strValue);

        }


        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            // Make sure this code never runs more than once
            if (!_disposed)
            {
                try
                {
                    // This may not be available during finalization, so trap any errors
                    _daBase.Dispose();
                    _daBase = null;
                }
                finally
                {
                    // Make sure this code never runs more than once
                    _disposed = true;
                }
            }
        }

        #region IDisposable Members
        /*        
        void IDisposable.Dispose()
        {
        //    throw new NotImplementedException();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        */
        #endregion
 
    }

}
