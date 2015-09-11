using System.Web.Optimization;

namespace LucentDb.Web.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/LucentDbServices").Include(
                "~/app/services/AssertTypeDataService.js",
                "~/app/services/ConnectionDataService.js",
                "~/app/services/ExpectedResultDataService.js",
                "~/app/services/Project_ConnectionDataService.js",
                "~/app/services/ProjectDataService.js",
                "~/app/services/RunHistoryDataService.js",
                "~/app/services/Script_ExpectedResultDataService.js",
                "~/app/services/ScriptDataService.js",
                "~/app/services/ScriptTypeDataService.js",
                "~/app/services/Test_ScriptDataService.js",
                "~/app/services/TestDataService.js",
                "~/app/services/TestTypeDataService.js",
                "~/app/services/LucentDbDataContext.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.yeti.min.css",
                "~/Content/site.css"));
        }
    }
}