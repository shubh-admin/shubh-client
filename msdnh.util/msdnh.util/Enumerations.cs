using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace msdnh.util
{
    public static class Enumerations
    {
        public enum UserDetail
        {
            UserId=1,
            FirstName=2,
            LastName=3,
        }
        public enum UserRoles
        {
            Owner = 1,
            SuperAdmin = 2,
            Admin = 3,
            Webmaster = 4,
            Manager = 5,
            LeadEditor = 6,
            Editor = 7,
            Contributor = 8,
            Publisher = 9,
            Member = 10,
            Resource = 11,
            ResourceDelete = 12,
            ResourceEdit = 13,
            ResourceView = 14,
            AddComment = 15
        }

        public enum MenusDirection
        {
            Horizontal = 1,
            Vertical
        }
        public enum UserType
        {
            Staff,
            Client
        }


    }
}
