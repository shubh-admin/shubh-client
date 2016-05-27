using System;
using System.Collections.Specialized;

namespace msdnh.DataAccess.Base
{
    /// <summary>
    /// </summary>
    public class Transform
    {
        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            if ((obj != DBNull.Value) && (obj != null))
                return Convert.ToDateTime(obj.ToString());
            return DateTime.Now; // Yeah I admit it, what the hell should this return?
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            if ((obj != DBNull.Value) && (obj != null))
                return obj.ToString();
            return string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string ToString(object obj, string defValue)
        {
            if ((obj != DBNull.Value) && (obj != null))
                return obj.ToString();
            return defValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static string[] ToStringArray(StringCollection coll)
        {
            var strReturn = new string[coll.Count];
            coll.CopyTo(strReturn, 0);
            return strReturn;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBool(object obj)
        {
            if ((obj != DBNull.Value) && (obj != null))
                return Convert.ToBoolean(obj);
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            if ((obj != DBNull.Value) && (obj != null))
                return Convert.ToInt32(obj);
            return 0;
        }
    }
}