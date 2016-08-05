using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CirneSports.LojaVirtual.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-1.*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr.*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                    "~/Content/Site.css",
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-theme.css",
                    "~/Content/ErroEstilo.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}