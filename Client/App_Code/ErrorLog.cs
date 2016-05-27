using System;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using msdnh.BF.MsDotnetHeaven;

/// <summary>
/// Summary description for ErrorLog
/// </summary>
namespace WriteLog
{
    public class ErrorLog
    {
        public ErrorLog()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Write Error File
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strError"></param>
        /// <param name="strDesc"></param>
        public static void WriteErrorLog(string strUrl, string strError, string strDesc)
        {
            MsDotNetHeaven objMsDnHBF = new MsDotNetHeaven();
            objMsDnHBF.LoggedError(strUrl, strError, strDesc, System.DateTime.Now);
        }
        #endregion
    }
}