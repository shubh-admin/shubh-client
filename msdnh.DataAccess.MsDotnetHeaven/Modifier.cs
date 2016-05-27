using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using msdnh.Common.Data.MsDotnetHeaven;
//using msdnm.Common;
using msdnh.DataAccess.Base;


namespace msdnh.DataAccess.MsDotnetHeaven
{
    public class Modifier : ModifierBase, IDisposable
    {
        public Modifier()
        {
            //
            // TODO: Add constructor logic here
            //
        }
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
            //Pass current date if date is null/blank
            dtDate = dtDate == null ? DateTime.Now : dtDate;

            SqlCommand = "spLogErrors";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@Date", dtDate);
            Parameters.AddWithValue("@Url", strUrl);
            Parameters.AddWithValue("@Err", strError);
            Parameters.AddWithValue("@Descr", strDesc);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// Logged Users Presence on the system
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strUserIP"></param>
        /// <param name="blnIsLogged"></param>
        /// <returns></returns>
        public bool LoggedUser(Int32 intUserId, string strUserIP, bool blnIsLogged)
        {
            SqlCommand = "tblUserLog_spUserLog";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@UserID", intUserId);
            Parameters.AddWithValue("@UserIP", strUserIP);
            Parameters.AddWithValue("@IsLogged", blnIsLogged);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="strDisplayName"></param>
        /// <param name="strFName"></param>
        /// <param name="strLName"></param>
        /// <param name="strState"></param>
        /// <param name="strCountry"></param>
        /// <param name="strImage"></param>
        /// <param name="strProfile"></param>
        /// <param name="strSignature"></param>
        /// <param name="blnAccepted"></param>
        /// <param name="blnNewsLetters"></param>
        /// <returns></returns>
        public bool UpdateUserProfile(Int32 intUserId, string strDisplayName, string strFName, string strLName, string strState,
            string strCountry, string strImage, string strProfile, string strSignature, bool blnAccepted, bool blnNewsLetters)
        {
            SqlCommand = "spUpdateUserProfile";
            SqlCommandType = CommandType.StoredProcedure;


            Parameters.AddWithValue("@UserID", intUserId);
            Parameters.AddWithValue("@DisplayName", strDisplayName);
            Parameters.AddWithValue("@FName", strFName);
            Parameters.AddWithValue("@LName", strLName);
            Parameters.AddWithValue("@State", strState);
            Parameters.AddWithValue("@Country", strCountry);
            Parameters.AddWithValue("@Image", strImage);
            Parameters.AddWithValue("@Profile", strProfile);
            Parameters.AddWithValue("@Signature", strSignature);
            Parameters.AddWithValue("@Accepted", blnAccepted);
            Parameters.AddWithValue("@NewsLetters", blnNewsLetters);



            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCatName"></param>
        /// <param name="intCatId"></param>
        /// <param name="strImgCaption"></param>
        /// <param name="strImgDescr"></param>
        /// <param name="strImg"></param>
        /// <param name="dblCostINR"></param>
        /// <param name="dblCostUSD"></param>
        /// <param name="blnStatus"></param>
        /// <returns></returns>


        public bool InsertImages(string strCatName, Int32 intCatId, string strImgCaption, string strImgDescr, string strImg, Double dblCostINR, Double dblCostUSD, Boolean blnStatus)
        {

            SqlCommand = "spInsertImages";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@CatName", strCatName);
            Parameters.AddWithValue("@CatId", intCatId);
            Parameters.AddWithValue("@ImgCaption", strImgCaption);
            Parameters.AddWithValue("@ImgDescr", strImgDescr);
            Parameters.AddWithValue("@Img", strImg);
            Parameters.AddWithValue("@CostINR", dblCostINR);
            Parameters.AddWithValue("@CostUSD", dblCostUSD);
            Parameters.AddWithValue("@Status", Convert.ToInt32(blnStatus));

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }



        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="FName">First Name of User</param>
        /// <param name="LName">Last Name of User</param>
        /// <param name="Email">Valid Email id of User</param>
        /// <param name="Pwd">Encryped Password</param>
        /// <returns>True/False quoting user successfully registered onr no.</returns>
        public bool RegisterUser(string FName, string LName, string Email, string Pwd)
        {
            SqlCommand = "spRegister";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@FName", FName);
            Parameters.AddWithValue("@LName", LName);
            Parameters.AddWithValue("@Email", Email);
            Parameters.AddWithValue("@Pwd", Pwd);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// Add new user from Admin Panel
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Email"></param>
        /// <param name="Type"></param>
        /// <param name="ACCID"></param>
        /// <param name="UPDATEDBY"></param>
        /// <returns></returns>
        public bool AddUser(string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY)
        {
            SqlCommand = "tblLogin_spAddUser";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserName", UserName);
            Parameters.AddWithValue("@Password", Password);
            Parameters.AddWithValue("@Email", Email);
            Parameters.AddWithValue("@Type", Type);
            if (ACCID != "0000000000")
                Parameters.AddWithValue("@ACCID", ACCID);

            Parameters.AddWithValue("@UPDATEBY", UPDATEDBY);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// Update the USer record
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Email"></param>
        /// <param name="Type"></param>
        /// <param name="ACCID"></param>
        /// <param name="UPDATEDBY"></param>
        /// <returns></returns>
        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY)
        {
            SqlCommand = "tblLogin_spUpdateUser";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@ID", strID);
            Parameters.AddWithValue("@UserName", UserName);
            Parameters.AddWithValue("@Password", Password);
            Parameters.AddWithValue("@Email", Email);
            Parameters.AddWithValue("@Type", Type);
            Parameters.AddWithValue("@ACCID", ACCID);
            Parameters.AddWithValue("@UPDATEBY", UPDATEDBY);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Email"></param>
        /// <param name="Type"></param>
        /// <param name="ACCID"></param>
        /// <param name="UPDATEDBY"></param>
        /// <param name="strName"></param>
        /// <param name="strAdd1"></param>
        /// <param name="strAdd2"></param>
        /// <param name="strCity"></param>
        /// <param name="strCountry"></param>
        /// <param name="strPhone"></param>
        /// <returns></returns>

        public bool UpdateUser(string strID, string UserName, string Password, string Email, string Type, string ACCID, int UPDATEDBY, string strName, string strAdd1, string strAdd2, string strCity, string strCountry, string strPhone)
        {
            SqlCommand = "tblLogin_spUpdateUser";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@ID", strID);
            Parameters.AddWithValue("@UserName", UserName);
            if (!string.IsNullOrEmpty(Password))
            {
                Parameters.AddWithValue("@Password", Password);
            }
            Parameters.AddWithValue("@Email", Email);
            Parameters.AddWithValue("@Type", Type);
            Parameters.AddWithValue("@ACCID", ACCID);
            Parameters.AddWithValue("@UPDATEBY", UPDATEDBY);
            Parameters.AddWithValue("@Name", strName);
            Parameters.AddWithValue("@Address1", strAdd1);
            Parameters.AddWithValue("@Address2", strAdd2);
            Parameters.AddWithValue("@City", strCity);
            Parameters.AddWithValue("@Country", strCountry);
            Parameters.AddWithValue("@Phone", strPhone);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserID"></param>
        /// <param name="strStatus"></param>
        /// <param name="strDomain"></param>
        /// <param name="strPrice"></param>
        /// <param name="strRegDate"></param>
        /// <param name="strNextDue"></param>
        /// <param name="UPDATEDBY"></param>
        /// <returns></returns>
        public bool AddDomains(string strUserID, string strStatus, string strDomain, string strPrice, string strRegDate, string strNextDue, int UPDATEDBY)
        {
            SqlCommand = "tblDomains_spAddDomains";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserID", strUserID);
            Parameters.AddWithValue("@Status", strStatus);

            Parameters.AddWithValue("@Domain", strDomain);
            Parameters.AddWithValue("@Price", strPrice);
            Parameters.AddWithValue("@RegDate", strRegDate);
            Parameters.AddWithValue("@UPDATEBY", UPDATEDBY);
            Parameters.AddWithValue("@NextDue", strNextDue);


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserID"></param>
        /// <param name="strID"></param>
        /// <param name="strStatus"></param>
        /// <param name="strDomain"></param>
        /// <param name="strPrice"></param>
        /// <param name="strRegDate"></param>
        /// <param name="strNextDue"></param>
        /// <param name="UPDATEDBY"></param>
        /// <returns></returns>
        public bool UpdateDomains(string strUserID, string strID, string strStatus, string strDomain, string strPrice, string strRegDate, string strNextDue, int UPDATEDBY)
        {
            SqlCommand = "tblDomains_spUpdateDomains";
            SqlCommandType = CommandType.StoredProcedure;
            Parameters.AddWithValue("@UserID", strUserID);
            Parameters.AddWithValue("@ID", strID);
            Parameters.AddWithValue("@Status", strStatus);

            Parameters.AddWithValue("@Domain", strDomain);
            Parameters.AddWithValue("@Price", strPrice);
            Parameters.AddWithValue("@RegDate", strRegDate);
            Parameters.AddWithValue("@UPDATEBY", UPDATEDBY);
            Parameters.AddWithValue("@NextDue", strNextDue);


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="strActivate"></param>
        /// <returns></returns>
        public bool ActivateUser(string strUserId, string strActivate)
        {
            SqlCommand = "Update [tblLogin] SET Status = @Activate WHERE ID = @UserId";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserId", strUserId);
            Parameters.AddWithValue("@Activate", strActivate);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// Remove records permanently
        /// </summary>
        /// <param name="strUserId"></param>
        /// <returns></returns>
        public bool DeleteUser(string strUserId)
        {
            SqlCommand = "DELETE [tblLogin] WHERE ID = @UserId";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserId", strUserId);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool DeleteImageById(Int32 intImgId)
        {
            SqlCommand = "spDeleteImageById";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ImgId", intImgId);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        public bool DeleteImageDetailById(Int32 intId)
        {
            SqlCommand = "spDeleteImageDetailById";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@Id", intId);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        public bool UpdateImageById(String strCategoryName, Int32 intCategoryId, string strImageCaption, string strImageDescr, Double dblCostINR, Double dblCostUSD, Int32 intImageOrder, Int32 intImageId)
        {
            SqlCommand = "spUpdateImageById";
            SqlCommandType = CommandType.StoredProcedure;


            Parameters.AddWithValue("@CategoryName", strCategoryName);
            Parameters.AddWithValue("@CategoryId", intCategoryId);
            Parameters.AddWithValue("@ImageCaption", strImageCaption);
            Parameters.AddWithValue("@ImageDescr", strImageDescr);
            Parameters.AddWithValue("@CostINR", dblCostINR);
            Parameters.AddWithValue("@CostUSD", dblCostUSD);
            Parameters.AddWithValue("@ImageOrder", intImageOrder);
            Parameters.AddWithValue("@ImageId", intImageId);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool UpdateImageDetailById(String strSize, string strCraft, Double dblCostINR, Double dblCostUSD, string strOther, Int32 intId)
        {
            SqlCommand = "spUpdateImageDetailById";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@Size", strSize);
            Parameters.AddWithValue("@Craft", strCraft);
            Parameters.AddWithValue("@PriceINR", dblCostINR);
            Parameters.AddWithValue("@PriceUSD", dblCostUSD);
            Parameters.AddWithValue("@Other", strOther);
            Parameters.AddWithValue("@Id", intId);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        public bool InsertImageDetail(Int32 intImageId, String strSize, string strCraft, Double dblCostINR, Double dblCostUSD, string strOther)
        {
            SqlCommand = "spInsertImageDetail";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ImageId", intImageId);
            Parameters.AddWithValue("@Size", strSize);
            Parameters.AddWithValue("@Craft", strCraft);
            Parameters.AddWithValue("@PriceINR", dblCostINR);
            Parameters.AddWithValue("@PriceUSD", dblCostUSD);
            Parameters.AddWithValue("@Other", strOther);


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool GenerateResetKey(string strUserId, string strResetKey)
        {

            SqlCommand = "Update [USERS] SET reset_key = @ResetKey WHERE USERID = @UserId";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@UserId", strUserId);
            Parameters.AddWithValue("@ResetKey", strResetKey);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        public bool UpdateUserPassword(string strNewPassword, string strUserid)
        {
            SqlCommand = "Update [tblLogin] SET Password = @NewPassword WHERE ID = @UserId";
            SqlCommandType = CommandType.Text;
            Parameters.AddWithValue("@NewPassword", strNewPassword);
            Parameters.AddWithValue("@UserId", strUserid);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTicketID"></param>
        /// <param name="intUserID"></param>
        /// <param name="strDepartment"></param>
        /// <param name="strPriority"></param>
        /// <param name="strPanelDetail"></param>
        /// <param name="strACCID"></param>
        /// <param name="strSubject"></param>
        /// <param name="strQuery"></param>
        /// <param name="strStatus"></param>
        /// <param name="intUpdatedBy"></param>
        /// <returns></returns>
        public bool GenerateTicket(string strTicketID, Int32 intUserID, string strDepartment, string strPriority, string strPanelDetail, string strACCID, string strSubject, string strQuery, string strStatus, Int32 intUpdatedBy)
        {
            SqlCommand = "tblSupport_spCreateTicket";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@TicketID", strTicketID);
            Parameters.AddWithValue("@UserID", intUserID);
            Parameters.AddWithValue("@Department", strDepartment);
            Parameters.AddWithValue("@Priority", strPriority);
            Parameters.AddWithValue("@PanelDetail", strPanelDetail);
            Parameters.AddWithValue("@ACCID", strACCID);
            Parameters.AddWithValue("@Subject", strSubject);
            Parameters.AddWithValue("@Query", strQuery);
            Parameters.AddWithValue("@Status", strStatus);
            Parameters.AddWithValue("@UpdatedBy", intUpdatedBy);


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTicketID"></param>
        /// <param name="strQuery"></param>
        /// <param name="strStatus"></param>
        /// <param name="intUpdatedBy"></param>
        /// <returns></returns>
        public bool UpdateTicket(string strTicketID, string strQuery, string strStatus, Int32 intUpdatedBy)
        {
            SqlCommand = "tblSupport_spUpdateTicket";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@TicketID", strTicketID);
            Parameters.AddWithValue("@Query", strQuery);
            Parameters.AddWithValue("@Status", strStatus);
            Parameters.AddWithValue("@UpdatedBy", intUpdatedBy);


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
        public bool SubmitComments(Int32 intResourceId, Int32 intUserId, DateTime dtDate, string strDescr)
        {
            //Pass current date if date is null/blank
            dtDate = dtDate == null ? DateTime.Now : dtDate;

            SqlCommand = "spSubmitComments";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ResourceId", intResourceId);
            Parameters.AddWithValue("@UserId", intUserId);
            Parameters.AddWithValue("@Date", dtDate);
            Parameters.AddWithValue("@Descr", strDescr);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }


        public bool SubmitResource(Int32 intResourceId, Int32 intCatId, Int32 intSubCatId, Int32 intUserId, string strTitle, string strDescr, string strUrl, Int32 intCredits, bool blnUpdateView, string strMetaDesc, string strMetaKeys)
        {

            SqlCommand = "spSubmitResource";
            SqlCommandType = CommandType.StoredProcedure;


            Parameters.AddWithValue("@ResTypeId", intResourceId);
            Parameters.AddWithValue("@CatId", intCatId);
            Parameters.AddWithValue("@SubCatId", intSubCatId);
            Parameters.AddWithValue("@UserId", intUserId);
            Parameters.AddWithValue("@title", strTitle);
            Parameters.AddWithValue("@Desc", strDescr);
            Parameters.AddWithValue("@url", strUrl);
            Parameters.AddWithValue("@credits", intCredits);
            Parameters.AddWithValue("@updateView", blnUpdateView);
            Parameters.AddWithValue("@metaDesc", strMetaDesc);
            Parameters.AddWithValue("@metaKey", strMetaKeys);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool UpdateResource(Int32 intResourceId, Int32 intCatId, Int32 intSubCatId, Int32 intUserId, Int32 intEditedBy, string strTitle, string strDescr, string strUrl, Int32 intCredits, string strMetaDesc, string strMetaKeys)
        {

            SqlCommand = "spUpdateResource";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ResourceId", intResourceId);
            Parameters.AddWithValue("@ResTypeId", 1);
            Parameters.AddWithValue("@CatId", intCatId);
            Parameters.AddWithValue("@SubCatId", intSubCatId);
            Parameters.AddWithValue("@UserId", intUserId);
            Parameters.AddWithValue("@EditedBy", intEditedBy);
            Parameters.AddWithValue("@title", strTitle);
            Parameters.AddWithValue("@Desc", strDescr);
            Parameters.AddWithValue("@url", strUrl);
            Parameters.AddWithValue("@credits", intCredits);
            Parameters.AddWithValue("@metaDesc", strMetaDesc);
            Parameters.AddWithValue("@metaKey", strMetaKeys);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool SendMessage(Int32 intRecepientID, Int32 intSenderID, string strSubject, string strMessage)
        {

            SqlCommand = "spSendMessage";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@RecepientID", intRecepientID);
            Parameters.AddWithValue("@SenderID", intSenderID);
            Parameters.AddWithValue("@Subject", strSubject);
            Parameters.AddWithValue("@Message", strMessage);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool DeleteContacts(Int32 intID)
        {

            SqlCommand = "spDeleteContacts";
            SqlCommandType = CommandType.StoredProcedure;

            Parameters.AddWithValue("@ID", intID);

            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }

        public bool DeleteErrorLog()
        {

            SqlCommand = "spDeleteErrorLog";
            SqlCommandType = CommandType.StoredProcedure;


            bool blnRes = false;
            int intRes = ExecuteNonQuery();
            if (intRes > 0)
                blnRes = true;

            return blnRes;
        }
















        /*
       public string DecrypPassword(string strPwd)
       {
           string strDecrypPwd = string.Empty;
           //Logics to decrypt the password


           return strDecrypPwd;
       }

       public string EncryptPassword(string strPwd)
       {
           string strEncryptPwd = string.Empty;
           //Logics to Encrypt the password


           return strEncryptPwd;
       }

       
   [Obsolete("Supply 0 as EducationId, when you dont know the new Id",false)] 
   public bool InsertEdu(String strEdu, Int32 intId)
   {
       SqlCommand = "InsertEducation(@Id,@Education)";
       //SqlCommand = "Insert Into Education Values(@Id,@Education)";
       SqlCommandType = CommandType.StoredProcedure;
       Parameters.Add("@pkid", intId);
       Parameters.Add("@eduName", strEdu);
            
       bool blRes=false ;
       int intRes = ExecuteNonQuery();
       if (intRes > 0)
           blRes = true;

       return blRes; 
   }
         
   public UserData InsertEdu(Int32 intPkid, String strUserid, String strPass)
   {
       UserData dsUserData = new UserData();
            
       SqlCommand = "InsertUser";
       SqlCommandType = CommandType.StoredProcedure;
            
       Parameters.Add("@pkid", intPkid);
       Parameters.Add("@userid", strUserid);
       Parameters.Add("@pass", strUserid);
       Parameters.Add("@last_name", strPass);
       Parameters.Add("@first_name", null);
       Parameters.Add("@email_id", null);
       Parameters.Add("@education_id", null);
       Parameters.Add("@MVP", null);
       Parameters.Add("@MCP", null);
       Parameters.Add("@MCTS", null);
       Parameters.Add("@others", null);
       Parameters.Add("@country_id", null);
       Parameters.Add("@state_id", null);
       Parameters.Add("@city_id", null);
       Parameters.Add("@about_you", null);
       Parameters.Add("@signature", null);
       Parameters.Add("@news_letter", null);
       Parameters.Add("@accountactive", null);
       Parameters.Add("@dtjoin", null);
       Parameters.Add("@address1", null);
       Parameters.Add("@address2", null);

            

       return dsUserData;

   }
   public bool InsertEdu(String strEdu)
   {
       Boolean blnRes=false;
       Int32 intEduId = new Fetcher().GetNextEducationid();
       SqlCommand = "InsertEducation";
       SqlCommandType = CommandType.StoredProcedure;
       Parameters.Add("@pkid", intEduId);
       Parameters.Add("@eduName", strEdu);

       int intRes = ExecuteNonQuery();
       if (intRes > 0)
           blnRes = true;

       return blnRes;
   }
   * */
    }

}
