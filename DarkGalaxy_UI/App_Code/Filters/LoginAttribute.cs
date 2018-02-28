using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI
{
    public class LoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);

            //判断登录状态
            if (null != httpContext.Request.Cookies["UserAccount"])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                UrlHelper mvcUrlHelpers = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(mvcUrlHelpers.Action("Index", "Login"));
            }
        }
    }
}