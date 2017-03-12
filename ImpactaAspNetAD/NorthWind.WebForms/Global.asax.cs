using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace NorthWind.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_Error(object sender, EventArgs e)
        {
            var excecao = Server.GetLastError();
            // Implementar log4net, por exemplo.
        }
    }
}