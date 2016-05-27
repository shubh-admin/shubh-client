using System;
using System.Data;
using msdnh.DataAccess.MsDotnetHeaven;

namespace msdnh.BF.MsDotnetHeaven
{
    /// <summary>
    /// 
    /// </summary>
    public class MsDotNetHeaven
    {
        #region Fetcher based Calls

        /// <summary>
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImages(strTableName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetUserProfile(int intUserId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUserProfile(intUserId, strTableName);
            }
        }


        public DataSet GetUserSubmission(int intUserId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUserSubmission(intUserId, strTableName);
            }
        }

        public DataSet GetUserStats(int intUserId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUserStats(intUserId, strTableName);
            }
        }

        public DataSet GetResourcesType(int intResTypeId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetResourcesType(intResTypeId, strTableName);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(bool blnStatus, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImages(blnStatus, strTableName);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strCatName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(bool blnStatus, string strCatName, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImages(blnStatus, strCatName, strTableName);
            }
        }

        public DataSet GetImagesByCatId(bool blnStatus, int intCatId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImagesByCatId(blnStatus, intCatId, strTableName);
            }
        }

        public DataSet GetImagesByCatId(bool blnStatus, int intCatId, int intSortValue, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImagesByCatId(blnStatus, intCatId, intSortValue, strTableName);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="strCategoryName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesForCategory(string strCategoryName, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImagesForCategory(strCategoryName, strTableName);
            }
        }

        public DataSet GetImagesCategory(bool blnStatus, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImagesCategory(blnStatus, strTableName);
            }
        }

        public DataSet GetImagesById(bool blnStatus, int intImgId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImagesById(blnStatus, intImgId, strTableName);
            }
        }

        public bool CheckUser(string strUserName, string strEmail)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.CheckUser(strUserName, strEmail);
            }
        }

        public DataSet GetActivationDetail(string strEmail, string strTableName, string strActivationKey)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetActivationDetail(strEmail, strTableName, strActivationKey);
            }
        }

        public DataSet GetActivationDetail(string strUserName, string strEmail, string strTableName,
            string strActivationKey)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetActivationDetail(strUserName, strEmail, strTableName, strActivationKey);
            }
        }

        public string GetUserRoles(string strUserId, char chConcateWith)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUserRoles(strUserId, chConcateWith);
            }
        }

        public DataSet GetCategoryList(int intResTypeId, int intCatId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetCategoryList(intResTypeId, intCatId, strTableName);
            }
        }

        public DataSet GetResourcesList(int intCatId, int intSubCatId, DateTime dtStartDate, DateTime dtEndDate,
            string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetResourcesList(intCatId, intSubCatId, dtStartDate, dtEndDate, strTableName);
            }
        }

        public DataSet GetSelectedResource(int intResId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetSelectedResource(intResId, strTableName);
            }
        }

        public DataSet GetMetaForSelectedResource(int intResId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMetaForSelectedResource(intResId, strTableName);
            }
        }

        public string DecrypString(string strPwd)
        {
            using (var utility = new Utility())
            {
                return utility.DecryptString(strPwd);
            }
        }

        public string EncryptString(string strPwd)
        {
            using (var utility = new Utility())
            {
                return utility.EncryptString(strPwd);
            }
        }

        public string HashPassword(string strPasswordToBeEncrypted)
        {
            using (var utility = new Utility())
            {
                return utility.HashPassword(strPasswordToBeEncrypted);
            }
        }

        public DataSet GetComments(int intResourceId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetComments(intResourceId, strTableName);
            }
        }

        public bool VerifyCredentials(string strUserName, string strUsePassword)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.VerifyCredentials(strUserName, strUsePassword);
            }
        }

        public bool VerifyCredentials(string strUserName, string strUsePassword, string strType)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.VerifyCredentials(strUserName, strUsePassword, strType);
            }
        }

        public int VerifyExistance(string strUserName, string strACCID, string strType, string strEmail)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.VerifyExistance(strUserName, strACCID, strType, strEmail);
            }
        }

        public bool VerifyPassword(string strUserName, string strID, string strUsePassword, string strType)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.VerifyPassword(strUserName, strID, strUsePassword, strType);
            }
        }

        public DataSet UserCredentials(string strUserName, string strUserPassword, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.UserCredentials(strUserName, strUserPassword, strTableName);
            }
        }

        public DataSet GetUsers(string strUserName, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUsers(strUserName, strTableName);
            }
        }

        public DataSet GetUsers(string strUserName, string strID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUsers(strUserName, strID, strTableName);
            }
        }

        public DataSet GetUsersByType(string strType, int intStatus, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetUsersByType(strType, intStatus, strTableName);
            }
        }

        public DataSet GetImageDetail(string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImageDetail(strTableName);
            }
        }

        public DataSet GetImageDetail(int intImgId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImageDetail(intImgId, strTableName);
            }
        }


        public DataSet GetImageDetailByCatId(int intCatId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImageDetailByCatId(intCatId, strTableName);
            }
        }

        public DataSet GetImageDetailByImage(bool blnStatus, string strImage, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetImageDetailByImage(blnStatus, strImage, strTableName);
            }
        }

        public DataSet GetContacts(bool blnStatus, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetContacts(blnStatus, strTableName);
            }
        }

        public DataSet GetErrorLog(string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetErrorLog(strTableName);
            }
        }

        public DataSet GetCountry(string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetCountry(strTableName);
            }
        }

        public DataSet GetMyResources(int intResourceTypeId, int intUserId, bool blnShowAll, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMyResources(intResourceTypeId, intUserId, blnShowAll, strTableName);
            }
        }

        public DataSet GetServicesDetail(string strUserName, string strUserID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetServicesDetail(strUserName, strUserID, strTableName);
            }
        }

        public DataSet GetDomainsDetail(string strUserName, string strUserID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetDomainsDetail(strUserName, strUserID, strTableName);
            }
        }

        public DataSet GetDomainsByID(string strID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetDomainsByID(strID, strTableName);
            }
        }

        public DataSet GetTransactionDetails(int intUserID, bool blnIsArchive, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetTransactionDetails(intUserID, blnIsArchive, strTableName);
            }
        }

        public DataSet GetMessagesDetail(int intUserID, int intMessageID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMessagesDetail(intUserID, intMessageID, strTableName);
            }
        }

        public DataSet GetSupportDetail(int intUserID, int intSupportID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetSupportDetail(intUserID, intSupportID, strTableName);
            }
        }

        /// <summary>
        ///     Get Messages
        /// </summary>
        /// <param name="intRecepientId"></param>
        /// <param name="intMessageId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMyMessages(int intRecepientId, int intMessageId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMyMessages(intRecepientId, intMessageId, strTableName);
            }
        }

        public DataSet GetMyMembers(int intUserId, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMyMembers(intUserId, strTableName);
            }
        }

        public DataSet GetEmailTemplate(int intEmailID, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetEmailTemplate(intEmailID, strTableName);
            }
        }


        public DataSet GetMenuByType(int intMenuType, string strTableName)
        {
            using (var fetcher = new Fetcher())
            {
                return fetcher.GetMenuByType(intMenuType, strTableName);
            }
        }

        #endregion

        #region Modifier based calls

        /// <summary>
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strError"></param>
        /// <param name="strDesc"></param>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public bool LoggedError(string strUrl, string strError, string strDesc, DateTime dtDate)
        {
            using (var modifier = new Modifier())
            {
                return modifier.LoggedError(strUrl, strError, strDesc, dtDate);
            }
        }

        public bool RegisterUser(string FName, string LName, string Email, string Pwd)
        {
            using (var modifier = new Modifier())
            {
                return modifier.RegisterUser(FName, LName, Email, Pwd);
            }
        }

        public bool AddUser(string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY)
        {
            using (var modifier = new Modifier())
            {
                return modifier.AddUser(UserName, Password, Email, Type, ACCID, UPDATEDBY);
            }
        }

        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID,
            int UPDATEDBY)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateUser(strID, UserName, Password, Email, Type, ACCID, UPDATEDBY);
            }
        }

        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID,
            int UPDATEDBY, string strName, string strAdd1, string strAdd2, string strCity, string strCountry,
            string strPhone)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateUser(strID, UserName, Password, Email, Type, ACCID, UPDATEDBY, strName, strAdd1,
                    strAdd2, strCity, strCountry, strPhone);
            }
        }

        public bool AddDomains(string strUserID, string strStatus, string strDomain, string strPrice, string strRegDate,
            string strNextDue, int UPDATEDBY)
        {
            using (var modifier = new Modifier())
            {
                return modifier.AddDomains(strUserID, strStatus, strDomain, strPrice, strRegDate, strNextDue, UPDATEDBY);
            }
        }

        public bool UpdateDomains(string strUserID, string strID, string strStatus, string strDomain, string strPrice,
            string strRegDate, string strNextDue, int UPDATEDBY)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateDomains(strUserID, strID, strStatus, strDomain, strPrice, strRegDate, strNextDue,
                    UPDATEDBY);
            }
        }

        public bool LoggedUser(int intUserId, string strUserIP, bool blnIsLogged)
        {
            using (var modifier = new Modifier())
            {
                return modifier.LoggedUser(intUserId, strUserIP, blnIsLogged);
            }
        }

        public bool ActivateUser(string strUserId, string strActivate)
        {
            using (var modifire = new Modifier())
            {
                return modifire.ActivateUser(strUserId, strActivate);
            }
        }

        public bool DeleteUser(string strUserId)
        {
            using (var modifier = new Modifier())
            {
                return modifier.DeleteUser(strUserId);
            }
        }

        public bool GenerateResetKey(string strUserId, string strResetKey)
        {
            using (var modifier = new Modifier())
            {
                return modifier.GenerateResetKey(strUserId, strResetKey);
            }
        }

        public bool UpdateUserPassword(string strNewPassword, string strUserid)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateUserPassword(strNewPassword, strUserid);
            }
        }

        public bool SubmitComments(int intResourceId, int intUserId, DateTime dtDate, string strDescr)
        {
            using (var modifier = new Modifier())
            {
                return modifier.SubmitComments(intResourceId, intUserId, dtDate, strDescr);
            }
        }

        public bool SubmitResource(int intResourceId, int intCatId, int intSubCatId, int intUserId, string strTitle,
            string strDescr, string strUrl, int intCredits, bool blnUpdateView, string strMetaDesc, string strMetaKeys)
        {
            using (var modifier = new Modifier())
            {
                return modifier.SubmitResource(intResourceId, intCatId, intSubCatId, intUserId, strTitle, strDescr,
                    strUrl, intCredits, blnUpdateView, strMetaDesc, strMetaKeys);
            }
        }

        public bool InsertImages(string strCatName, int intCatId, string strImgCaption, string strImgDescr,
            string strImg, double dblCostINR, double dblCostUSD, bool blnStatus)
        {
            using (var modifier = new Modifier())
            {
                return modifier.InsertImages(strCatName, intCatId, strImgCaption, strImgDescr, strImg, dblCostINR,
                    dblCostUSD, blnStatus);
            }
        }

        public bool DeleteImageById(int intImgId)
        {
            using (var modifier = new Modifier())
            {
                return modifier.DeleteImageById(intImgId);
            }
        }

        public bool UpdateImageById(string strCategoryName, int intCategoryId, string strImageCaption,
            string strImageDescr, double dblCostINR, double dblCostUSD, int intImageOrder, int intImageId)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateImageById(strCategoryName, intCategoryId, strImageCaption, strImageDescr,
                    dblCostINR, dblCostUSD, intImageOrder, intImageId);
            }
        }

        public bool DeleteImageDetailById(int intId)
        {
            using (var modifier = new Modifier())
            {
                return modifier.DeleteImageDetailById(intId);
            }
        }

        public bool UpdateImageDetailById(string strSize, string strCraft, double dblCostINR, double dblCostUSD,
            string strOther, int intId)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateImageDetailById(strSize, strCraft, dblCostINR, dblCostUSD, strOther, intId);
            }
        }

        public bool InsertImageDetail(int intImageId, string strSize, string strCraft, double dblCostINR,
            double dblCostUSD, string strOther)
        {
            using (var modifier = new Modifier())
            {
                return modifier.InsertImageDetail(intImageId, strSize, strCraft, dblCostINR, dblCostUSD, strOther);
            }
        }

        public bool DeleteContacts(int intID)
        {
            using (var modifier = new Modifier())
            {
                return modifier.DeleteContacts(intID);
            }
        }

        public bool DeleteErrorLog()
        {
            using (var modifier = new Modifier())
            {
                return modifier.DeleteErrorLog();
            }
        }

        public bool UpdateUserProfile(int intUserId, string strDisplayName, string strFName, string strLName,
            string strState,
            string strCountry, string strImage, string strProfile, string strSignature, bool blnAccepted,
            bool blnNewsLetters)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateUserProfile(intUserId, strDisplayName, strFName, strLName, strState, strCountry,
                    strImage, strProfile, strSignature, blnAccepted, blnNewsLetters);
            }
        }


        public bool UpdateResource(int intResourceId, int intCatId, int intSubCatId, int intUserId, int intEditedBy,
            string strTitle, string strDescr, string strUrl, int intCredits, string strMetaDesc, string strMetaKeys)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateResource(intResourceId, intCatId, intSubCatId, intUserId, intEditedBy, strTitle,
                    strDescr, strUrl, intCredits, strMetaDesc, strMetaKeys);
            }
        }

        public bool SendMessage(int intRecepientID, int intSenderID, string strSubject, string strMessage)
        {
            using (var modifier = new Modifier())
            {
                return modifier.SendMessage(intRecepientID, intSenderID, strSubject, strMessage);
            }
        }

        public bool GenerateTicket(string strTicketID, int intUserID, string strDepartment, string strPriority,
            string strPanelDetail, string strACCID, string strSubject, string strQuery, string strStatus,
            int intUpdatedBy)
        {
            using (var modifier = new Modifier())
            {
                return modifier.GenerateTicket(strTicketID, intUserID, strDepartment, strPriority, strPanelDetail,
                    strACCID, strSubject, strQuery, strStatus, intUpdatedBy);
            }
        }

        public bool UpdateTicket(string strTicketID, string strQuery, string strStatus, int intUpdatedBy)
        {
            using (var modifier = new Modifier())
            {
                return modifier.UpdateTicket(strTicketID, strQuery, strStatus, intUpdatedBy);
            }
        }

        #endregion
    }
}