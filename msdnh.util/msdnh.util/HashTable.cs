using System.Collections;

namespace msdnh.util
{
    public class HashTable
    {
        public static Hashtable Htable = new Hashtable();

        public static string FindKey(string Value, Hashtable HT)
        {
            var Key = "";
            var e = HT.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Value.ToString().Equals(Value))
                {
                    Key = e.Key.ToString();
                }
            }
            return Key;
        }

        public static string FindSingleValue(string Key, Hashtable HT)
        {
            var strRes = string.Empty;
            if ((Key != null) && HT.ContainsKey(Key))
                strRes = HT[Key].ToString();
            return strRes;
        }

        public static bool MatchKey(string Key, Hashtable HT)
        {
            var blnRes = false;
            if ((Key != null) && HT.ContainsKey(Key))
                blnRes = true;
            return blnRes;
        }

        public static bool MatchKey(string[] Keys, Hashtable HT)
        {
            var blnRes = false;
            var length = Keys.Length;
            for (var i = 0; i < length; i++)
            {
                if ((Keys[i] != null) && HT.ContainsKey(Keys[i]))
                    blnRes = true;
            }

            return blnRes;
        }

        public static void RemoveItem(string Key, Hashtable HT)
        {
            HT.Remove(Key);
        }
    }
}