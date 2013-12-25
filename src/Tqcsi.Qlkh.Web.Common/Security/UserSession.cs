using System;
using System.Security.Claims;

namespace Tqcsi.Qlkh.Web.Common.Security
{
    public class UserSession : IUserSession
    {
        public UserSession(ClaimsPrincipal principal)
        {
            UserId = Convert.ToInt32(principal.FindFirst(ClaimTypes.Sid).Value);
            Firstname = principal.FindFirst(ClaimTypes.GivenName).Value;
            Lastname = principal.FindFirst(ClaimTypes.Surname).Value;
            Username = principal.FindFirst(ClaimTypes.Name).Value;
            Email = principal.FindFirst(ClaimTypes.Email).Value;
        }

        public int UserId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}