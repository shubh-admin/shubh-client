using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using msdnh.DataAccess.MsDotnetHeaven;
using msdnh.Common.Data.MsDotnetHeaven;

namespace msdnh.BF.MsDotnetHeaven
{
    public class MsDotNetHeaven
    {
        public MsDotNetHeaven()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Fetcher based Calls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImages(strTableName);
            }
        }
        public DataSet GetUserProfile(Int32 intUserId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUserProfile(intUserId, strTableName);
            }
        }


        public DataSet GetUserSubmission(Int32 intUserId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUserSubmission(intUserId, strTableName);
            }
        }

        public DataSet GetUserStats(Int32 intUserId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUserStats(intUserId, strTableName);
            }
        }
        public DataSet GetResourcesType(Int32 intResTypeId, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetResourcesType(intResTypeId, strTableName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>

        public DataSet GetImages(Boolean blnStatus, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImages(blnStatus, strTableName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnStatus"></param>
        /// <param name="strCatName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImages(Boolean blnStatus, string strCatName, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImages(blnStatus, strCatName, strTableName);
            }
        }
        public DataSet GetImagesByCatId(Boolean blnStatus, Int32 intCatId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImagesByCatId(blnStatus, intCatId, strTableName);
            }
        }
        public DataSet GetImagesByCatId(Boolean blnStatus, Int32 intCatId, Int32 intSortValue, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImagesByCatId(blnStatus, intCatId, intSortValue, strTableName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCategoryName"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetImagesForCategory(String strCategoryName, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImagesForCategory(strCategoryName, strTableName);
            }
        }

        public DataSet GetImagesCategory(Boolean blnStatus, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImagesCategory(blnStatus, strTableName);
            }
        }

        public DataSet GetImagesById(Boolean blnStatus, Int32 intImgId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImagesById(blnStatus, intImgId, strTableName);
            }
        }

        public bool CheckUser(string strUserName, string strEmail)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.CheckUser(strUserName, strEmail);
            }
        }
        public DataSet GetActivationDetail(string strEmail, string strTableName, string strActivationKey)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetActivationDetail(strEmail, strTableName, strActivationKey);
            }
        }
        public DataSet GetActivationDetail(string strUserName, string strEmail, string strTableName, string strActivationKey)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetActivationDetail(strUserName, strEmail, strTableName, strActivationKey);
            }
        }
        public string GetUserRoles(string strUserId, char chConcateWith)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUserRoles(strUserId, chConcateWith);
            }
        }
        public DataSet GetCategoryList(Int32 intResTypeId, Int32 intCatId, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetCategoryList(intResTypeId, intCatId, strTableName);

            }
        }
        public DataSet GetResourcesList(Int32 intCatId, Int32 intSubCatId, DateTime dtStartDate, DateTime dtEndDate, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetResourcesList(intCatId, intSubCatId, dtStartDate, dtEndDate, strTableName);

            }
        }
        public DataSet GetSelectedResource(Int32 intResId, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetSelectedResource(intResId, strTableName);
            }
        }
        public DataSet GetMetaForSelectedResource(Int32 intResId, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMetaForSelectedResource(intResId, strTableName);
            }
        }
        public string DecrypString(string strPwd)
        {
            using (Utility utility = new Utility())
            {
                return utility.DecryptString(strPwd);
            }
        }
        public string EncryptString(string strPwd)
        {
            using (Utility utility = new Utility())
            {
                return utility.EncryptString(strPwd);
            }
        }
        public string HashPassword(string strPasswordToBeEncrypted)
        {
            using (Utility utility = new Utility())
            {
                return utility.HashPassword(strPasswordToBeEncrypted);
            }
        }

        public DataSet GetComments(Int32 intResourceId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetComments(intResourceId, strTableName);
            }
        }
        public bool VerifyCredentials(string strUserName, string strUsePassword)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.VerifyCredentials(strUserName, strUsePassword);

            }
        }
        public bool VerifyCredentials(string strUserName, string strUsePassword, string strType)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.VerifyCredentials(strUserName, strUsePassword, strType);
            }
        }
        public Int32 VerifyExistance(string strUserName, string strACCID, string strType, string strEmail)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.VerifyExistance(strUserName, strACCID, strType, strEmail);
            }
        }
        public bool VerifyPassword(string strUserName, string strID, string strUsePassword, string strType)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.VerifyPassword(strUserName, strID, strUsePassword, strType);
            }
        }

        public DataSet UserCredentials(string strUserName, string strUserPassword, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.UserCredentials(strUserName, strUserPassword, strTableName);
            }
        }
        public DataSet GetUsers(string strUserName, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUsers(strUserName, strTableName);
            }
        }
        public DataSet GetUsers(string strUserName, string strID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUsers(strUserName, strID, strTableName);
            }
        }
        public DataSet GetUsersByType(string strType, int intStatus, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetUsersByType(strType, intStatus, strTableName);
            }
        }
        public DataSet GetImageDetail(String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImageDetail(strTableName);
            }
        }
        public DataSet GetImageDetail(Int32 intImgId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImageDetail(intImgId, strTableName);
            }
        }


        public DataSet GetImageDetailByCatId(Int32 intCatId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImageDetailByCatId(intCatId, strTableName);
            }
        }
        public DataSet GetImageDetailByImage(bool blnStatus, String strImage, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetImageDetailByImage(blnStatus, strImage, strTableName);
            }
        }

        public DataSet GetContacts(bool blnStatus, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetContacts(blnStatus, strTableName);
            }
        }

        public DataSet GetErrorLog(string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetErrorLog(strTableName);
            }
        }

        public DataSet GetCountry(String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetCountry(strTableName);
            }
        }
        public DataSet GetMyResources(int intResourceTypeId, int intUserId, bool blnShowAll, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMyResources(intResourceTypeId, intUserId, blnShowAll, strTableName);
            }
        }
        public DataSet GetServicesDetail(string strUserName, string strUserID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetServicesDetail(strUserName, strUserID, strTableName);
            }
        }
        public DataSet GetDomainsDetail(string strUserName, string strUserID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetDomainsDetail(strUserName, strUserID, strTableName);
            }
        }
        public DataSet GetDomainsByID(string strID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetDomainsByID(strID, strTableName);
            }
        }
        public DataSet GetTransactionDetails(Int32 intUserID, Boolean blnIsArchive, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetTransactionDetails(intUserID, blnIsArchive, strTableName);
            }
        }
        public DataSet GetMessagesDetail(int intUserID, int intMessageID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMessagesDetail(intUserID, intMessageID, strTableName);
            }
        }
        public DataSet GetSupportDetail(int intUserID, int intSupportID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetSupportDetail(intUserID, intSupportID, strTableName);
            }
        }
        /// <summary>
        /// Get Messages
        /// </summary>
        /// <param name="intRecepientId"></param>
        /// <param name="intMessageId"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public DataSet GetMyMessages(int intRecepientId, int intMessageId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMyMessages(intRecepientId, intMessageId, strTableName);
            }
        }

        public DataSet GetMyMembers(int intUserId, String strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMyMembers(intUserId, strTableName);
            }
        }

        public DataSet GetEmailTemplate(int intEmailID, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetEmailTemplate(intEmailID, strTableName);
            }
        }


        public DataSet GetMenuByType(int intMenuType, string strTableName)
        {
            using (Fetcher fetcher = new Fetcher())
            {
                return fetcher.GetMenuByType(intMenuType, strTableName);
            }
        }



        #endregion


        #region Modifier based calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strError"></param>
        /// <param name="strDesc"></param>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public bool LoggedError(string strUrl, string strError, string strDesc, DateTime dtDate)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.LoggedError(strUrl, strError, strDesc, dtDate);
            }
        }
        public bool RegisterUser(string FName, string LName, string Email, string Pwd)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.RegisterUser(FName, LName, Email, Pwd);

            }
        }

        public bool AddUser(string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.AddUser(UserName, Password, Email, Type, ACCID, UPDATEDBY);
            }
        }

        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateUser(strID, UserName, Password, Email, Type, ACCID, UPDATEDBY);
            }
        }
        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY, string strName, string strAdd1, string strAdd2, string strCity, string strCountry, string strPhone)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateUser(strID, UserName, Password, Email, Type, ACCID, UPDATEDBY, strName, strAdd1, strAdd2, strCity, strCountry, strPhone);
            }
        }
        public bool AddDomains(string strUserID, string strStatus, string strDomain, string strPrice, string strRegDate, string strNextDue, int UPDATEDBY)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.AddDomains(strUserID, strStatus, strDomain, strPrice, strRegDate, strNextDue, UPDATEDBY);
            }
        }
        public bool UpdateDomains(string strUserID, string strID, string strStatus, string strDomain, string strPrice, string strRegDate, string strNextDue, int UPDATEDBY)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateDomains(strUserID,strID, strStatus, strDomain, strPrice, strRegDate, strNextDue, UPDATEDBY);
            }
        }
        public bool LoggedUser(Int32 intUserId, string strUserIP, bool blnIsLogged)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.LoggedUser(intUserId, strUserIP, blnIsLogged);

            }
        }

        public bool ActivateUser(string strUserId, string strActivate)
        {
            using (Modifier modifire = new Modifier())
            {
                return modifire.ActivateUser(strUserId, strActivate);
            }
        }
        public bool DeleteUser(string strUserId)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.DeleteUser(strUserId);
            }
        }
        public bool GenerateResetKey(string strUserId, string strResetKey)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.GenerateResetKey(strUserId, strResetKey);
            }
        }

        public bool UpdateUserPassword(string strNewPassword, string strUserid)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateUserPassword(strNewPassword, strUserid);
            }
        }

        public bool SubmitComments(Int32 intResourceId, Int32 intUserId, DateTime dtDate, string strDescr)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.SubmitComments(intResourceId, intUserId, dtDate, strDescr);
            }
        }

        public bool SubmitResource(Int32 intResourceId, Int32 intCatId, Int32 intSubCatId, Int32 intUserId, string strTitle, string strDescr, string strUrl, Int32 intCredits, bool blnUpdateView, string strMetaDesc, string strMetaKeys)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.SubmitResource(intResourceId, intCatId, intSubCatId, intUserId, strTitle, strDescr, strUrl, intCredits, blnUpdateView, strMetaDesc, strMetaKeys);
            }
        }

        public bool InsertImages(string strCatName, Int32 intCatId, string strImgCaption, string strImgDescr, string strImg, Double dblCostINR, Double dblCostUSD, Boolean blnStatus)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.InsertImages(strCatName, intCatId, strImgCaption, strImgDescr, strImg, dblCostINR, dblCostUSD, blnStatus);
            }
        }

        public bool DeleteImageById(Int32 intImgId)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.DeleteImageById(intImgId);
            }
        }

        public bool UpdateImageById(String strCategoryName, Int32 intCategoryId, string strImageCaption, string strImageDescr, Double dblCostINR, Double dblCostUSD, Int32 intImageOrder, Int32 intImageId)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateImageById(strCategoryName, intCategoryId, strImageCaption, strImageDescr, dblCostINR, dblCostUSD, intImageOrder, intImageId);
            }
        }

        public bool DeleteImageDetailById(Int32 intId)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.DeleteImageDetailById(intId);
            }
        }

        public bool UpdateImageDetailById(String strSize, string strCraft, Double dblCostINR, Double dblCostUSD, string strOther, Int32 intId)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateImageDetailById(strSize, strCraft, dblCostINR, dblCostUSD, strOther, intId);
            }
        }

        public bool InsertImageDetail(Int32 intImageId, String strSize, string strCraft, Double dblCostINR, Double dblCostUSD, string strOther)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.InsertImageDetail(intImageId, strSize, strCraft, dblCostINR, dblCostUSD, strOther);
            }
        }

        public bool DeleteContacts(Int32 intID)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.DeleteContacts(intID);
            }
        }
        public bool DeleteErrorLog()
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.DeleteErrorLog();
            }
        }

        public bool UpdateUserProfile(Int32 intUserId, string strDisplayName, string strFName, string strLName, string strState,
           string strCountry, string strImage, string strProfile, string strSignature, bool blnAccepted, bool blnNewsLetters)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateUserProfile(intUserId, strDisplayName, strFName, strLName, strState, strCountry, strImage, strProfile, strSignature, blnAccepted, blnNewsLetters);
            }
        }


        public bool UpdateResource(Int32 intResourceId, Int32 intCatId, Int32 intSubCatId, Int32 intUserId, Int32 intEditedBy, string strTitle, string strDescr, string strUrl, Int32 intCredits, string strMetaDesc, string strMetaKeys)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateResource(intResourceId, intCatId, intSubCatId, intUserId, intEditedBy, strTitle, strDescr, strUrl, intCredits, strMetaDesc, strMetaKeys);
            }
        }

        public bool SendMessage(Int32 intRecepientID, Int32 intSenderID, string strSubject, string strMessage)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.SendMessage(intRecepientID, intSenderID, strSubject, strMessage);
            }
        }

        public bool GenerateTicket(string strTicketID, Int32 intUserID, string strDepartment, string strPriority, string strPanelDetail, string strACCID, string strSubject, string strQuery, string strStatus, Int32 intUpdatedBy)
        {

            using (Modifier modifier = new Modifier())
            {
                return modifier.GenerateTicket(strTicketID, intUserID, strDepartment, strPriority, strPanelDetail, strACCID, strSubject, strQuery, strStatus, intUpdatedBy);
            }
        }
        public bool UpdateTicket(string strTicketID, string strQuery, string strStatus, Int32 intUpdatedBy)
        {
            using (Modifier modifier = new Modifier())
            {
                return modifier.UpdateTicket(strTicketID, strQuery, strStatus, intUpdatedBy);
            }
        }
        #endregion

    }
}
