using Northwind.Mvc.Ado.Filtros;
using System.Web.Mvc;

namespace Northwind.Mvc.Ado
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new LogErrorAttribute());
        }
    }
}