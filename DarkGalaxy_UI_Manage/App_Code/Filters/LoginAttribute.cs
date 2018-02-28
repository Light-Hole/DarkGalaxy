using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DarkGalaxy_UI_Manage
{
    public class LoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);

            //判断登录状态
            if (null != httpContext.Session["AdminAccount"])
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
                UrlHelper UrlHelpers = new UrlHelper(filterContext.RequestContext);
                string Url = UrlHelpers.Action("Index", "Login");
                filterContext.HttpContext.Response.Write("<script>top.location='" + Url + "'</script>");
                filterContext.HttpContext.Response.End();
            }
        }
    }
}