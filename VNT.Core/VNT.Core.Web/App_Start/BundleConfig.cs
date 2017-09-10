using System.Web;
using System.Web.Optimization;

namespace VNT.UI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
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

            bundles.Add(new ScriptBundle("~/bundles/themeScript").Include(
                "~/Content/assets/js/jquery.js",
                "~/Content/assets/js/jquery-1.8.3.min.js",
                "~/Content/assets/js/bootstrap.min.js",
                "~/Content/assets/js/jquery.dcjqaccordion.2.7.js",
                "~/Content/assets/js/jquery.scrollTo.min.js",
                "~/Content/assets/js/jquery.nicescroll.js",
                "~/Content/assets/js/jquery.sparkline.js",
                "~/Content/assets/js/common-scripts.js",
                "~/Content/assets/js/gritter/js/jquery.gritter.js",
                "~/Content/assets/js/gritter-conf.js",
                "~/Content/assets/js/chart-master/Chart.js"));

            bundles.Add(new StyleBundle("~/bundles/themeStyle").Include(
                "~/Content/assets/css/bootstrap.css",
                "~/Content/assets/font-awesome/css/font-awesome.css",
                "~/Content/assets/css/zabuto_calendar.css",
                "~/Content/assets/js/gritter/css/jquery.gritter.css",
                "~/Content/assets/lineicons/style.css",
                "~/Content/assets/css/style.css",
                "~/Content/assets/css/style-responsive.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/loginStyle").Include(
                "~/Content/assets/css/bootstrap.css",
                "~/Content/assets/font-awesome/css/font-awesome.css",
                "~/Content/assets/css/style.css",
                "~/Content/assets/css/style-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/loginScript").Include(
                "~/Content/assets/js/jquery.js",
                "~/Content/assets/js/bootstrap.min.js",
                "~/Content/assets/js/jquery.backstretch.min.js"));
        }
    }
}
