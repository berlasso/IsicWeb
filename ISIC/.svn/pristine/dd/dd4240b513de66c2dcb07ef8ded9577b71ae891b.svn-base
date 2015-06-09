using System.Web;
using System.Web.Optimization;

namespace ISICWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                           "~/Scripts/jquery.validate*",
                           "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
    "~/Scripts/DataTables-1.10.4/jquery.dataTables.min.js",
    "~/Scripts/DataTables-1.10.4/dataTables.tableTools.min.js",
    "~/Scripts/DataTables-1.10.4/dataTables.colVis.min.js",
    "~/Scripts/DataTables-1.10.4/dataTables.colReorder.min.js",
    "~/Scripts/DataTables-1.10.4/dataTables.fixedHeader.min.js",
                //"~/Scripts/DataTables-1.10.4/dataTables.jqueryui.min.js",
                //"~/Scripts/DataTables-1.10.4/dataTables.bootstrap.js",
    "~/Scripts/DataTables-1.10.4/dataTables.responsive.min.js"));


            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // fabric
            bundles.Add(new ScriptBundle("~/bundles/fabric").Include(
                      "~/Scripts/fabric.js"));

            // pretty Photo

            bundles.Add(new ScriptBundle("~/bundles/prettyPhoto").Include(
                      "~/Scripts/jquery.prettyPhoto.js",
                      "~/Scripts/jquery.isotope.min.js"));
            //boostrap
            bundles.Add(new StyleBundle("~/Content/boostrap").Include(
                   "~/Content/boostrap.css"));


            //alertify
            bundles.Add(new ScriptBundle("~/bundles/alertifyjs").Include(
                    "~/Scripts/alertify.min.js"));
            bundles.Add(new StyleBundle("~/Content/alertifycss").Include(
                "~/Content/alertifyjs/alertify.min.css",
                      "~/Content/alertifyjs/themes/semantic.min.css"));

            bundles.Add(new StyleBundle("~/Content/prettyPhoto").Include(
          "~/Content/prettyPhoto.css"));
            // jquery ui
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                     "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/variosjs").Include(
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/jquery.imagemapster.js",
                "~/Scripts/selectize.js",
                "~/Scripts/jquery.maskedinput.min.js",
                "~/Scripts/site.js",
                "~/Scripts/wow.min.js",
                "~/scripts/moment.min.js",
                "~/Scripts/scriptcam.min.js",
                "~/Scripts/swfobject.js",
                "~/scripts/moment-with-locales.min.js",
                //"~/scripts/scriptcam.js",
                "~/scripts/bootstrap-datetimepicker*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
            "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                //"~/Content/DataTables-1.10.4/css/jquery.dataTables.min.css",
                "~/Content/DataTables-1.10.4/css/dataTables.tableTools.min.css",
                "~/Content/DataTables-1.10.4/css/dataTables.colVis.min.css",
                "~/Content/DataTables-1.10.4/css/dataTables.colReorder.min.css",
                "~/Content/DataTables-1.10.4/css/dataTables.responsive.min.css",
                "~/Content/DataTables-1.10.4/css/dataTables.fixedHeader.min.css"
                //"~/Content/DataTables-1.10.4/css/dataTables.bootstrap.css"
                //"~/Content/DataTables-1.10.4/css/dataTables.jqueryui.min.css"
            ));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                 "~/Content/jquery-ui*"));

            bundles.Add(new StyleBundle("~/Content/varioscss").Include(
                 "~/Content/selectize.bootstrap3.css",
    "~/Content/font-awesome.min.css",
    "~/Content/animate.min.css",
    "~/Content/form.css",
    "~/Content/bootstrap-datetimepicker.css",
    "~/fonts/icons/flaticons/flaticon.css",
    "~/Scripts/jsTree3/themes/default/style.min.css"));

            // Para la depuración, establezca EnableOptimizations en false. Para obtener más información,
            // visite http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
