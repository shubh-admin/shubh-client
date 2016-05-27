using System;
using System.Text;

namespace msdnh.DataAccess.Base
{
    /// <summary>
    /// </summary>
    public class CleanUtils
    {
        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDate(object obj)
        {
            return obj != DBNull.Value ? Convert.ToDateTime(obj.ToString()) : DateTime.Now;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return obj != DBNull.Value ? obj.ToString() : string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBool(object obj)
        {
            return obj != DBNull.Value && Convert.ToBoolean(obj);
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            return obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="hashedBytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] hashedBytes)
        {
            var hashedSb = new StringBuilder(hashedBytes.Length*2 + 2);
            foreach (var b in hashedBytes)
            {
                hashedSb.AppendFormat("{0:X2}", b);
            }
            return hashedSb.ToString();
        }
    }
}