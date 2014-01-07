using System;
using System.Collections.Generic;
using System.Web.Security;

namespace Tqcsi.Qlkh.Web.Common.Security
{
    public class MembershipAdapter : IMembershipInfoProvider
    {
        public int GetUserId(string username)
        {
            var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
            return membership.GetUserId(username);
        }

        public int CreateUser(string username, string password, string firstName, string lastName, string email)
        {
            var addInfo = new Dictionary<string, object>();

            addInfo.Add("FirstName", firstName);
            addInfo.Add("LastName", lastName);
            addInfo.Add("Email", email);

            var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
            membership.CreateUserAndAccount(username, password, false, addInfo);

            return membership.GetUserId(username);
        }

        public bool ValidateUser(string username, string password)
        {
            var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
            return membership.ValidateUser(username, password);
        }

        public string[] GetRolesForUser(string username)
        {
            return  Roles.GetRolesForUser(username);
        }
    }
}
