using System.Web;
using System.Web.Optimization;

namespace FoodOrderSolution.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Styles/js").Include(
                      "~/Content/lib/fontawesome-free-5.10.2-web/js/brands.js",
                      "~/Content/lib/fontawesome-free-5.10.2-web/js/solid.js",
                      "~/Content/lib/fontawesome-free-5.10.2-web/js/fontawesome.js",
                      "~/Content/lib/jquery/jquery-3.4.1.min.js",
                      "~/Content/lib/bootstrap/js/bootstrap.min.js",
                      "~/Content/lib/Magnific-Popup-master/dist/jquery.magnific-popup.js",
                      "~/Content/lib/slick/slick/slick.min.js",
                      "~/Content/js/bootstrap-datepicker.min.js",
                      "~/Content/js/theme.js",
                      "~/Content/js/script.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/lib/bootstrap/css/bootstrap.min.css",
                      "~/Content/css/normalize.css",
                      "~/Content/css/theme.css",
                      "~/Content/css/theme/themelibrary.css",
                      "~/Content/lib/slick/slick/slick.css",
                      "~/Content/lib/slick/slick/slick-theme.css",
                      "~/Content/css/bootstrap-datepicker.min.css",
                      "~/Content/lib/Magnific-Popup-master/dist/magnific-popup.css"));
        }
    }
}
