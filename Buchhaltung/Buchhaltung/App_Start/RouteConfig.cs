using System.Web.Mvc;
using System.Web.Routing;

namespace Buchhaltung
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Bilanz",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            //routes.MapRoute(
            //    name: "BilanzDetails",
            //    url: "Bilanz/{action}/{id}",
            //    defaults: new { controller = "Bilanz", action = "Details" }
            //);
        }
    }
}
