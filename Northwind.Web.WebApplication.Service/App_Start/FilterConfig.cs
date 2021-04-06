using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.WebApplication.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
