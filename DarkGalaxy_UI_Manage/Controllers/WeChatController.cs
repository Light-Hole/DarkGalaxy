using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_Model;
using DarkGalaxy_WeChat;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkGalaxy_UI_Manage.Controllers
{
    public class WeChatController : Controller
    {
        /// <summary>
        /// 接收WeChat推送消息
        /// </summary>
        /// <returns></returns>
        public ActionResult ReceiveWeChatMessage()
        {
            if (0 == String.Compare("GET", Request.HttpMethod, true))
            {
                //接收WeChat服务器参数
                string Token = "WeChat";//WeChat设置的Token
                string Timestamp = Request.QueryString["timestamp"].ToString();
                string Nonce = Request.QueryString["nonce"].ToString();
                string Signature = Request.QueryString["signature"].ToString().ToLower();
                string EchoStr = Request.QueryString["echostr"].ToString();

                //处理WeChat服务器参数
                if ((String.IsNullOrEmpty(Timestamp)) || (String.IsNullOrEmpty(Nonce)) || (String.IsNullOrEmpty(Nonce)) || (String.IsNullOrEmpty(Signature)) || (String.IsNullOrEmpty(EchoStr)))
                {
                    return Content("");
                }
                else { }

                //验证WeChat服务器
                WeChat_Basicinfo wecBasicinfo = new WeChat_Basicinfo();
                string SignatureValidation = wecBasicinfo.CreateServerValidationSignature(Token, Timestamp, Nonce);
                if (SignatureValidation == Signature)
                {
                    return Content(EchoStr);
                }
                else
                {
                    return Content("");
                }
            }
            else if (0 == String.Compare("POST", Request.HttpMethod, true))
            {
                //接收WeChat服务器推送数据
                string RequestContent = null;
                using (Stream RequestStream = Request.InputStream)
                {
                    StreamReader ContentReader = new StreamReader(RequestStream, Encoding.UTF8);
                    RequestContent = ContentReader.ReadToEnd();
                }

                //处理接收到的数据
                if (!String.IsNullOrEmpty(RequestContent))
                {
                    string TimeStamp = Helper_Time.CreateTimeStamp(DateTime.Now, new DateTime(1970, 1, 1, 0, 0, 0));
                    ReceiveMessage_Base ReceiveMessageBase = Helper_Serializer_Xml.XmlDeserializer<ReceiveMessage_Base>(RequestContent);
                    switch (ReceiveMessageBase.MsgType.ToLower())
                    {
                        //处理接收普通消息
                        case "text":
                            //文本消息
                            ReceiveMessage_Text TextMessage = Helper_Serializer_Xml.XmlDeserializer<ReceiveMessage_Text>(RequestContent);
                            ReplyPassiveMessage_Text ReplyText = new ReplyPassiveMessage_Text(TextMessage.FromUserName, TextMessage.ToUserName, TimeStamp, TextMessage.Content);
                            return Content(Helper_Serializer_Xml.XmlSerializer(ReplyText, String.Empty, String.Empty));

                        //处理接收事件
                        case "event":
                            ReceiveEvent_Base ReceiveEventBase = Helper_Serializer_Xml.XmlDeserializer<ReceiveEvent_Base>(RequestContent);
                            switch (ReceiveEventBase.Event.ToLower())
                            {
                                case "click":
                                    //菜单点击事件
                                    ReceiveEvent_CustomizeMenu CustomizeMenuEvent = Helper_Serializer_Xml.XmlDeserializer<ReceiveEvent_CustomizeMenu>(RequestContent);
                                    ReplyPassiveMessage_Text ReplyClickText = new ReplyPassiveMessage_Text(CustomizeMenuEvent.FromUserName, CustomizeMenuEvent.ToUserName, TimeStamp, CustomizeMenuEvent.EventKey);
                                    return Content(Helper_Serializer_Xml.XmlSerializer(ReplyClickText, String.Empty, String.Empty));
                                case "subscribe":
                                    //关注事件事件
                                    ReceiveEvent_Subscribe SubscribeEvent = Helper_Serializer_Xml.XmlDeserializer<ReceiveEvent_Subscribe>(RequestContent);
                                    ReplyPassiveMessage_Text ReplySubscribeText = new ReplyPassiveMessage_Text(SubscribeEvent.FromUserName, SubscribeEvent.ToUserName, TimeStamp, "您好，欢迎关注安巨网络！");
                                    return Content(Helper_Serializer_Xml.XmlSerializer(ReplySubscribeText, String.Empty, String.Empty));
                            }
                            return Content("success");
                        default:
                            return Content("success");
                    }
                }
                else
                {
                    return Content("success");
                }
            }
            else
            {
                return Content("success");
            }
        }

        /// <summary>
        /// 接收支付结果消息
        /// </summary>
        /// <returns></returns>
        public ActionResult ReceivePayResultMessage()
        {
            string result = null;

            //接收WeChat服务器推送数据
            PayResultCode ResultCode = new PayResultCode();
            string RequestContent = null;
            using (Stream RequestStream = Request.InputStream)
            {
                StreamReader ContentReader = new StreamReader(RequestStream, Encoding.UTF8);
                RequestContent = ContentReader.ReadToEnd();
            }

            //处理接收到的数据
            if (!String.IsNullOrEmpty(RequestContent))
            {
                PayResultMessage ResultMessage = Helper_Serializer_Xml.XmlDeserializer<PayResultMessage>(RequestContent);

                //此处进行逻辑处理

                ResultCode.return_code = "SUCCESS";
                ResultCode.return_msg = "OK";
            }
            else
            {
                ResultCode.return_code = "FAIL";
                ResultCode.return_msg = "未接收到数据";
            }

            result = Helper_Serializer_Xml.XmlSerializer(ResultCode, String.Empty, String.Empty);

            return Content(result);
        }

        /// <summary>
        /// 接收退款结果消息
        /// </summary>
        /// <returns></returns>
        public ActionResult ReceiveRefundResultMessage()
        {
            string result = null;

            //接收WeChat服务器推送数据
            PayResultCode ResultCode = new PayResultCode();
            string RequestContent = null;
            using (Stream RequestStream = Request.InputStream)
            {
                StreamReader ContentReader = new StreamReader(RequestStream, Encoding.UTF8);
                RequestContent = ContentReader.ReadToEnd();
            }

            //处理接收到的数据
            if (!String.IsNullOrEmpty(RequestContent))
            {
                RefundResultMessage ResultMessage = Helper_Serializer_Xml.XmlDeserializer<RefundResultMessage>(RequestContent);
                if (0 == String.Compare("SUCCESS", ResultMessage.return_code, true))//退款成功
                {
                    //解密退款信息
                    byte[] RefundMessageBytes = Encoding.UTF8.GetBytes(ResultMessage.req_info);//进行Base64解码
                    string RefundMessage = Convert.ToBase64String(RefundMessageBytes);
                    string PayKey = WeChat_Basicinfo.PayKey;//加密支付密钥
                    IEncryptionSymmetric iEncryptionSymmetric = new Helper_Encryption_DES();
                    IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
                    PayKey = iEncryptionAsymmetric.Encryption(PayKey, MatchCaseType.Lowercase);//进行MD5加密
                    RefundMessageBytes = Encoding.UTF8.GetBytes(RefundMessage);//进行AES-256-ECB解密
                    RefundMessage = iEncryptionSymmetric.Decryption(RefundMessage, RefundMessageBytes, null, CipherMode.ECB);//进行DES解密
                    RefundResultInfo RefundInfo = Helper_Serializer_Xml.XmlDeserializer<RefundResultInfo>(RefundMessage);

                    //此处进行逻辑处理
                    BLL_Order OrderBLL = new BLL_Order();
                    Order model = OrderBLL.SelectSingleOrderByRefund(RefundInfo.out_refund_no);
                    if (null != model)
                    {
                        model.RefundWeChatOrderNumber = RefundInfo.refund_id;
                        model.Status = OrderStatusType.RefundFinish;
                        OrderBLL.UpdateSingleOrder(model.ID, model);

                        ResultCode.return_code = "SUCCESS";
                        ResultCode.return_msg = "OK";
                    }
                    else
                    {
                        ResultCode.return_code = "FAIL";
                        ResultCode.return_msg = "未查询到订单";
                    }
                }
                else//退款失败
                {
                    //错误处理

                    ResultCode.return_code = "SUCCESS";
                    ResultCode.return_msg = "OK";
                }
            }
            else
            {
                ResultCode.return_code = "FAIL";
                ResultCode.return_msg = "未接收到数据";
            }

            result = Helper_Serializer_Xml.XmlSerializer(ResultCode, String.Empty, String.Empty);

            return Content(result);
        }

        /// <summary>
        /// 获取用户OpenID
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserOpenID()
        {
            //处理错误参数
            DGError ErrorInfo = new DGError();
            if ((String.IsNullOrEmpty(WeChat_Basicinfo.AppID)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AppSecret)))
            {
                ErrorInfo.ErrorCode = "500";
                ErrorInfo.ErrorDescribe = "内部服务器错误";
                ErrorInfo.ErrorContent = "未设置WeChat基本信息，请检查是否设置了AppID、AppSecret";
                return RedirectToAction("Index", "Error", ErrorInfo);
            }
            else { }

            //请求WeChat获取OpenID
            WeChat_Web wecWeb = new WeChat_Web();
            if (String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                //获取网页授权Code
                WebAuthorization_Code CodeModel = new WebAuthorization_Code(WeChat_Basicinfo.AppID, "http://k10.iwangto.com/pay/Red.aspx", WebAuthorizationType.snsapi_base);
                string CodeUrl = wecWeb.CreateWebAuthorizationCodeUrl(CodeModel);
                return Redirect(CodeUrl);
            }
            else
            {
                //请求WeChat获取OpenID
                string Code = Request.QueryString["code"];
                var Token = wecWeb.GetWebAuthorizationAccessToken(new WebAuthorization_Token(WeChat_Basicinfo.AppID, WeChat_Basicinfo.AppSecret, Code));
                if (null == Token)
                {
                    ErrorInfo.ErrorCode = "500";
                    ErrorInfo.ErrorDescribe = "内部服务器错误";
                    ErrorInfo.ErrorContent = "获取WeChat网页授权失败";
                }
                else if (0 != Token.errcode)
                {
                    ErrorInfo.ErrorCode = "WeChat错误码：" + Token.errcode.ToString();
                    ErrorInfo.ErrorDescribe = "内部服务器错误";
                    ErrorInfo.ErrorContent = "获取WeChat网页授权失败，WeChat消息：" + Token.errmsg;
                }
                else
                {
                    return Content(Token.openid);
                }
            }

            return RedirectToAction("Index", "Error", ErrorInfo);
        }
    }
}