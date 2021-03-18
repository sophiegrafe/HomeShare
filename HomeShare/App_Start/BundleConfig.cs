using System.Web;
using System.Web.Optimization;

namespace HomeShare
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/owlCarousel").Include(
                      "~/css/owl.carousel.css",
                      "~/css/owl.theme.css"));

            bundles.Add(new StyleBundle("~/Content/slitSlider").Include(
                      "~/css/slitSlider-custom.css",
                      "~/css/slitSlider-style.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/slitSlider").Include(
                        "~/js/jquery.slitslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlCarousel").Include(
                        "~/js/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.ba-cond.min").Include(
                        "~/js/jquery.ba-cond.min.js")); 

            bundles.Add(new ScriptBundle("~/bundles/customScript").Include(
                        "~/js/script.js",
                        "~/js/modernizr.custom.79639.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
        
    
        }
    }
}
