using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.Configuration.Provider;
using System.Security.Authentication;
using System.Collections.Specialized;
using System.Text.RegularExpressions;


namespace msdnh.DataAccess.Base
{
    public class SecurityBase //: MembershipProvider
    {
        /*
        // Instance Variables
        string _appName, _passwordStrengthRegularExpression;
        int _minimumRequiredPasswordLength, _minRequiredNonAlphanumericCharacters;
        int _maxInvalidPasswordAttempts, _passwordAttemptWindow;
        bool _enablePasswordReset, _enablePasswordRetrieval, _requiresQuestionAndAnswer;
        bool _requiresUniqueEmail, _useSalt, _hashHex, _msCompliant;
        string _hashCase, _hashRemoveChars;
        MembershipPasswordFormat _passwordFormat;

        // Contants
        private const int PASSWORDSIZE = 14;

        private static string HashType()
        {
            if (String.IsNullOrEmpty(System.Web.Security.Membership.HashAlgorithmType))
                return "MD5"; // Default Hash Algorithm Type
            else
                return System.Web.Security.Membership.HashAlgorithmType;
        }

        public static string GenerateSalt()
        {
            byte[] buf = new byte[16];
            RNGCryptoServiceProvider rngCryptoSP = new RNGCryptoServiceProvider();
            rngCryptoSP.GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static byte[] Hash(byte[] clearBytes, string hashType)
        {
            // MD5, SHA1, SHA256, SHA384, SHA512
            Byte[] hash = HashAlgorithm.Create(hashType).ComputeHash(clearBytes);
            return hash;
        }
        public static string Hash(string clearString, string hashType, string salt, bool useSalt, bool hashHex, string hashCase, bool standardComp)
        {
            byte[] buffer;
            if (useSalt)
            {
                buffer = GeneratePasswordBuffer(salt, clearString, standardComp);
            }
            else
            {
                byte[] unencodedBytes = Encoding.UTF8.GetBytes(clearString); // UTF8 used to maintain compatibility
                buffer = new byte[unencodedBytes.Length];
                System.Buffer.BlockCopy(unencodedBytes, 0, buffer, 0, unencodedBytes.Length);
            }

            byte[] hashedBytes = Hash(buffer, hashType); //Hash

            string hashedString;

            if (hashHex)
            {
                hashedString = CleanUtils.toHexString(hashedBytes);
            }
            else
            {
                hashedString = Convert.ToBase64String(hashedBytes);
            }

            //Adjust the case of the hash output
            switch (hashCase.ToLower())
            {
                case "upper":
                    hashedString = hashedString.ToUpper();
                    break;
                case "lower":
                    hashedString = hashedString.ToLower();
                    break;
            }

            return hashedString;

        }
        public static byte[] GeneratePasswordBuffer(string strSalt, string strPwd, bool blnStandardComp)
        {
            byte[] unencodedBytes = Encoding.Unicode.GetBytes(strPwd);
            byte[] saltBytes = Convert.FromBase64String(strSalt);
            byte[] buffer = new byte[unencodedBytes.Length + saltBytes.Length];

            if (blnStandardComp) // Compliant with ASP.NET Membership method of hash/salt
            {
                Buffer.BlockCopy(saltBytes, 0, buffer, 0, saltBytes.Length);
                Buffer.BlockCopy(unencodedBytes, 0, buffer, saltBytes.Length, unencodedBytes.Length);
            }
            else
            {
                System.Buffer.BlockCopy(unencodedBytes, 0, buffer, 0, unencodedBytes.Length);
                System.Buffer.BlockCopy(saltBytes, 0, buffer, unencodedBytes.Length - 1, saltBytes.Length);
            }
            return buffer;
        }

        public static string DecodeString(string pass, int passwordFormat)
        {
            switch ((MembershipPasswordFormat)Enum.ToObject(typeof(MembershipPasswordFormat), passwordFormat))
            {
                case MembershipPasswordFormat.Clear: // MembershipPasswordFormat.Clear:
                    return pass;
                case MembershipPasswordFormat.Hashed: // MembershipPasswordFormat.Hashed:
                    //ExceptionReporter.Throw("MEMBERSHIP", "DECODEHASH");
                    break;
                case MembershipPasswordFormat.Encrypted:
                    byte[] bIn = Convert.FromBase64String(pass);
                    byte[] bRet = (new SecurityBase()).DecryptPassword(bIn);
                    if (bRet == null)
                        return null;
                    return Encoding.Unicode.GetString(bRet, 16, bRet.Length - 16);
                default:
                    //ExceptionReporter.Throw("MEMBERSHIP", "DECODEHASH");
                    break;
            }

            return String.Empty; // Removes "Not all paths return a value" warning.
        }
        private static string Encrypt(string clearString, string saltString, bool standardComp)
        {
            byte[] buffer = GeneratePasswordBuffer(saltString, clearString, standardComp);
            return Convert.ToBase64String((new SecurityBase()).EncryptPassword(buffer));

        }
        internal static string EncodeString(string clearString, int encFormat, string salt, bool useSalt, bool hashHex, string hashCase, bool msCompliant)
        {
            string encodedPass = string.Empty;

            MembershipPasswordFormat passwordFormat = (MembershipPasswordFormat)Enum.ToObject(typeof(MembershipPasswordFormat), encFormat);

            // Multiple Checks to ensure UseSalt is valid.
            #region UseSalt Checks

            if (String.IsNullOrEmpty(clearString)) // Check to ensure string is not null or empty.
                return String.Empty;

            if (useSalt && String.IsNullOrEmpty(salt)) // If Salt value is null disable Salt procedure
            {
                useSalt = false;
            }

            if (useSalt && passwordFormat == MembershipPasswordFormat.Encrypted)
            {
                useSalt = false; // Cannot use Salt with encryption
            }

            #endregion

            // Check Encoding format / method
            switch (passwordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    // plain text
                    encodedPass = clearString;
                    break;
                case MembershipPasswordFormat.Hashed:
                    encodedPass = Hash(clearString, HashType(), salt, useSalt, hashHex, hashCase, msCompliant);
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPass = Encrypt(clearString, salt, msCompliant);
                    break;
                default:
                    encodedPass = Hash(clearString, HashType(), salt, useSalt, hashHex, hashCase, msCompliant);
                    break;
            }

            return encodedPass;
        }
        #region Override Public Properties

        public override string ApplicationName
        {
            get
            {
                return _appName;
            }
            set
            {
                if (value != _appName)
                {
                    _appName = value;
                }
            }
        }

        public override bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _minimumRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _passwordStrengthRegularExpression; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _passwordFormat; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return _requiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
        }

        internal bool UseSalt
        {
            get { return _useSalt; }
        }

        internal bool HashHex
        {
            get { return _hashHex; }
        }

        internal bool MSCompliant
        {
            get { return _msCompliant; }
        }

        internal string HashCase
        {
            get { return _hashCase; }
        }

        internal string HashRemoveChars
        {
            get { return _hashRemoveChars; }
        }

        #endregion

        #region Overriden Public Methods

        /// <summary>
        /// Initialie Membership Provider
        /// </summary>
        /// <param name="name">Membership Provider Name</param>
        /// <param name="config">NameValueCollection of configuration items</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that the configuration section was properly passed
            if (config == null)
               // ExceptionReporter.ThrowArgument("ROLES", "CONFIGNOTFOUND");

            // Retrieve information for provider from web config
            // config ints

            // Minimum Required Password Length from Provider configuration
            _minimumRequiredPasswordLength = int.Parse(config["minRequiredPasswordLength"] ?? "6");

            // Minimum Required Non Alpha-numeric Characters from Provider configuration
            _minRequiredNonAlphanumericCharacters = int.Parse(config["minRequiredNonAlphanumericCharacters"] ?? "1");

            // Maximum number of allowed password attempts
            _maxInvalidPasswordAttempts = int.Parse(config["maxInvalidPasswordAttempts"] ?? "5");

            // Password Attempt Window when maximum attempts have been reached
            _passwordAttemptWindow = int.Parse(config["passwordAttemptWindow"] ?? "10");

            // Check whething Hashing methods should use Salt
            _useSalt = Transform.ToBool(config["useSalt"] ?? "false");

            // Check whether password hashing should output as Hex instead of Base64
            _hashHex = Transform.ToBool(config["hashHex"] ?? "false");

            // Check to see if password hex case should be altered
            _hashCase = Transform.ToString(config["hashCase"], "None");

            // Check to see if password should have characters removed
            _hashRemoveChars = Transform.ToString(config["hashRemoveChars"] ?? String.Empty);

            // Check to see if password/salt combination needs to asp.net standard membership compliant
            _msCompliant = Transform.ToBool(config["msCompliant"] ?? "false");

            // Application Name
            _appName = Transform.ToString(config["applicationName"], "MsDnH");

            _passwordStrengthRegularExpression = Transform.ToString(config["passwordStrengthRegularExpression"]);

            // Password reset enabled from Provider Configuration
            _enablePasswordReset = Transform.ToBool(config["enablePasswordReset"] ?? "true");
            _enablePasswordRetrieval = Transform.ToBool(config["enablePasswordRetrieval"] ?? "false");
            _requiresQuestionAndAnswer = Transform.ToBool(config["requiresQuestionAndAnswer"] ?? "true");

            _requiresUniqueEmail = Transform.ToBool(config["requiresUniqueEmail"] ?? "true");

            string strPasswordFormat = Transform.ToString(config["passwordFormat"], "Hashed");

            switch (strPasswordFormat)
            {
                case "Clear":
                    _passwordFormat = MembershipPasswordFormat.Clear;
                    break;
                case "Encrypted":
                    _passwordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Hashed":
                    _passwordFormat = MembershipPasswordFormat.Hashed;
                    break;
                default:
                   // ExceptionReporter.Throw("MEMBERSHIP", "BADPASSWORDFORMAT");
                    break;
            }

            base.Initialize(name, config);

        }


        /// <summary>
        /// Change Users password
        /// </summary>
        /// <param name="username">Username to change password for</param>
        /// <param name="oldpassword">Password</param>
        /// <param name="newPassword">New question</param>
        /// <returns> Boolean depending on whether the change was successful</returns>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            string newPasswordSalt = string.Empty;
            string newEncPassword = string.Empty;

            // Clean input

            // Check password meets requirements as set by Configuration settings
            if (!(this.IsPasswordCompliant(newPassword)))
                return false;

            UserPasswordInfo currentPasswordInfo = UserPasswordInfo.CreateInstanceFromDB(this.ApplicationName, username, false, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            // validate the correct user information was found...
            if (currentPasswordInfo == null) return false;

            // validate the correct user password was entered...
            if (!currentPasswordInfo.IsCorrectPassword(oldPassword))
                return false;

            // generate a salt if desired...
            if (UseSalt) newPasswordSalt = GenerateSalt();
            // encode new password
            newEncPassword = EncodeString(newPassword, (int)this.PasswordFormat, newPasswordSalt, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            // Call SQL Password to Change
            DB.ChangePassword(this.ApplicationName, username, newEncPassword, newPasswordSalt, (int)this.PasswordFormat, currentPasswordInfo.PasswordAnswer);

            // Return True
            return true;
        }


        /// <summary>
        /// Change Users password Question and Answer
        /// </summary>
        /// <param name="username">Username to change Q&A for</param>
        /// <param name="password">Password</param>
        /// <param name="newPasswordQuestion">New question</param>
        /// <param name="newPasswordAnswer">New answer</param>
        /// <returns> Boolean depending on whether the change was successful</returns>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {

            // Check arguments for null values
            if ((username == null) || (password == null) || (newPasswordQuestion == null) || (newPasswordAnswer == null))
                throw new ArgumentException("Username, Password, Password Question or Password Answer cannot be null");

            UserPasswordInfo currentPasswordInfo = UserPasswordInfo.CreateInstanceFromDB(this.ApplicationName, username, false, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);
            newPasswordAnswer = YafMembershipProvider.EncodeString(newPasswordAnswer, currentPasswordInfo.PasswordFormat, currentPasswordInfo.PasswordSalt, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            if (currentPasswordInfo != null && currentPasswordInfo.IsCorrectPassword(password))
            {
                try
                {
                    DB.ChangePasswordQuestionAndAnswer(this.ApplicationName, username, newPasswordQuestion, newPasswordAnswer);
                    return true;
                }
                catch
                {
                    // will return false...
                }

            }

            return false; // Invalid password return false
        }

        /// <summary>
        /// Create user and add to provider
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="email">Email Address</param>
        /// <param name="passwordQuestion">Password Question</param>
        /// <param name="passwordAnswer">Password Answer - used for password retrievals.</param>
        /// <param name="isApproved">Is the User approved?</param>
        /// <param name="providerUserKey">Provider User Key to identify the User</param>
        /// <param name="status">Out - MembershipCreateStatus object containing status of the Create User process</param>
        /// <returns> Boolean depending on whether the deletion was successful</returns>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            // ValidatePasswordEventArgs e = new ValidatePasswordEventArgs( username, password, true );
            // OnValidatingPassword( e );
            //
            //if ( e.Cancel )
            //{
            //	status = MembershipCreateStatus.InvalidPassword;
            //	return null;
            //}

            string salt = string.Empty, pass = string.Empty;

            // Check password meets requirements as set out in the web.config
            if (!(this.IsPasswordCompliant(password)))
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            // Check password Question and Answer requirements.
            if (this.RequiresQuestionAndAnswer)
            {
                if (String.IsNullOrEmpty(passwordQuestion))
                {
                    status = MembershipCreateStatus.InvalidQuestion;
                    return null;
                }
                if (String.IsNullOrEmpty(passwordAnswer))
                {
                    status = MembershipCreateStatus.InvalidAnswer;
                    return null;
                }
            }

            // Check provider User Key
            if (!(providerUserKey == null))
            {
                // IS not a duplicate key
                if (!(this.GetUser(providerUserKey, false) == null))
                {
                    status = MembershipCreateStatus.DuplicateProviderUserKey;
                    return null;
                }
            }

            // Check for unique email
            if (this.RequiresUniqueEmail)
            {
                if (!(String.IsNullOrEmpty(this.GetUserNameByEmail(email))))
                {
                    status = MembershipCreateStatus.DuplicateEmail; // Email exists
                    return null;
                }
            }

            // Check for unique user name
            if (!(this.GetUser(username, false) == null))
            {
                status = MembershipCreateStatus.DuplicateUserName; // Username exists
                return null;
            }

            if (UseSalt) salt = YafMembershipProvider.GenerateSalt();
            pass = YafMembershipProvider.EncodeString(password, (int)this.PasswordFormat, salt, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);
            // Encode Password Answer
            string encodedPasswordAnswer = YafMembershipProvider.EncodeString(passwordAnswer, (int)this.PasswordFormat, salt, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);
            // Process database user creation request
            DB.CreateUser(this.ApplicationName, username, pass, salt, (int)this.PasswordFormat, email, passwordQuestion, encodedPasswordAnswer, isApproved, providerUserKey);

            status = MembershipCreateStatus.Success;

            return this.GetUser(username, false);
        }

        /// <summary>
        /// Delete User and User's information from provider
        /// </summary>
        /// <param name="username">Username to delete</param>
        /// <param name="deleteAllRelatedData">Delete all related daata</param>
        /// <returns> Boolean depending on whether the deletion was successful</returns>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            // Check username argument is not null
            if (username == null)
                ExceptionReporter.ThrowArgumentNull("MEMBERSHIP", "USERNAMENULL");

            // Process database user deletion request
            try
            {
                DB.DeleteUser(this.ApplicationName, username, deleteAllRelatedData);
                return true;
            }
            catch
            {
                // will return false...  
            }

            return false;
        }

        /// <summary>
        /// Retrieves all users into a MembershupUserCollection where Email Matches
        /// </summary>
        /// <param name="emailToMatch">Email use as filter criteria</param>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="userIsOnline">How many records to the page</param>
        /// <param name="totalRecords">Out - Number of records held</param>
        /// <returns>MembershipUser Collection</returns>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            if (pageIndex < 0)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGEINDEX");
            if (pageSize < 1)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGESIZE");

            // Loop through all users
            foreach (DataRow dr in DB.FindUsersByEmail(this.ApplicationName, emailToMatch, pageIndex, pageSize).Rows)
            {
                // Add new user to collection
                users.Add(new MembershipUser(Utils.Transform.ToString(this.Name), Utils.Transform.ToString(dr["Username"]), Utils.Transform.ToString(dr["UserID"]), Utils.Transform.ToString(dr["Email"]), Utils.Transform.ToString(dr["PasswordQuestion"]), Utils.Transform.ToString(dr["Comment"]), Utils.Transform.ToBool(dr["IsApproved"]), Utils.Transform.ToBool(dr["IsLockedOut"]), Utils.Transform.ToDateTime(dr["Joined"]), Utils.Transform.ToDateTime(dr["LastLogin"]), Utils.Transform.ToDateTime(dr["LastActivity"]), Utils.Transform.ToDateTime(dr["LastPasswordChange"]), Utils.Transform.ToDateTime(dr["LastLockout"])));
            }
            totalRecords = users.Count;
            return users;
        }

        /// <summary>
        /// Retrieves all users into a MembershupUserCollection where Username matches
        /// </summary>
        /// <param name="usernameToMatch">Username use as filter criteria</param>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="userIsOnline">How many records to the page</param>
        /// <param name="totalRecords">Out - Number of records held</param>
        /// <returns>MembershipUser Collection</returns>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            if (pageIndex < 0)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGEINDEX");
            if (pageSize < 1)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGESIZE");

            // Loop through all users
            foreach (DataRow dr in DB.FindUsersByName(this.ApplicationName, usernameToMatch, pageIndex, pageSize).Rows)
            {
                // Add new user to collection
                users.Add(new MembershipUser(Utils.Transform.ToString(this.Name), Utils.Transform.ToString(dr["Username"]), Utils.Transform.ToString(dr["UserID"]), Utils.Transform.ToString(dr["Email"]), Utils.Transform.ToString(dr["PasswordQuestion"]), Utils.Transform.ToString(dr["Comment"]), Utils.Transform.ToBool(dr["IsApproved"]), Utils.Transform.ToBool(dr["IsLockedOut"]), Utils.Transform.ToDateTime(dr["Joined"]), Utils.Transform.ToDateTime(dr["LastLogin"]), Utils.Transform.ToDateTime(dr["LastActivity"]), Utils.Transform.ToDateTime(dr["LastPasswordChange"]), Utils.Transform.ToDateTime(dr["LastLockout"])));
            }
            totalRecords = users.Count;
            return users;
        }

        /// <summary>
        /// Retrieves all users into a MembershupUserCollection
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="userIsOnline">How many records to the page</param>
        /// <param name="totalRecords">Out - Number of records held</param>
        /// <returns>MembershipUser Collection</returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            if (pageIndex < 0)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGEINDEX");
            if (pageSize < 1)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "BADPAGESIZE");

            // Loop through all users
            foreach (DataRow dr in DB.GetAllUsers(this.ApplicationName, pageIndex, pageSize).Rows)
            {
                // Add new user to collection
                users.Add(new MembershipUser(Utils.Transform.ToString(this.Name), Utils.Transform.ToString(dr["Username"]), Utils.Transform.ToString(dr["UserID"]), Utils.Transform.ToString(dr["Email"]), Utils.Transform.ToString(dr["PasswordQuestion"]), Utils.Transform.ToString(dr["Comment"]), Utils.Transform.ToBool(dr["IsApproved"]), Utils.Transform.ToBool(dr["IsLockedOut"]), Utils.Transform.ToDateTime(dr["Joined"]), Utils.Transform.ToDateTime(dr["LastLogin"]), Utils.Transform.ToDateTime(dr["LastActivity"]), Utils.Transform.ToDateTime(dr["LastPasswordChange"]), Utils.Transform.ToDateTime(dr["LastLockout"])));
            }
            totalRecords = users.Count;
            return users;
        }

        /// <summary>
        /// Retrieves the number of users currently online for this application
        /// </summary>
        /// <returns>Number of users online</returns>
        public override int GetNumberOfUsersOnline()
        {
            return DB.GetNumberOfUsersOnline(this.ApplicationName, System.Web.Security.Membership.UserIsOnlineTimeWindow);
        }


        /// <summary>
        /// Retrieves the Users password (if EnablePasswordRetrieval is true)
        /// </summary>
        /// <param name="username">Username to retrieve password for</param>
        /// <param name="answer">Answer to the Users Membership Question</param>
        /// <param name="newPasswordQuestion">New question</param>
        /// <param name="newPasswordAnswer">New answer</param>
        /// <returns> Password unencrypted</returns>
        public override string GetPassword(string username, string answer)
        {
            if (!this.EnablePasswordRetrieval)
            {
                ExceptionReporter.ThrowNotSupported("MEMBERSHIP", "PASSWORDRETRIEVALNOTSUPPORTED");
            }

            // Check for null arguments
            if ((username == null) || (answer == null))
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "USERNAMEPASSWORDNULL");

            UserPasswordInfo currentPasswordInfo = UserPasswordInfo.CreateInstanceFromDB(this.ApplicationName, username, false, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            if (currentPasswordInfo != null && currentPasswordInfo.IsCorrectAnswer(answer))
            {
                return YafMembershipProvider.DecodeString(currentPasswordInfo.Password, currentPasswordInfo.PasswordFormat);
            }

            return null;
        }

        /// <summary>
        /// Retrieves a MembershipUser object from the criteria given
        /// </summary>
        /// <param name="username">Username to be foundr</param>
        /// <param name="userIsOnline">Is the User currently online</param>
        /// <returns>MembershipUser object</returns>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (username == null)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "USERNAMENULL");

            // if it's empty don't bother calling the DB.
            if (String.IsNullOrEmpty(username))
            {
                return null;
            }

            DataRow dr = DB.GetUser(this.ApplicationName, null, username, userIsOnline);

            if (dr != null)
            {
                return new MembershipUser(Utils.Transform.ToString(this.Name), Utils.Transform.ToString(dr["Username"]), Utils.Transform.ToString(dr["UserID"]), Utils.Transform.ToString(dr["Email"]), Utils.Transform.ToString(dr["PasswordQuestion"]), Utils.Transform.ToString(dr["Comment"]), Utils.Transform.ToBool(dr["IsApproved"]), Utils.Transform.ToBool(dr["IsLockedOut"]), Utils.Transform.ToDateTime(dr["Joined"]), Utils.Transform.ToDateTime(dr["LastLogin"]), Utils.Transform.ToDateTime(dr["LastActivity"]), Utils.Transform.ToDateTime(dr["LastPasswordChange"]), Utils.Transform.ToDateTime(dr["LastLockout"]));
            }

            return null;
        }

        /// <summary>
        /// Retrieves a MembershipUser object from the criteria given
        /// </summary>
        /// <param name="providerUserKey">User to be found based on UserKey</param>
        /// <param name="userIsOnline">Is the User currently online</param>
        /// <returns>MembershipUser object</returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            if (providerUserKey == null)
            {
                ExceptionReporter.ThrowArgumentNull("MEMBERSHIP", "USERKEYNULL");
            }

            DataRow dr = DB.GetUser(this.ApplicationName, providerUserKey, null, userIsOnline);
            if (dr != null)
                return new MembershipUser(Utils.Transform.ToString(this.Name), Utils.Transform.ToString(dr["Username"]), Utils.Transform.ToString(dr["UserID"]), Utils.Transform.ToString(dr["Email"]), Utils.Transform.ToString(dr["PasswordQuestion"]), Utils.Transform.ToString(dr["Comment"]), Utils.Transform.ToBool(dr["IsApproved"]), Utils.Transform.ToBool(dr["IsLockedOut"]), Utils.Transform.ToDateTime(dr["Joined"]), Utils.Transform.ToDateTime(dr["LastLogin"]), Utils.Transform.ToDateTime(dr["LastActivity"]), Utils.Transform.ToDateTime(dr["LastPasswordChange"]), Utils.Transform.ToDateTime(dr["LastLockout"]));
            else
                return null;
        }


        /// <summary>
        /// Retrieves a MembershipUser object from the criteria given
        /// </summary>
        /// <param name="providerUserKey">User to be found based on UserKey</param>
        /// <param name="userIsOnline">Is the User currently online</param>
        /// <returns>Username as string</returns>
        public override string GetUserNameByEmail(string email)
        {
            if (email == null)
                ExceptionReporter.ThrowArgumentNull("MEMBERSHIP", "EMAILNULL");

            DataTable Users = DB.GetUserNameByEmail(this.ApplicationName, email);
            if (this.RequiresUniqueEmail && Users.Rows.Count > 1)
                ExceptionReporter.ThrowProvider("MEMBERSHIP", "TOOMANYUSERNAMERETURNS");

            if (Users.Rows.Count == 0)
                return null;
            else
                return Users.Rows[0]["Username"].ToString();
        }

        /// <summary>
        /// Reset a users password - *
        /// </summary>
        /// <param name="username">User to be found based by Name</param>
        /// <param name="answer">Verifcation that it is them</param>
        /// <returns>Username as string</returns>
        public override string ResetPassword(string username, string answer)
        {
            string newPassword = string.Empty, newPasswordEnc = string.Empty, newPasswordSalt = string.Empty, newPasswordAnswer = string.Empty;

            /// Check Password reset is enabled
            if (!(this.EnablePasswordReset))
                ExceptionReporter.ThrowNotSupported("MEMBERSHIP", "RESETNOTSUPPORTED");

            // Check arguments for null values
            if (username == null)
                ExceptionReporter.ThrowArgument("MEMBERSHIP", "USERNAMEPASSWORDNULL");

            // get an instance of the current password information class
            UserPasswordInfo currentPasswordInfo = UserPasswordInfo.CreateInstanceFromDB(this.ApplicationName, username, false, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            if (currentPasswordInfo != null)
            {
                if (UseSalt && String.IsNullOrEmpty(currentPasswordInfo.PasswordSalt))
                {
                    // get a new password salt...
                    newPasswordSalt = YafMembershipProvider.GenerateSalt();
                }
                else
                {
                    // use existing salt...
                    newPasswordSalt = currentPasswordInfo.PasswordSalt;
                }

                if (!String.IsNullOrEmpty(answer))
                {
                    // verify answer is correct...
                    if (!currentPasswordInfo.IsCorrectAnswer(answer)) return null;
                }

                // create a new password
                newPassword = YafMembershipProvider.GeneratePassword(this.MinRequiredPasswordLength, this.MinRequiredNonAlphanumericCharacters);
                // encode it...
                newPasswordEnc = YafMembershipProvider.EncodeString(newPassword, (int)this.PasswordFormat, newPasswordSalt, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);
                // save to the database
                DB.ResetPassword(this.ApplicationName, username, newPasswordEnc, newPasswordSalt, (int)this.PasswordFormat, this.MaxInvalidPasswordAttempts, this.PasswordAttemptWindow);
                // Return unencrypted password
                return newPassword;
            }

            return null;
        }

        /// <summary>
        /// Unlocks a users account
        /// </summary>
        /// <param name="username">User to be found based by Name</param>
        /// <returns>True/False is users account has been unlocked</returns>
        public override bool UnlockUser(string userName)
        {
            // Check for null argument
            if (userName == null)
                ExceptionReporter.ThrowArgumentNull("MEMBERSHIP", "USERNAMENULL");

            try
            {
                DB.UnlockUser(this.ApplicationName, userName);
                return true;
            }
            catch
            {
                // will return false below
            }

            return false;
        }


        /// <summary>
        /// Updates a providers user information
        /// </summary>
        /// <param name="user">MembershipUser object</param>
        public override void UpdateUser(MembershipUser user)
        {
            // Check User object is not null
            if (user == null)
                ExceptionReporter.ThrowArgumentNull("MEMBERSHIP", "MEMBERSHIPUSERNULL");

            // Update User
            int updateStatus = DB.UpdateUser(this.ApplicationName, user, this.RequiresUniqueEmail);

            // Check update was not successful
            if (updateStatus != 0)
            {
                // An error has occurred, determine which one.
                switch (updateStatus)
                {
                    case 1: ExceptionReporter.Throw("MEMBERSHIP", "USERKEYNULL");
                        break;
                    case 2: ExceptionReporter.Throw("MEMBERSHIP", "DUPLICATEEMAIL");
                        break;
                }
            }
        }

        /// <summary>
        /// Validates a user by user name / password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// /// <returns>True/False whether username/password match what is on database.</returns>
        public override bool ValidateUser(string username, string password)
        {
            UserPasswordInfo currentUser = UserPasswordInfo.CreateInstanceFromDB(this.ApplicationName, username, false, this.UseSalt, this.HashHex, this.HashCase, this.HashRemoveChars, this.MSCompliant);

            if (currentUser != null && currentUser.IsApproved)
            {
                return currentUser.IsCorrectPassword(password);
            }

            return false;
        }
        #endregion
         * */
    }
}
