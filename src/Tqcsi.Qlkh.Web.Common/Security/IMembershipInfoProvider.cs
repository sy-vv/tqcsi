using System;

namespace Tqcsi.Qlkh.Web.Common.Security
{
    public interface IMembershipInfoProvider
    {
        int GetUserId(string username);
        int CreateUser(string username, string password, string firstName, string lastName, string email);
        bool ValidateUser(string username, string password);
        string[] GetRolesForUser(string username);
    }
}