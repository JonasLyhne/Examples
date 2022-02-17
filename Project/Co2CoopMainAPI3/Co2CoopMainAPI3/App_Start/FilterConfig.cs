using System.Web;
using System.Web.Mvc;

namespace Co2CoopMainAPI3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
