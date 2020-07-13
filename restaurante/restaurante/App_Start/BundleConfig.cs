using System.Web;
using System.Web.Optimization;

namespace restaurante
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/js/material-dashboard.js",
                        "~/Content/js/material-dashboard.js.map",
                        "~/Content/js/material-dashboard.min.js",
                        "~/Content/js/bootstrap-material-design.min.js",
                        "~/Content/js/bootstrap-notify.js",
                        "~/Content/js/chartist.min.js",
                        "~/Content/js/jquery.min.js",
                        "~/Content/js/perfect-scrollbar.jquery.min.js",
                        "~/Content/js/popper.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      	"~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap.css.map",
                        "~/Content/css/test/material-dashboard.css",
                        "~/Content/css/material-dashboard.css.min",
                        "~/Content/css/material-dashboard.css.map",
	                    "~/Content/css/style.css",
                        "~/Content/css/bootstrap-grid.css",
                        "~/Content/css/bootstrap-grid.css.map",
                        "~/Content/css/bootstrap-reboot.css",
                        "~/Content/css/bootstrap-reboot.css.mmap"));
        }
    }
}
