using System.Web.Mvc;
using System.Web.Routing;

namespace PriceListEditor2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PriceLists", action = "PriceLists", id = UrlParameter.Optional }
            );
        }
    }
}
