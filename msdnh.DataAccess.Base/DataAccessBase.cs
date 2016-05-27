using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace msdnh.DataAccess.Base
{
    /// <summary>
    /// </summary>
    public class DataAccessBase : IDisposable
    {
        private string _connectionString;


        private bool _disposed;
        internal bool _EnableParseXml;
        internal string _ErrorMessage = string.Empty;
        private string _InitialConnectionString = string.Empty;
        internal string _SqlCommand = string.Empty;
        internal CommandType _SqlCommandType = CommandType.Text;
        internal string _UseDB = string.Empty;

        internal SqlDataAdapter DaBase;
        private int MAX_TRIES;
        private int NUM_TRIES = 1;
        internal BaseType TypeOfBase;

        /// <summary>
        /// </summary>
        public DataAccessBase()
        {
            //
            // TODO: Add constructor logic here
            //
            DaBase = new SqlDataAdapter {SelectCommand = new SqlCommand()};
            _SqlCommandType = CommandType.Text;
            _EnableParseXml = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataAccessBase()
        {
            Dispose(false);
        }

        internal void OpenConnection()
        {
            if (DaBase.SelectCommand.Connection == null)
            {
                DaBase.SelectCommand.Connection = new SqlConnection(_connectionString);
                OpenValidConnection();
            }
            else
            {
                switch (DaBase.SelectCommand.Connection.State)
                {
                    case ConnectionState.Closed:
                    case ConnectionState.Broken:
                        if (DaBase.SelectCommand.Connection.ConnectionString.ToLower() != _connectionString.ToLower())
                            DaBase.SelectCommand.Connection.ConnectionString = _connectionString;
                        OpenValidConnection();
                        break;
                    default:
                        if (DaBase.SelectCommand.Connection.ConnectionString.ToLower() != _connectionString.ToLower())
                        {
                            DaBase.SelectCommand.Connection.Close();
                            DaBase.SelectCommand.Connection.ConnectionString = _connectionString;
                            OpenValidConnection();
                        }
                        break;
                }
            }

            DaBase.SelectCommand.CommandTimeout = 0;
        }


        internal void OpenValidConnection()
        {
            try
            {
                DaBase.SelectCommand.Connection.Open();
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
            DaBase.SelectCommand.CommandText = string.Empty;
            DaBase.SelectCommand.Parameters.Clear();
            ;
            DaBase.TableMappings.Clear();
            _SqlCommandType = CommandType.Text;

            if (DaBase.SelectCommand.Connection != null)
            {
                DaBase.SelectCommand.Connection.Close();
            }
        }

        internal void BaseError(Exception fe, string strBonus)
        {
            if (_ErrorMessage == string.Empty)
            {
                var strBuilder = new StringBuilder();
                var stackTrace = new StackTrace();
                var stackFrame = stackTrace.GetFrame(2);
                var methodBase = stackFrame.GetMethod();
                strBuilder.Append("DataAccess Call: " + methodBase.Name + "\r\n");
                if (TypeOfBase == BaseType.Fetcher)
                    strBuilder.Append("SqlCommand: " + SqlCommand + "\r\n");
                strBuilder.Append("Parameters:\r\n");
                for (var i = 0; i < Parameters.Count; i++)
                {
                    strBuilder.Append(Parameters[i]).Append(" = ").Append(Parameters[i].Value).Append("\r\n");
                }
                strBuilder.Append("\r\n" + strBonus);

                //ApplicationLog.WriteError(ApplicationLog.FormatException(fe, strBuilder.ToString()));
            }
        }

        internal void BaseError(Exception fe)
        {
            BaseError(fe, string.Empty);
        }

        protected void ChangeDataBase(string strDatabaseName)
        {
            if (TypeOfBase == BaseType.Fetcher)
            {
                _UseDB = "use " + strDatabaseName + "; ";
                if (SqlCommand != string.Empty && !SqlCommand.StartsWith(_UseDB) &&
                    SqlCommandType != CommandType.StoredProcedure)
                    SqlCommand = _UseDB + SqlCommand;
            }
            else
            {
                if (_connectionString.ToLower().IndexOf("database=" + strDatabaseName) == -1)
                {
                    if (_InitialConnectionString != null)
                    {
                        //_ConnectionString = _InitialConnectionString.ToLower().Replace("database=wh", "database=" + strDatabaseName);
                        _connectionString =
                            _InitialConnectionString.Replace(
                                "database=".ToLower() +
                                ReturnConnectionStringParameter(_InitialConnectionString, "database"),
                                "database=" + strDatabaseName);
                    }
                    else
                    {
                        //ConnectionString = _ConnectionString.ToLower().Replace("database=wh", "database=" + strDatabaseName);
                        ConnectionString =
                            _connectionString.Replace(
                                "database=".ToLower() + ReturnConnectionStringParameter(_connectionString, "database"),
                                "database=" + strDatabaseName);
                    }
                }
            }


            //			if (_InitialConnectionString == null || _InitialConnectionString == String.Empty)
            //				ConnectionString = _InitialConnectionString;
            //			_UseDB = "use " + strDatabaseName + "; ";
            //			if (_SqlCommand != String.Empty && _SqlCommand.IndexOf(_SqlCommand, 0, _UseDB.Length-1) < 0 && _SqlCommandType != CommandType.StoredProcedure)
            //				_SqlCommand = _UseDB + _SqlCommand;
        }

        protected void ChangeConnection(string strConnectionString)
        {
            /*
             * TODO: Fix when we have 2 connection strings
             * We should no longer pass in the connection string - it should be handled 
             * exclusively in base
             * */

            if (
                ReturnConnectionStringParameter(_InitialConnectionString, "data source")
                    .Trim()
                    .ToLower()
                    .Equals(ReturnConnectionStringParameter(strConnectionString, "data source").Trim().ToLower()))
            {
                ChangeDataBase(ReturnConnectionStringParameter(strConnectionString, "database"));
            }
            else
            {
                _connectionString = strConnectionString;
            }
        }

        protected void ResetConnection()
        {
            if (_InitialConnectionString != null && _InitialConnectionString != _connectionString)
            {
                _connectionString = _InitialConnectionString;
            }
        }

        protected string ReturnConnectionStringParameter(string strConnectionString, string strKey)
        {
            var strValue = string.Empty;
            var aryConnection = strConnectionString.Split(Convert.ToChar(";"));
            foreach (var strParam in aryConnection)
            {
                if (strParam.Length > strKey.Length + 1 &&
                    strParam.ToLower().Substring(0, strKey.Length + 1) == strKey.ToLower() + "=")
                    strValue = strParam.Substring(strKey.Length + 1, strParam.Length - strKey.Length - 1);
            }
            return strValue;
        }

        public void Dispose(bool disposing)
        {
            // Make sure this code never runs more than once
            if (!_disposed)
            {
                try
                {
                    // This may not be available during finalization, so trap any errors
                    DaBase.Dispose();
                    DaBase = null;
                }
                finally
                {
                    // Make sure this code never runs more than once
                    _disposed = true;
                }
            }
        }

        internal enum BaseType
        {
            Fetcher,
            Modifier
        }

        # region properties

        internal string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (_connectionString != null && _connectionString != string.Empty)
                    _connectionString = value;
                else
                {
                    _InitialConnectionString = value;
                    _connectionString = value;
                }
            }
        }

        protected string SqlCommand
        {
            get { return _SqlCommand; }
            set
            {
                if (_UseDB != string.Empty && !value.StartsWith(_UseDB) &&
                    _SqlCommandType != CommandType.StoredProcedure)
                    _SqlCommand = _UseDB + value;
                else
                    _SqlCommand = value;
            }
        }

        [Obsolete("Temporary fix until statements are converted to use parameters", false)]
        protected string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        protected CommandType SqlCommandType
        {
            get { return _SqlCommandType; }
            set { _SqlCommandType = value; }
        }

        protected SqlParameterCollection Parameters
        {
            get { return DaBase.SelectCommand.Parameters; }
        }

        protected DataTableMappingCollection TableMappings
        {
            get { return DaBase.TableMappings; }
        }

        protected int MaxPoolSize
        {
            get
            {
                if (MAX_TRIES > 0)
                {
                    return MAX_TRIES;
                }
                var strMaxPoolSize = ReturnConnectionStringParameter(_connectionString, "Max Pool Size");

                if (strMaxPoolSize != string.Empty)
                    MAX_TRIES = Convert.ToInt32(strMaxPoolSize);
                else
                    MAX_TRIES = 2;

                return MAX_TRIES;
            }
        }

        protected bool EnableParseXml
        {
            get { return _EnableParseXml; }
            set { _EnableParseXml = value; }
        }

        # endregion

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