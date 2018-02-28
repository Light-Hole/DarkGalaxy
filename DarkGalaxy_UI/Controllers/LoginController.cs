using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using DarkGalaxy_WeChat;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("UserAccount");
            cookie.Values.Add("ID", "1");
            Response.AppendCookie(cookie);
            return RedirectToAction("Index", "Home");

            //判断登陆状态
            //if (null == Request.Cookies["UserAccount"])
            //{
            //    DGError result = new DGError();

            //    //处理错误参数
            //    if ((String.IsNullOrEmpty(WeChat_Basicinfo.AppID)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AppSecret)))
            //    {
            //        result.ErrorCode = "500";
            //        result.ErrorDescribe = "内部服务器错误";
            //        result.ErrorContent = "未设置WeChat基本信息，请检查是否设置了AppID、AppSecret";
            //        return View();
            //    }
            //    else { }

            //    //请求WeChat获取OpenID
            //    WeChat_Web wecWeb = new WeChat_Web();
            //    if (String.IsNullOrEmpty(Request.QueryString["code"]))
            //    {
            //        //获取网页授权Code
            //        WebAuthorization_Code vmodWebCode = new WebAuthorization_Code(WeChat_Basicinfo.AppID, "http://k3.iwangto.com/Default.aspx", WebAuthorizationType.snsapi_base);
            //        string strUrl = wecWeb.CreateWebAuthorizationCodeUrl(vmodWebCode);//生成网页授权URL
            //        return Redirect(strUrl);
            //    }
            //    else
            //    {
            //        //请求WeChat获取OpenID
            //        string strCode = Request.QueryString["code"];
            //        WebAuthorization_Token wmodWebAuthorization = new WebAuthorization_Token(WeChat_Basicinfo.AppID, WeChat_Basicinfo.AppSecret, strCode);
            //        WebAccessToken wmodWebToken = wecWeb.GetWebAuthorizationAccessToken(wmodWebAuthorization);
            //        if (null == wmodWebToken)
            //        {
            //            result.ErrorCode = "500";
            //            result.ErrorDescribe = "内部服务器错误";
            //            result.ErrorContent = "获取WeChat网页授权失败";
            //            return View();
            //        }
            //        else if (0 != wmodWebToken.errcode)
            //        {
            //            result.ErrorCode = "WeChat错误码：" + wmodWebToken.errcode.ToString();
            //            result.ErrorDescribe = "内部服务器错误";
            //            result.ErrorContent = "获取WeChat网页授权失败，WeChat消息：" + wmodWebToken.errmsg;
            //            return View();
            //        }
            //        else
            //        {
            //            //设置登录状态
            //            BLL_UserAccount bllUserAccount = new BLL_UserAccount();
            //            BLL_UserInformation bllUserInfo = new BLL_UserInformation();
            //            UserAccount modUserAccount = bllUserAccount.SelectSingleIntoUserAccount_WeChat(wmodWebToken.openid);//查询用户记录
            //            if (null == modUserAccount)
            //            {
            //                //新建用户记录
            //                int intID = 0;
            //                bllUserAccount.InsertUserAccount(new UserAccount() { OpenID = wmodWebToken.openid }, out intID);
            //                bllUserInfo.InsertUserInformation(new UserInformation() { UserAccount_ID = intID }, out intID);

            //                //设置登录状态
            //                HttpCookie cookie = new HttpCookie("UserAccount");
            //                cookie.Values.Add("ID", intID.ToString());
            //                cookie.Values.Add("OpenID", wmodWebToken.openid);
            //                Response.AppendCookie(cookie);
            //                return RedirectToAction("Index", "Home");
            //            }
            //            else
            //            {
            //                //设置登录状态
            //                HttpCookie cookie = new HttpCookie("UserAccount");
            //                cookie.Values.Add("ID", modUserAccount.ID.ToString());
            //                cookie.Values.Add("OpenID", modUserAccount.OpenID);
            //                Response.AppendCookie(cookie);
            //                return RedirectToAction("Index", "Home");
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }
    }
}