using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.Mvc.Ado
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // A ordem é relevante!
            routes.MapRoute(
                name: "ClientesPorPais",
                url: "Clientes/{nomePais}",
                defaults: new { controller = "Cliente", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
