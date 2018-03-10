using DarkGalaxy_Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkGalaxy_UI_Mobile
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册路由规则
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //启用数据库依赖
            Helper_Cache.EnableSqlCacheDependency();
        }
    }
}
