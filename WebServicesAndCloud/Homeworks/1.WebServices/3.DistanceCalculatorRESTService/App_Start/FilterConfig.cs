using System.Web;
using System.Web.Mvc;

namespace _3.DistanceCalculatorRESTService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
