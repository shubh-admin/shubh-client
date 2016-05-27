using System;
using System.Collections.Generic;
using System.Text;

namespace msdnh.DataAccess.Base
{
    public class CleanUtils
    {
        public static DateTime ToDate(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToDateTime(obj.ToString());
            else
                return DateTime.Now;
        }

        public static string ToString(object obj)
        {
            if (obj != DBNull.Value)
                return obj.ToString();
            else
                return String.Empty;
        }

        public static bool ToBool(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToBoolean(obj);
            else
                return false;
        }

        public static int ToInt(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToInt32(obj);
            else
                return 0;
        }

        public static string toHexString(byte[] hashedBytes)
        {
            StringBuilder hashedSB = new StringBuilder(hashedBytes.Length * 2 + 2);
            foreach (byte b in hashedBytes)
            {
                hashedSB.AppendFormat("{0:X2}", b);
            }
            return hashedSB.ToString();
        }
    }
}
