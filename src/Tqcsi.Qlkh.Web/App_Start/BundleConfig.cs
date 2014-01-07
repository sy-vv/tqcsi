using System.Web;
using System.Web.Optimization;

namespace Tqcsi.Qlkh.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Third Party plugins
            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
                     "~/Third_party/bootboxjs/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/thirdparty").Include(
                      "~/Third_party/fuelux/css/fuelux.css",
                      "~/Third_party/fuelux/css/fuelux-responsive.css"));
        }
    }
}