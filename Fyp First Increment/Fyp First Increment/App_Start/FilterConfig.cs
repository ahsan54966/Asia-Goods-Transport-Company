using Fyp_First_Increment.App_Start;
using System.Web;
using System.Web.Mvc;

namespace Fyp_First_Increment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
