using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ALProject.Authorization
{
    public class RequireLogin : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region"This is where we check the sessions created by the Ektron Environment."

            String User = (String)filterContext.HttpContext.Session["Ektron_User"];
            // checking for Session exists
            Boolean hasSession = User != null;
            //If no Session exists
            if (!hasSession)
            {

                filterContext.Result = new RedirectToRouteResult(
                                  new RouteValueDictionary
                                  {
                                       { "controller", "AL" },
                                       { "action", "Login" }

                                  });

            }


            #endregion

        }
    }
}