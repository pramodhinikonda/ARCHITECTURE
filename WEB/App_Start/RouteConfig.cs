using System.Web.Mvc;
using System.Web.Routing;

namespace Y_WEB.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "Home", action = "Demo", Id = UrlParameter.Optional }
            );
        }
    }
}
