using System.Collections.Generic;

namespace msdnh.util
{
    /// <summary>
    ///     Enumerates for Url Section
    /// </summary>
    public enum UrlSection
    {
        /// <summary>
        ///     The Profile Link - author,member etc.
        /// </summary>
        Author = 1,
        ResourceType = 2,
        CategoryType = 3,
        Resource = 4,
        Member = 5,
        MyContribution = 6,
        EditPost = 7
    }

    /// <summary>
    ///     To build Urls
    /// </summary>
    public static class BuildUrl
    {
        #region Build Urls

        /// <summary>
        ///     To get dynamic Urls
        /// </summary>
        /// <param name="urlSection">
        ///     Section name for which url is meant for
        /// </param>
        /// <param name="lStrArgs">
        ///     List containing Querystring values
        /// </param>
        /// <returns>
        ///     Dynamic or Actual Url as per Config values
        /// </returns>
        public static string GetDynamicUrl(UrlSection urlSection, List<string> lStrArgs)
        {
            var strDynUrl = string.Empty;
            var strUrl = string.Empty;
            var strReturnUrl = string.Empty;
            var intLength = lStrArgs.Count;

            switch (CleanUtils.ToInt(urlSection))
            {
                case 1:
                    strDynUrl = Config.GetConfigValueAsString(urlSection + "UrlDynamic");
                    strUrl = Config.GetConfigValueAsString(urlSection + "UrlActual");
                    break;
                default:
                    strDynUrl = Config.GetConfigValueAsString(urlSection + "UrlDynamic");
                    strUrl = Config.GetConfigValueAsString(urlSection + "UrlActual");
                    break;
            }
            if (Config.EnableURLRewriting)
            {
                strReturnUrl = strDynUrl;
            }
            else
            {
                strReturnUrl = strUrl;
            }

            for (var i = 0; i < intLength; i++)
            {
                strReturnUrl = CleanUtils.Replace(strReturnUrl, "[$" + CleanUtils.ToString(i) + "]",
                    CleanUtils.ToString(lStrArgs[i]));
            }

            strReturnUrl = Config.EnableURLRewriting
                ? strReturnUrl + Config.GetConfigValueAsString("urlExt")
                : strReturnUrl;

            return strReturnUrl;
        }

        /// <summary>
        /// </summary>
        /// <param name="strConfigUrl"></param>
        /// <param name="strUrl"></param>
        /// <param name="lStrArgs"></param>
        /// <returns></returns>
        public static string GetDynamicUrl(string strConfigUrl, string strUrl, List<string> lStrArgs)
        {
            var intLength = lStrArgs.Count;
            var strDynamicUrl = strConfigUrl;
            for (var i = 0; i < intLength; i++)
            {
                strDynamicUrl.Replace("$" + CleanUtils.ToString(i), lStrArgs[i]);
            }


            return strDynamicUrl + Config.GetConfigValueAsString("urlExt");
        }

        #endregion
    }
}