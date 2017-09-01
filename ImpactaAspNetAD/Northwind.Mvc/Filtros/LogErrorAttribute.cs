using System.Diagnostics;
using System.Web.Mvc;

namespace Northwind.Mvc.Ado.Filtros
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Debug.WriteLine(filterContext.Exception);
        }
    }
}