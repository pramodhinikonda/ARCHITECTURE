using System;
using System.Web.Optimization;

namespace Y_WEB.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            BundleTable.EnableOptimizations = false;
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                            .Include(
                                // jQuery plugins
                                "~/Scripts/TrafficCop.min.js",
                                 //Amplify
                                 "~/Scripts/amplify.min.js",
                                //Bootstrap js
                                "~/Scripts/bootstrap.min.js",
                                // Knockout and its plugins
                                "~/Scripts/knockout-{version}.js",
                                "~/Scripts/knockout.activity.js",
                                "~/Scripts/knockout.command.js",
                                "~/Scripts/knockout.dirtyFlag.js",
                                "~/Scripts/knockout.validation.min.js",
                                "~/Scripts/knockout.mapping-latest.js",
                                "~/Scripts/knockout-switch-case.min.js",
                                "~/Scripts/knockout-bootstrap.min.js",
                                "~/Scripts/knockout.mapping-latest.js",

                                // Other 3rd party libraries
                                "~/Scripts/underscore.min.js",
                                "~/Scripts/moment.min.js",
                                "~/Scripts/kinetic.min.js",
                                "~/Scripts/xml2json.js"
                                ));

            bundles.Add(new StyleBundle("~/Content/css")
                              .Include("~/Content/durandal.css")
                              .Include("~/Content/bootstrap.min.css")
                              .Include("~/Content/font-awesome.min.css")
                            );
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
        }
    }
}
