using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fyp_First_Increment.App_Start
{
    public class VehicleAuthentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session != null && session["VehicleNumber"] == null)
                {
                    filterContext.Result =
                           new RedirectToRouteResult(
                               new RouteValueDictionary{{ "controller", "Home" },
                                          { "action", "Index"}
                                          ////{"id","4"}
                                         });
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}