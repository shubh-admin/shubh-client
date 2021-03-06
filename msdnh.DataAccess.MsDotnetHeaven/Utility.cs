﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using msdnh.DataAccess.Base;

namespace msdnh.DataAccess.MsDotnetHeaven
{
    /// <summary>
    /// </summary>
    public class Utility : SecurityBase, IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion

        //public enum HashType
        //{
        //    MD5, SHA1, SHA256, SHA384, SHA512

        //}
        /// <summary>
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public string DecryptString(string strPwd)
        {
            var strDecryptPwd = strPwd; //(new SecurityBase()).DecodeString(strPwd,2);
            //Logics to decrypt the password


            return strDecryptPwd;
        }

        /// <summary>
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public string EncryptString(string strPwd)
        {
            var strEncryptPwd = strPwd; // string.Empty;
            //Logics to Encrypt the password
            //byte[] buffer;
            //string strSalt = GenerateSalt();
            //bool blnStandardComp = false;
            //buffer = GeneratePasswordBuffer(strSalt, strPwd, blnStandardComp);
            //byte[] hashedBytes = Hash(buffer, strHashType); //Hash

            //strEncryptPwd = Convert.ToBase64String(hashedBytes);

            return strEncryptPwd;
        }

        /// <summary>
        ///     Hash password using SHA512
        /// </summary>
        /// <param name="strPasswordToBeEncrypted"></param>
        /// <returns></returns>
        public string HashPassword(string strPasswordToBeEncrypted)
        {
            SHA512 sha512 = new SHA512Managed();

            var sha512Bytes = Encoding.Default.GetBytes(strPasswordToBeEncrypted);

            var cryString = sha512.ComputeHash(sha512Bytes);

            var sha512Str = string.Empty;

            for (var i = 0; i < cryString.Length; i++)
            {
                sha512Str += cryString[i].ToString("X");
            }

            return sha512Str;
        }


        //private static string GenerateSalt()
        //{
        //    byte[] buf = new byte[16];
        //    RNGCryptoServiceProvider rngCryptoSP = new RNGCryptoServiceProvider();
        //    rngCryptoSP.GetBytes(buf);
        //    return Convert.ToBase64String(buf);
        //}
        //private static byte[] Hash(byte[] clearBytes, string hashType)
        //{
        //    // MD5, SHA1, SHA256, SHA384, SHA512
        //    Byte[] hash = HashAlgorithm.Create(hashType).ComputeHash(clearBytes);
        //    return hash;
        //}
        //public static byte[] GeneratePasswordBuffer(string strSalt, string strPwd, bool blnStandardComp)
        //{
        //    byte[] unencodedBytes = Encoding.Unicode.GetBytes(strPwd);
        //    byte[] saltBytes = Convert.FromBase64String(strSalt);
        //    byte[] buffer = new byte[unencodedBytes.Length + saltBytes.Length];

        //    if (blnStandardComp) // Compliant with ASP.NET Membership method of hash/salt
        //    {
        //        Buffer.BlockCopy(saltBytes, 0, buffer, 0, saltBytes.Length);
        //        Buffer.BlockCopy(unencodedBytes, 0, buffer, saltBytes.Length, unencodedBytes.Length);
        //    }
        //    else
        //    {
        //        System.Buffer.BlockCopy(unencodedBytes, 0, buffer, 0, unencodedBytes.Length);
        //        System.Buffer.BlockCopy(saltBytes, 0, buffer, unencodedBytes.Length - 1, saltBytes.Length);
        //    }
        //    return buffer;
        //}

        /// <summary>
        /// </summary>
        /// <param name="dtTable"></param>
        /// <param name="lstColName"></param>
        /// <returns></returns>
        public static DataTable RemoveColumns(DataTable dtTable, IList<string> lstColName)
        {
            var dtNewTable = new DataTable();
            for (var intCount = 0; intCount < lstColName.Count; intCount++)
            {
                if (dtTable.Columns.CanRemove(dtTable.Columns[lstColName[intCount]]))
                {
                    dtTable.Columns.Remove(lstColName[intCount]);
                }
            }
            dtNewTable = dtTable.Copy();
            return dtNewTable;
        }

        /// <summary>
        /// </summary>
        /// <param name="dtTable"></param>
        /// <param name="lstOldCol"></param>
        /// <param name="lstNewCol"></param>
        /// <returns></returns>
        public static DataTable RenameColumns(DataTable dtTable, IList<string> lstOldCol, IList<string> lstNewCol)
        {
            var dtNewTable = new DataTable();
            if (lstOldCol.Count == lstNewCol.Count)
            {
                for (var intCount = 0; intCount < lstOldCol.Count; intCount++)
                {
                    foreach (DataColumn dtCol in dtTable.Columns)
                    {
                        if (dtCol.ColumnName == lstOldCol[intCount])
                        {
                            dtTable.Columns[lstOldCol[intCount]].ColumnName = lstNewCol[intCount];
                        }
                    }
                }
            }
            dtNewTable = dtTable.Copy();
            return dtNewTable;
        }

        /// <summary>
        ///     Add a new column in a Table
        /// </summary>
        /// <param name="dtTable"></param>
        /// <param name="strColName"></param>
        /// <returns></returns>
        public static DataTable AddColumn(DataTable dtTable, string strColName)
        {
            dtTable.Columns.Add(new DataColumn(strColName));
            return dtTable;
        }
    }
}