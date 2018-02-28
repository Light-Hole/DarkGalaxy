using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DarkGalaxy_UI_Manage.pay
{
    public partial class EnterprisePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////处理错误参数
            //DGError ErrorInfo = new DGError();
            //if ((String.IsNullOrEmpty(WeChat_Basicinfo.AppID)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AppSecret)) || (String.IsNullOrEmpty(WeChat_Basicinfo.PayKey)) || (String.IsNullOrEmpty(WeChat_Basicinfo.PayMchID)))
            //{
            //    ErrorInfo.ErrorCode = "未定义";
            //    ErrorInfo.ErrorDescribe = "未设置WeChat基本信息";
            //    string ErrorInfoJson = Helper_Serializer_Json.JsonSerializer(ErrorInfo);
            //    Response.Redirect("/Error/Index?ErrorInfo=" + ErrorInfoJson);
            //}
            //else { }

            ////WeChat企业付款
            //if (String.IsNullOrEmpty(Request.QueryString["code"]))
            //{
            //    //获取网页授权Code
            //    WebAuthorization_Code CodeModel = new WebAuthorization_Code(WeChat_Basicinfo.AppID, "http://k10.iwangto.com/pay/EnterprisePay.aspx", WebAuthorizationType.snsapi_base);
            //    if (!String.IsNullOrEmpty(Request["OrderNum"]))
            //    {
            //        CodeModel.state = Request["OrderNum"];
            //    }
            //    else
            //    {
            //        Response.Write("没有商户订单号");
            //    }
            //    string CodeUrl = WeChat_Web.CreateWebAuthorizationCodeUrl(CodeModel);
            //    Response.Redirect(CodeUrl);
            //}
            //else
            //{
            //    //设置基本参数
            //    string Url = Request.Url.ToString();
            //    string IPAddress = Request.ServerVariables["LOCAL_ADDR"];
            //    string TimeStamp = Helper_Time.CreateTimeStamp(DateTime.UtcNow, new DateTime(1970, 1, 1, 0, 0, 0, 0));
            //    string NonceStr = Guid.NewGuid().ToString().Replace("-", "");

            //    //请求WeChat获取OpenID
            //    string Code = Request.QueryString["code"];
            //    var Token = WeChat_Web.GetWebAuthorizationAccessToken(new WebAuthorization_Token(WeChat_Basicinfo.AppID, WeChat_Basicinfo.AppSecret, Code));
            //    if (null == Token)
            //    {
            //        ErrorInfo.ErrorCode = "未定义";
            //        ErrorInfo.ErrorDescribe = "获取WeChat网页授权失败";
            //        string ErrorInfoJson = Helper_Serializer_Json.JsonSerializer(ErrorInfo);
            //        Response.Redirect("/Error/Index?ErrorInfo=" + ErrorInfoJson);
            //    }
            //    else if (0 != Token.errcode)
            //    {
            //        ErrorInfo.ErrorCode = "WeChat错误码：" + Token.errcode.ToString();
            //        ErrorInfo.ErrorDescribe = "获取WeChat网页授权失败，WeChat消息：" + Token.errmsg;
            //        string ErrorInfoJson = Helper_Serializer_Json.JsonSerializer(ErrorInfo);
            //        Response.Redirect("/Error/Index?ErrorInfo=" + ErrorInfoJson);
            //    }
            //    else { }

            //    //请求WeChat企业付款
            //    Enterprise EnterprisePays = new Enterprise(WeChat_Basicinfo.AppID, WeChat_Basicinfo.PayMchID, NonceStr, Request.QueryString["state"], Token.openid, 100, "企业测试描述", IPAddress);
            //    EnterprisePays.sign = WeChat_Pay.CreatePaySignature(EnterprisePays, WeChat_Basicinfo.PayKey, PaySignatureType.MD5);
            //    var EnterprisePaysResult = WeChat_Pay.SendEnterprisePayer(EnterprisePays, "D://site/hongbao/apiclient_cert.p12", WeChat_Basicinfo.PayMchID);
            //    if (("SUCCESS" != EnterprisePaysResult.return_code) || ("SUCCESS" != EnterprisePaysResult.result_code))
            //    {
            //        ErrorInfo.ErrorCode = "WeChat返回状态码：" + EnterprisePaysResult.return_code + "/WeChat错误码：" + EnterprisePaysResult.err_code;
            //        ErrorInfo.ErrorDescribe = "发送WeChat企业付款失败，" + "WeChat返回消息：" + EnterprisePaysResult.return_msg + "/WeChat错误消息：" + EnterprisePaysResult.err_code_des;
            //        string ErrorInfoJson = Helper_Serializer_Json.JsonSerializer(ErrorInfo);
            //        Response.Redirect("/Error/Index?ErrorInfo=" + ErrorInfoJson);
            //    }
            //    else { }
            //}
        }
    }
}