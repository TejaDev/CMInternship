using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ALProject.Authorization
{
    public class RequireRole : ActionFilterAttribute, IActionFilter
    {
        String thisRole;//="ALADMIN";
        public RequireRole(String Role)
        {
            thisRole = Role;
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region"This is where we check the sessions created by the Ektron Environment."
            /*
             * The following lines of code assumes that the Ektron Environment will create a three Sessions Variables 
             * Ektron_User - > the User ID
             * Ektron_Role - > the Role of this User
             * 
             * 
             */
            String User = (String)filterContext.HttpContext.Session["Ektron_User"];
            // Session exists
            Boolean hasSession = User != null;
            String Role = User == null ? "" : filterContext.HttpContext.Session["Ektron_Role"].ToString();
            Boolean hasRole = Role.Equals(thisRole);
            if (hasSession && hasRole)
            {   // Has Session and Role.

                // If the role is IPCADMIN, we will set an additional session for IPC ADMIN purposes
                if (thisRole.Equals("ALADMIN") && filterContext.HttpContext.Session["Ektron_ALADMIN"] == null)
                {
                    filterContext.HttpContext.Session["Ektron_ALADMIN"] = User;
                }

            }

            else
            {// Has Session but invalid Role.

                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "controller", "ALAdmin" },
                                       { "action", "DefaultPage" }

                                   });
            }
            #endregion

        }
    }
}