using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkHandShake.Custom.Filters
{
    public class DebugFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine(
                $"DebugFilter : OnActionExecuted => Method : {filterContext.HttpContext.Request.HttpMethod} ------- Controller : {filterContext.Controller} -------- Action : {filterContext.RouteData.Values["action"]}"
                );
        }
    }
}