using System.Web;
using System.Web.Mvc;

namespace Net.SSO.Client.Web2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
