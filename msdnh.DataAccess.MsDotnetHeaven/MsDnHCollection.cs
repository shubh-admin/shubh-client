namespace msdnh.DataAccess.MsDotnetHeaven
{
    /// <summary>
    /// 
    /// </summary>
    public class MsDnHCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public enum MyEnum
        {
            ResourceType,
            ResourceCategory,
            ResourceSubCategory
        }

        private string _Activated;
        private string _Browser;
        private string _Password;
        private string _SessionId;
        private string _UserId;
        private string _UserName;

        public string UserId
        {
            set { _UserId = value; }
            get
            {
                if (!string.IsNullOrEmpty(_UserId))
                    return _UserId;
                return string.Empty;
            }
        }

        public string UserName
        {
            set { _UserName = value; }
            get
            {
                if (!string.IsNullOrEmpty(_UserName))
                    return _UserName;
                return string.Empty;
            }
        }

        public MsDnHCollection UserCollection()
        {
            var objUserCollection = new MsDnHCollection();
            objUserCollection.UserId = UserId;
            objUserCollection.UserName = UserName;
            return objUserCollection;
        }
    }
}