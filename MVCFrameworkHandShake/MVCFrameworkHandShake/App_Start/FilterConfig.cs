using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkHandShake
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //For Enabling AuthRization
            filters.Add(new AuthorizeAttribute());
        }
    }
}
