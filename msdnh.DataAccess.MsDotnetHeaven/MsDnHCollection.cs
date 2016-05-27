using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using msdnh.DataAccess.MsDotnetHeaven;

namespace msdnh.DataAccess.MsDotnetHeaven.MsDnHCollection
{
    public class MsDnHCollection
    {
        private string _SessionId;
        private string _Browser;
        private string _UserId;
        private string _UserName;
        private string _Password;
        private string _Activated;

        public enum MyEnum
        {
            ResourceType,
            ResourceCategory,
            ResourceSubCategory
        }

        public string UserId
        {
            set
            {
                _UserId = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_UserId))
                    return _UserId;
                else
                    return string.Empty;
            }
        }
        public string UserName
        {
            set
            {
                _UserName = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_UserName))
                    return _UserName;
                else
                    return string.Empty;
            }
        }
        public MsDnHCollection UserCollection()
        {
            MsDnHCollection objUserCollection = new MsDnHCollection();
            objUserCollection.UserId = this.UserId;
            objUserCollection.UserName = this.UserName;
            return objUserCollection;
        }

    }
}
