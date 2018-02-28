using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkGalaxy_UI_Manage
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

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    //获取异常信息
        //    Exception ExceptionInfo = Server.GetLastError();
        //    Response.TrySkipIisCustomErrors = true;
        //    Response.clear();

        //    //处理错误信息
        //    DGError ErrorInfo = new DGError();
        //    if (ExceptionInfo != null)
        //    {
        //        //设置错误信息
        //        string RequestParames = null;
        //        HttpException HttpExceptionInfo = ExceptionInfo as HttpException;
        //        if (HttpExceptionInfo != null)
        //        {
        //            switch (HttpExceptionInfo.GetHttpCode())
        //            {
        //                case 404:
        //                    ErrorInfo.ErrorCode = "404";
        //                    ErrorInfo.ErrorDescribe = "NO FOUND";
        //                    ErrorInfo.ErrorContent = "您找的页面被外星人抓走了！";
        //                    break;
        //                case 500:
        //                    ErrorInfo.ErrorCode = "500";
        //                    ErrorInfo.ErrorDescribe = "SERVER ERROR";
        //                    ErrorInfo.ErrorContent = "呀！内部服务器出错啦！";
        //                    break;
        //            }
        //        }
        //        else { }

        //        //设置错误信息参数
        //        FieldInfo[] FieldInfos = typeof(DGError).GetFields();
        //        foreach (FieldInfo temp in FieldInfos)
        //        {
        //            object FieldValue = temp.GetValue(ErrorInfo);
        //            if ((null != FieldValue) && (false == String.IsNullOrEmpty(FieldValue.ToString())))
        //            {
        //                RequestParames += (temp.Name + "=" + FieldValue.ToString());
        //            }
        //            else { }
        //        }
        //        Server.clearError();
        //        //Response.Redirect("~/Error/Index?" + RequestParames, true);
        //    }
        //    else { }
        //}

        //伪静态
        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    HttpContext context = ((HttpApplication)sender).Context;

        //    string Url = context.Request.Url.AbsolutePath;
        //    string RegexHtml = @"\.html$";

        //    Regex Regexs = new Regex(RegexHtml, RegexOptions.Compiled);
        //    if (Regexs.IsMatch(Url))
        //    {
        //        Url = Regexs.Replace(Url, ".aspx");
        //        context.RewritePath(Url);
        //    }
        //    else { }
        //}
    }
}
