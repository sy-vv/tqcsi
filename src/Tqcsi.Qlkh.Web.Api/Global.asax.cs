using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Tqcsi.Qlkh.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            WebSecurity.InitializeDatabaseConnection("Mvc4ServicesDb",
                userTableName: "UserProfile",
                userIdColumn: "UserId",
                userNameColumn: "UserName",
                autoCreateTables: true);
        }
    }
}