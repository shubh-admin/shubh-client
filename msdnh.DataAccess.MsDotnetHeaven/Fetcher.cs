using System;
using System.Data;
using System.Data.SqlClient;

//using msdnm.Common;
using msdnh.DataAccess.Base;
using msdnh.util;


namespace msdnh.DataAccess.MsDotnetHeaven
{
    /// <summary>
    /// 
    /// </summary>
    public class Fetcher : FetcherBase, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public Fetcher()
        {
        }
        /// <summary>
        /// Status :2 for all status
        /// Category:0 for all categories
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(string strTableName)
        {
            SqlCommand = "spGetImages";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImages";
            Parameters.Add(new SqlParameter("@Status", SqlDbType.Int));
            Parameters["@Status"].Value = 2;
            Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100));
            Parameters["@CategoryName"].Value = "0";

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>


        public DataSet GetImages(Boolean blnStatus, String strTableName)
        {
            SqlCommand = "spGetImages";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImages";

            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));
            Parameters.AddWithValue("@CategoryName", "0");

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strCatName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(bool blnStatus, string strCatName, string strTableName)
        {
            SqlCommand = "spGetImages";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImages";

            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));
            Parameters.AddWithValue("@CategoryName", strCatName);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="intCatId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesByCatId(Int32 intCatId, String strTableName)
        {
            return GetImagesByCatId(false, intCatId, strTableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="intCatId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesByCatId(bool blnStatus, int intCatId, string strTableName)
        {
            SqlCommand = "spGetImagesByCatId";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImagesByCatId";

            Parameters.AddWithValue("@CategoryId", intCatId);
            Parameters.AddWithValue("@SortValue", null);
            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="intCatId"></param>
        /// <param name="intSortValue"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesByCatId(bool blnStatus, int intCatId, int intSortValue, string strTableName)
        {
            SqlCommand = "spGetImagesByCatId";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImagesByCatId";

            Parameters.AddWithValue("@CategoryId", intCatId);
            Parameters.AddWithValue("@SortValue", intSortValue);
            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="intImgId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesById(Boolean blnStatus, Int32 intImgId, String strTableName)
        {
            SqlCommand = "spGetImagesById";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImagesById";

            Parameters.AddWithValue("@ImgId", intImgId);
            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImageDetail(String strTableName)
        {
            SqlCommand = "spGetImageDetail";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImageDetail";

            Parameters.AddWithValue("@ImageId", null);


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intImgId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImageDetail(Int32 intImgId, String strTableName)
        {
            SqlCommand = "spGetImageDetail";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImageDetail";

            Parameters.AddWithValue("@ImageId", intImgId);


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strImage"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImageDetailByImage(bool blnStatus, String strImage, String strTableName)
        {
            SqlCommand = "spGetImageDetailByImage";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImageDetailByImage";

            Parameters.AddWithValue("@Image", strImage);
            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intCatId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImageDetailByCatId(Int32 intCatId, String strTableName)
        {
            SqlCommand = "spGetImageDetailByCatId";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImageDetailByCatId";

            Parameters.AddWithValue("@CatId", intCatId);


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCategoryName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesForCategory(String strCategoryName, String strTableName)
        {
            SqlCommand = "spGetImagesForCategory";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImagesForCategory";

            Parameters.AddWithValue("@CatName", strCategoryName);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetImagesCategory(Boolean blnStatus, String strTableName)
        {
            SqlCommand = "spGetImagesCategory";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetImagesCategory";

            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }


        /// <summary>
        /// Check the existance of user
        /// </summary>
        /// <param name="strUserName">UserName</param>
        /// <param name="strEmail">Valid Email</param>
        /// <returns>True/False quoting existance of user</returns>
        public bool CheckUser(string strUserName, string strEmail)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            bool blRes = false;
            ds = GetActivationDetail(strUserName, strEmail, "CheckUser", string.Empty);

            if ((ds != null) && ds.Tables.Contains("CheckUser"))
            {
                var intRes = ds.Tables["CheckUser"].Rows.Count;
                if (intRes > 0)
                    blRes = true;
            }
            return blRes;

        }
        /// <summary>
        /// Retrieve registered user public profile
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUserProfile(Int32 intUserId, String strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (String.IsNullOrEmpty(strTableName))
                strTableName = "GetUserProfile";
            SqlCommand = "spGetUserProfile";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserID", intUserId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// Get User Submission
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUserSubmission(Int32 intUserId, String strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (String.IsNullOrEmpty(strTableName))
                strTableName = "UserSubmission";
            SqlCommand = "spGetUserSubmission";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserID", intUserId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUserStats(Int32 intUserId, String strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (String.IsNullOrEmpty(strTableName))
                strTableName = "UserStats";
            SqlCommand = "spGetUserStats";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserID", intUserId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strEmail"></param>
        /// <param name="strTableName"></param>
        /// <param name="strActivationKey"></param>
        /// <returns></returns>
        public DataSet GetActivationDetail(string strUserName, string strEmail, string strTableName, string strActivationKey)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqlCommand = "spCheckUser";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@Email", strEmail);
            Parameters.AddWithValue("@ActivationKey", strActivationKey);
            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strEmail"></param>
        /// <param name="strTableName"></param>
        /// <param name="strActivationKey"></param>
        /// <returns></returns>
        public DataSet GetActivationDetail(string strEmail, string strTableName, string strActivationKey)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string strValieEmail = string.Empty;
            string strUserName = string.Empty;
            //Check wheter username or email
            if (ValidationUtils.IsValidEmail(strEmail))
                strValieEmail = strEmail;
            else
                strUserName = strEmail;

            SqlCommand = "spCheckUser";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@Email", strValieEmail);
            Parameters.AddWithValue("@ActivationKey", strActivationKey);
            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strUserID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetServicesDetail(string strUserName, string strUserID, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblServices_spGetServices";
            SqlCommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(strUserName))
                Parameters.AddWithValue("@UserName", strUserName);

            if (!string.IsNullOrEmpty(strUserID))
                Parameters.AddWithValue("@ID", strUserID);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strUserID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetDomainsDetail(string strUserName, string strUserID, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblServices_spGetDomains";
            SqlCommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(strUserName))
                Parameters.AddWithValue("@UserName", strUserName);

            if (!string.IsNullOrEmpty(strUserID))
                Parameters.AddWithValue("@ID", strUserID);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetDomainsByID(string strID, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblDomains_spGetDomainByID";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ID", strID);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserID"></param>
        /// <param name="blnIsArchive"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetTransactionDetails(Int32 intUserID, Boolean blnIsArchive, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetTransactionDetails";
            SqlCommand = "tblTransaction_spGetTransactionDetails";
            SqlCommandType = CommandType.StoredProcedure;


            Parameters.AddWithValue("@UserID", intUserID);
            Parameters.AddWithValue("@IsArchive", blnIsArchive);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserID"></param>
        /// <param name="intMessageID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMessagesDetail(int intUserID, int intMessageID, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblMessages_spGetMessages";
            SqlCommandType = CommandType.StoredProcedure;


            if (intUserID != 0)
                Parameters.AddWithValue("@ID", intUserID);
            if (intMessageID != 0)
                Parameters.AddWithValue("@MessageID", intMessageID);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserID"></param>
        /// <param name="intSupportID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetSupportDetail(int intUserID, int intSupportID, string strTableName)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblSupport_spGetSupportDetails";
            SqlCommandType = CommandType.StoredProcedure;


            if (intUserID != 0)
                Parameters.AddWithValue("@ID", intUserID);
            if (intSupportID != 0)
                Parameters.AddWithValue("@ISSUEID", intSupportID);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);
                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strUserPassword"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>

        public DataSet UserCredentials(string strUserName, string strUserPassword, string strTableName)
        {
            if (VerifyCredentials(strUserName, strUserPassword))
            {
                ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

                SqlCommand = "spCheckUser";
                SqlCommandType = CommandType.StoredProcedure;
                Parameters.AddWithValue("@UserName", strUserName);
                Parameters.AddWithValue("@Email", strUserName);
                Parameters.AddWithValue("@ActivationKey", string.Empty);
                using (DataSet ds = new DataSet())
                {
                    Fill(ds, strTableName);


                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strUsePassword"></param>
        /// <returns></returns>
        public bool VerifyCredentials(string strUserName, string strUsePassword)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqlCommand = "SELECT * FROM [dbo].[USERS] WHERE (USERNAME = @UserName OR EMAIL_ID = @UserName) AND PASSWORD = @UsePassword";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@UsePassword", strUsePassword);
            Int32 intCount = 0;
            intCount = Convert.ToInt32(ExecuteScalar());
            return (intCount != 0);
        }
        /// <summary>
        /// Check whether login is valid
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strUsePassword"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public bool VerifyCredentials(string strUserName, string strUsePassword, string strType)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqlCommand = "SELECT 1 FROM [dbo].[tblLogin] WHERE (USERNAME = @UserName OR EMAIL = @UserName ) AND (PASSWORD = @UserPassword AND Type = @Type)";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@UserPassword", strUsePassword);
            Parameters.AddWithValue("@Type", strType);
            Int32 intCount = 0;
            Boolean blnRes = false;
            intCount = msdnh.util.CleanUtils.ToInt(ExecuteScalar());
            if (intCount > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strID"></param>
        /// <param name="strUsePassword"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public bool VerifyPassword(string strUserName, string strID, string strUsePassword, string strType)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqlCommand = "SELECT 1 FROM [dbo].[tblLogin] WHERE (USERNAME = @UserName OR ID = @strID ) AND (PASSWORD = @UserPassword AND Type = @Type)";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@strID", strID);
            Parameters.AddWithValue("@UserPassword", strUsePassword);
            Parameters.AddWithValue("@Type", strType);
            Int32 intCount = 0;
            Boolean blnRes = false;
            intCount = msdnh.util.CleanUtils.ToInt(ExecuteScalar());
            if (intCount > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// Check wheter username,accid,email of same type exist
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strACCID"></param>
        /// <param name="strType"></param>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public Int32 VerifyExistance(string strUserName, string strACCID, string strType, string strEmail)
        {
            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            SqlCommand = "SELECT 1 FROM [dbo].[tblLogin] WHERE (USERNAME = @UserName OR EMAIL = @Email OR  ACCID = @ACCID) AND Type = @Type";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserName", strUserName);
            Parameters.AddWithValue("@Email", strEmail);
            Parameters.AddWithValue("@Type", strType);
            Parameters.AddWithValue("@ACCID", strACCID);
            Int32 intCount = 0;

            intCount = msdnh.util.CleanUtils.ToInt(ExecuteScalar());

            return intCount;
        }
        /// <summary>
        /// Get users per username
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUsers(string strUserName, string strTableName)
        {

            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblLogin_spGetUser";
            SqlCommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(strUserName))
                Parameters.AddWithValue("@UserName", strUserName);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);


                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUsers(string strUserName, string strID, string strTableName)
        {

            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            SqlCommand = "tblLogin_spGetUser";
            SqlCommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(strID))
                Parameters.AddWithValue("@ID", strID);

            if (!string.IsNullOrEmpty(strUserName))
                Parameters.AddWithValue("@UserName", strUserName);
            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);


                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="intStatus"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUsersByType(string strType, int intStatus, string strTableName)
        {

            ErrorMessage = this.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;

            string strCommand = "Select * From tblLogin Where Type = @Type and Status = @Status";
            //SqlCommandType = CommandType.Text;

            Parameters.AddWithValue("@Type", strType);
            Parameters.AddWithValue("@Status", intStatus);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName, strCommand);


                if (ds.Tables[strTableName].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="chConcateWith"></param>
        /// <returns></returns>

        public string GetUserRoles(string strUserId, char chConcateWith)
        {
            SqlCommand = "spGetUserRoles";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserId", strUserId);

            string strTableName = "UserRoles";
            string strUserRoles = string.Empty;

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                //return empty string if dataset is null or blank

                if (ds != null)
                {
                    if (ds.Tables[strTableName].Rows.Count <= 0)
                    {
                        return string.Empty;
                    }
                    if (ds.Tables[strTableName].Rows.Count > 0)
                    {
                        //if (chConcateWith != null)
                        //{
                        //    //Concatenate-only when rows are multiple and return as string
                        //    // strUserRoles = ds.Tables[strTableName].Rows[0]["roles"].ToString();
                        //    strUserRoles = ds.Tables[strTableName].Rows[0]["roleid"].ToString();
                        //    for (int i = 1; i <= ds.Tables[strTableName].Rows.Count - 1; i++)
                        //    {
                        //        strUserRoles += chConcateWith + ds.Tables[strTableName].Rows[i]["roleid"].ToString();
                        //    }
                        //}
                        //else
                        //{
                        strUserRoles = ds.Tables[strTableName].Rows[0]["roleid"].ToString() + "/" + ds.Tables[strTableName].Rows[0]["roles"].ToString();
                        for (int i = 1; i <= ds.Tables[strTableName].Rows.Count - 1; i++)
                        {
                            strUserRoles += chConcateWith + ds.Tables[strTableName].Rows[i]["roleid"].ToString() + "/" + ds.Tables[strTableName].Rows[i]["roles"].ToString();
                        }
                        //}
                        return strUserRoles;
                    }
                }
                else
                {
                    return string.Empty;
                }
                return null;    //Omits not all code paths return a value
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intResTypeId"></param>
        /// <param name="intCatId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetCategoryList(Int32 intResTypeId, Int32 intCatId, string strTableName)
        {
            SqlCommand = "spGetCategoryList";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ResTypeId", intResTypeId);
            Parameters.AddWithValue("@CatId", intCatId);

            if (string.IsNullOrEmpty(strTableName))
                strTableName = "CategoryList";

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if (ds != null)
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intResTypeId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetResourcesType(Int32 intResTypeId, string strTableName)
        {
            SqlCommand = "spGetResourcesType";
            SqlCommandType = CommandType.StoredProcedure;


            if (string.IsNullOrEmpty(strTableName))
                strTableName = "ResourcesType";

            Parameters.AddWithValue("@ResTypeId", intResTypeId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intCatId"></param>
        /// <param name="intSubCatId"></param>
        /// <param name="dtStartDate"></param>
        /// <param name="dtEndDate"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetResourcesList(Int32 intCatId, Int32 intSubCatId, DateTime dtStartDate, DateTime dtEndDate, string strTableName)
        {
            SqlCommand = "spGetResourcesList";
            SqlCommandType = CommandType.StoredProcedure;

            if (dtStartDate == null)
                dtStartDate = Convert.ToDateTime("01/01/1900");
            if (dtEndDate == null)
                dtEndDate = DateTime.Now;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "ResourcesList";

            Parameters.AddWithValue("@CatId", intCatId);
            Parameters.AddWithValue("@SubCatId", intSubCatId);
            Parameters.AddWithValue("@StartDate", dtStartDate);
            Parameters.AddWithValue("@EndDate", dtEndDate);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intResId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetSelectedResource(Int32 intResId, string strTableName)
        {
            SqlCommand = "spGetSelectedResource";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "SelectedResource";
            Parameters.AddWithValue("@ResId", intResId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetComments(Int32 intResourceId, String strTableName)
        {
            SqlCommand = "spGetComments";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetComments";

            Parameters.AddWithValue("@ResourceId", intResourceId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetMetaForSelectedResource(Int32 intResId, string strTableName)
        {
            SqlCommand = "spGetMetaForSelectedResource";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "MetaForSelectedResource";
            Parameters.AddWithValue("@ResId", intResId);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetContacts(bool blnStatus, String strTableName)
        {
            SqlCommand = "spGetContacts";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetContacts";

            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        public DataSet GetErrorLog(string strTableName)
        {
            SqlCommand = "spGetErrorLog";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetErrorLog";

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetCountry(String strTableName)
        {
            SqlCommand = "spGetCountry";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetCountry";


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        public DataSet GetMyResources(int intResourceTypeId, int intUserId, bool blnShowAll, String strTableName)
        {
            SqlCommand = "spGetMyResources";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetMyResources";

            Parameters.AddWithValue("@UserID", intUserId);
            Parameters.AddWithValue("@ResourceTypeID", intResourceTypeId);
            Parameters.AddWithValue("@ShowAll", blnShowAll);

            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intRecepientId"></param>
        /// <param name="intMessageId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMyMessages(int intRecepientId, int intMessageId, String strTableName)
        {
            SqlCommand = "spGetMyMessages";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetMyMessages";

            Parameters.AddWithValue("@MessageID", intMessageId);
            Parameters.AddWithValue("@RecepientID", intRecepientId);


            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMyMembers(int intUserId, String strTableName)
        {
            SqlCommand = "spGetMyMembers";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetMyMembers";

            Parameters.AddWithValue("@UserID", intUserId);



            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        /// <summary>
        /// Get EmailTemplates
        /// </summary>
        /// <param name="intEmailID"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetEmailTemplate(int intEmailID, string strTableName)
        {
            SqlCommand = "spGetEmailTemplate";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetEmailTemplate";

            Parameters.AddWithValue("@EmailID", intEmailID);



            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    if (ds.Tables[strTableName].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            return null;    //Omits not all code paths return a value

        }

        /// <summary>
        /// GetMenus by Menu Type
        /// </summary>
        /// <param name="intMenuType"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMenuByType(int intMenuType, string strTableName)
        {
            SqlCommand = "spGetMenuByType";
            SqlCommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(strTableName))
                strTableName = "GetEmailTemplate";

            Parameters.AddWithValue("@MenuType", intMenuType);



            using (DataSet ds = new DataSet())
            {
                Fill(ds, strTableName);

                if ((ds != null) && (ds.Tables.Contains(strTableName)))
                {
                    return ds.Tables[strTableName].Rows.Count > 0 ? ds : null;
                }
            }
            return null;    //Omits not all code paths return a value

        }
    }

}
