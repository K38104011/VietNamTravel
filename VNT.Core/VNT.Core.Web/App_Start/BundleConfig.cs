using System.Web.Optimization;

namespace VNT.UI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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
                "~/Content/assets/font-awesome/css/Roboto.css",
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
