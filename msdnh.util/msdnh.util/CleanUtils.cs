﻿using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace msdnh.util
{
    public class CleanUtils
    {
        public static DateTime ToDate(object obj)
        {
            return obj != DBNull.Value
                ? DateTime.ParseExact(obj.ToString(), @"MM/dd/yyyy HH:mm:ss",
                    CultureInfo.CreateSpecificCulture("en-US"))
                : DateTime.Now;
        }


        public static string ToString(object obj)
        {
            return obj != DBNull.Value ? Convert.ToString(obj) : string.Empty;
        }

        public static char ToChar(object obj)
        {
            return obj != DBNull.Value ? Convert.ToChar(obj) : '\0';
        }

        public static bool ToBool(object obj)
        {
            return obj != DBNull.Value && Convert.ToBoolean(obj);
        }

        public static int ToInt(object obj)
        {
            return obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }

        public static double ToDouble(object obj)
        {
            return obj != DBNull.Value ? Convert.ToDouble(obj) : 0.00;
        }

        public static string ToHexString(byte[] hashedBytes)
        {
            var hashedSB = new StringBuilder(hashedBytes.Length*2 + 2);
            foreach (var b in hashedBytes)
            {
                hashedSB.AppendFormat("{0:X2}", b);
            }
            return hashedSB.ToString();
        }

        /// <summary>
        ///     Get plain text without html and script tags
        /// </summary>
        /// <param name="source">String needs to convert in Plai Text</param>
        /// <returns>String without tags</returns>
        public static string ToPlainText(string source)
        {
            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            var result = source.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating spaces because browsers ignore them
            result = Regex.Replace(result,
                @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*head([^>])*>", "<head>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*head( )*>)", "</head>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(<head>).*(</head>)", string.Empty,
                RegexOptions.IgnoreCase);

            // remove all scrBipts (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*script([^>])*>", "<script>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*script( )*>)", "</script>",
                RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result,
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty,
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<script>).*(</script>)", string.Empty,
                RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*style([^>])*>", "<style>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*style( )*>)", "</style>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(<style>).*(</style>)", string.Empty,
                RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = Regex.Replace(result,
                @"<( )*td([^>])*>", "\t",
                RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = Regex.Replace(result,
                @"<( )*br( )*>", "\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*li( )*>", "\r",
                RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = Regex.Replace(result,
                @"<( )*div([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*tr([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*p([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything that's enclosed inside < >
            result = Regex.Replace(result,
                @"<[^>]*>", string.Empty,
                RegexOptions.IgnoreCase);

            // replace special characters:
            result = Regex.Replace(result,
                @" ", " ",
                RegexOptions.IgnoreCase);

            result = Regex.Replace(result,
                @"&bull;", " * ",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&lsaquo;", "<",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&rsaquo;", ">",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&trade;", "(tm)",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&frasl;", "/",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&lt;", "<",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&gt;", ">",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&copy;", "(c)",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&reg;", "(r)",
                RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see

            result = Regex.Replace(result,
                @"&(.{2,6});", string.Empty,
                RegexOptions.IgnoreCase);

            // for testing
            //System.Text.RegularExpressions.Regex.Replace(result,
            //       this.txtRegex.Text,string.Empty,
            //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4.
            // Prepare first to remove any whitespaces in between
            // the escaped characters and remove redundant tabs in between line breaks
            result = Regex.Replace(result,
                "(\r)( )+(\r)", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\t)( )+(\t)", "\t\t",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\t)( )+(\r)", "\t\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\r)( )+(\t)", "\r\t",
                RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = Regex.Replace(result,
                "(\r)(\t)+(\r)", "\r\r",
                RegexOptions.IgnoreCase);
            // Remove multiple tabs following a line break with just one tab
            result = Regex.Replace(result,
                "(\r)(\t)+", "\r\t",
                RegexOptions.IgnoreCase);
            // Initial replacement target string for line breaks
            var breaks = "\r\r\r";
            // Initial replacement target string for tabs
            var tabs = "\t\t\t\t\t";
            for (var index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // That's it.
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="blnLineBreaks"></param>
        /// <returns></returns>
        public static string ToPlainText(string source, bool blnLineBreaks)
        {
            string result;
            if (blnLineBreaks)
            {
                result = source;
            }
            else
            {
                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");

                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
            }
            // Remove repeating spaces because browsers ignore them
            result = Regex.Replace(result,
                @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*head([^>])*>", "<head>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*head( )*>)", "</head>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(<head>).*(</head>)", string.Empty,
                RegexOptions.IgnoreCase);

            // remove all scrBipts (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*script([^>])*>", "<script>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*script( )*>)", "</script>",
                RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result,
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty,
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<script>).*(</script>)", string.Empty,
                RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = Regex.Replace(result,
                @"<( )*style([^>])*>", "<style>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"(<( )*(/)( )*style( )*>)", "</style>",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(<style>).*(</style>)", string.Empty,
                RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = Regex.Replace(result,
                @"<( )*td([^>])*>", "\t",
                RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = Regex.Replace(result,
                @"<( )*br( )*>", "\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*li( )*>", "\r",
                RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = Regex.Replace(result,
                @"<( )*div([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*tr([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"<( )*p([^>])*>", "\r\r",
                RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything that's enclosed inside < >
            result = Regex.Replace(result,
                @"<[^>]*>", string.Empty,
                RegexOptions.IgnoreCase);

            // replace special characters:
            result = Regex.Replace(result,
                @" ", " ",
                RegexOptions.IgnoreCase);

            result = Regex.Replace(result,
                @"&bull;", " * ",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&lsaquo;", "<",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&rsaquo;", ">",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&trade;", "(tm)",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&frasl;", "/",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&lt;", "<",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&gt;", ">",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&copy;", "(c)",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                @"&reg;", "(r)",
                RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see

            result = Regex.Replace(result,
                @"&(.{2,6});", string.Empty,
                RegexOptions.IgnoreCase);

            // for testing
            //System.Text.RegularExpressions.Regex.Replace(result,
            //       this.txtRegex.Text,string.Empty,
            //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4.
            // Prepare first to remove any whitespaces in between
            // the escaped characters and remove redundant tabs in between line breaks
            result = Regex.Replace(result,
                "(\r)( )+(\r)", "\r\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\t)( )+(\t)", "\t\t",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\t)( )+(\r)", "\t\r",
                RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                "(\r)( )+(\t)", "\r\t",
                RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = Regex.Replace(result,
                "(\r)(\t)+(\r)", "\r\r",
                RegexOptions.IgnoreCase);
            // Remove multiple tabs following a line break with just one tab
            result = Regex.Replace(result,
                "(\r)(\t)+", "\r\t",
                RegexOptions.IgnoreCase);
            // Initial replacement target string for line breaks
            var breaks = "\r\r\r";
            // Initial replacement target string for tabs
            var tabs = "\t\t\t\t\t";
            for (var index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }
            //Convert line breaks to <br />
            if (blnLineBreaks)
            {
                result = result.Replace("\r", "<br />");
                result = result.Replace("\n", "<br />");
            }
            // That's it.
            return result;
        }

        /// <summary>
        ///     Change the Title to url specific title
        /// </summary>
        /// <param name="strPlainText">The string to convert to Title</param>
        /// <returns>The string of url Title</returns>
        public static string toTitle(string strPlainText)
        {
            var strTitle = strPlainText.ToLower();
            //Remove # sign
            strTitle = Replace(strTitle, '#', '-');
            strTitle = Replace(strTitle, ' ', '-');
            //strTitle = strTitle.Replace(' ', '-');
            return strTitle;
        }

        /// <summary>
        ///     Change the case of the first letter of each word to upper case.
        /// </summary>
        /// <param name="strText">The string to convert to title case.</param>
        /// <param name="culture">The culture information to be used.</param>
        /// <param name="forceCasing">When true, forces all words to be lower case before changing everything to title case.</param>
        /// <returns>The string in title case.</returns>
        public static string ToTitleCase(string strText, CultureInfo culture, bool forceCasing)
        {
            if (forceCasing)
            {
                return culture.TextInfo.ToTitleCase(strText.ToLower());
            }
            return culture.TextInfo.ToTitleCase(strText);
        }

        /// <summary>
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string ToUpperCase(string strText)
        {
            if (!string.IsNullOrEmpty(strText))

                return strText.ToUpper();
            return string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToUpperCase(string strText, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(strText))

                return strText.ToUpper(culture);
            return string.Empty;
        }

        /// <summary>
        ///     Converts to lower alphabets
        /// </summary>
        /// <param name="strText">
        ///     Text needs to convert
        /// </param>
        /// <returns>Lower case text </returns>
        public static string ToLoawerCase(string strText)
        {
            if (!string.IsNullOrEmpty(strText))

                return strText.ToLower();
            return string.Empty;
        }

        /// <summary>
        ///     Convert to lowercase per specific culture
        /// </summary>
        /// <param name="strText">Text needs to convert</param>
        /// <param name="culture">Current Culture</param>
        /// <returns>Lower text per culture</returns>
        public static string ToLoawerCase(string strText, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(strText))

                return strText.ToLower(culture);
            return string.Empty;
        }

        public static bool Authorised(int intUserID, string strRoleID, Hashtable newHT)
        {
            var blnRes = false;


            if (HashTable.MatchKey(strRoleID, newHT))
            {
                if (intUserID == ToInt(HashTable.FindSingleValue(strRoleID, newHT)))
                {
                    blnRes = true;
                }
            }
            else
            {
                blnRes = false;
            }

            return blnRes;
        }

        public static string Replace(string strText, string strOldValue, string strNewValue)
        {
            return strText.Replace(strOldValue, strNewValue);
        }

        public static string Replace(string strText, char OldValue, char NewValue)
        {
            return strText.Replace(OldValue, NewValue);
        }

        /// <summary>
        ///     Add a new column in a Table
        /// </summary>
        /// <param name="dtTable"></param>
        /// <param name="strColName"></param>
        public static void AddColumn(DataTable dtTable, string strColName)
        {
            dtTable.Columns.Add(new DataColumn(strColName));
        }

        private static bool IsValid(string value)
        {
            return Regex.IsMatch(value, @"^[a-z]*$");
        }

        public static string GenerateTicketId()
        {
            var strTicketID = string.Empty;
            var strLeft = string.Empty;
            var strRight = string.Empty;
            var nGUID = Guid.NewGuid();
            var j = 0;
            var chCode = ToLoawerCase(nGUID.ToString("N")).ToCharArray();
            for (var i = 0; i < chCode.Length; i++)
            {
                if (IsValid(chCode[i].ToString()))
                {
                    if (j > 3) continue;
                    j += 1;
                    strLeft += chCode[i];
                }
                else
                {
                    strRight += chCode[i];
                }
            }
            return ToUpperCase((strLeft + "-" + strRight).Substring(1, 10));
        }
    }
}