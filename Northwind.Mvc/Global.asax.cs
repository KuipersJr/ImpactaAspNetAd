using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Northwind.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var excecao = Server.GetLastError();
            // Implementar log4net, por exemplo.
        }
    }
}
