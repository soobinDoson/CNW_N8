using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = Session["LoginBackend"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "User", action = "Login"}));

            }

            base.OnActionExecuted(filterContext);
        }
    }
}