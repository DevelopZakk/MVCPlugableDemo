using System.Web;
using System.Web.Mvc;

namespace myHost.WebSite1PlugIn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
