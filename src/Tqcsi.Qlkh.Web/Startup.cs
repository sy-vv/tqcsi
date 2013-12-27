using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tqcsi.Qlkh.Web.Startup))]
namespace Tqcsi.Qlkh.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
