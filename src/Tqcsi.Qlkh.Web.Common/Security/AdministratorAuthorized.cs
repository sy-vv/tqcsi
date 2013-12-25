using System.Web.Http;

namespace Tqcsi.Qlkh.Web.Common.Security
{
    public class AdministratorAuthorized : AuthorizeAttribute
    {
        public AdministratorAuthorized()
        {
            Roles = "Administrators";
        }
    }
}