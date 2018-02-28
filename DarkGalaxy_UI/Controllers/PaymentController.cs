using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using DarkGalaxy_UI.Models;
using DarkGalaxy_WeChat;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    [Login]
    public class PaymentController : Controller
    {
        [HttpPost]
        public ActionResult WeChatPay(int orderID, string callbackUrl)
        {
            DGResultData<WeChatJSPayViewModel> result = new DGResultData<WeChatJSPayViewModel>();

            //处理错误参数
            if ((String.IsNullOrEmpty(WeChat_Basicinfo.AppID)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AppSecret)) || (String.IsNullOrEmpty(WeChat_Basicinfo.PayKey)) || (String.IsNullOrEmpty(WeChat_Basicinfo.PayMchID)))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "WeChat参数错误";
                return Json(result);
            }
            else if (String.IsNullOrEmpty(callbackUrl))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "WeChat回调URL错误";
                return Json(result);
            }
            else { }

            //查询订单信息，获取OpenID
            string strOpenid = Request.Cookies["UserAccount"].Values.Get("OpenID");
            BLL_Order bllOrder = new BLL_Order();
            Order modOrder = bllOrder.SelectSingleOrder(orderID);

            //WeChat支付
            if ((!String.IsNullOrEmpty(strOpenid)) && (null != modOrder))
            {
                WeChatJSPayViewModel vmodJSPay = new WeChatJSPayViewModel();

                //设置基本参数
                string strUrl = Request.Url.ToString();//通知地址
                string strIPAddress = Request.ServerVariables["LOCAL_ADDR"];//IP地址
                string strTimeStamp = Helper_Time.CreateTimeStamp(DateTime.UtcNow, new DateTime(1970, 1, 1, 0, 0, 0, 0));//时间戳
                string strNonceStr = Guid.NewGuid().ToString().Replace("-", "");//随机字符串

                //请求WeChat支付统一下单
                WeChat_Pay wechPay = new WeChat_Pay();
                UnifiedOrder wmodUnifiedOrder = new UnifiedOrder(WeChat_Basicinfo.AppID, WeChat_Basicinfo.PayMchID, strNonceStr, "支付", modOrder.OrderNumber, modOrder.ActualPrice, strIPAddress, callbackUrl, PayType.JSAPI, strOpenid);
                wmodUnifiedOrder.sign = wechPay.CreatePaySignature(wmodUnifiedOrder, WeChat_Basicinfo.PayKey, PaySignatureType.MD5);
                UnifiedOrder_Result wmodUnifiedOrderResult = wechPay.UnifiedOrder(wmodUnifiedOrder);
                if (null == wmodUnifiedOrderResult)
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "WeChat统一下单请求失败";
                }
                else if (("SUCCESS" != wmodUnifiedOrderResult.return_code) || ("SUCCESS" != wmodUnifiedOrderResult.result_code))
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "WeChat状态码：" + wmodUnifiedOrderResult.return_code + "/WeChat返回消息" + wmodUnifiedOrderResult.return_msg + "/WeChat错误码：" + wmodUnifiedOrderResult.err_code + "/WeChat错误描述：" + wmodUnifiedOrderResult.err_code_des;
                }
                else
                {
                    //设置JS-SDK配置文件
                    WeChat_JSSDK wecJSSDK = new WeChat_JSSDK();
                    JSApiConfig wmodJSApiConfig = new JSApiConfig(WeChat_Basicinfo.AppID, strTimeStamp, strNonceStr, new JSApiType[] { JSApiType.chooseWXPay })
                    {
                        signature = wecJSSDK.CreateJsApiSignature(strUrl, strNonceStr, strTimeStamp)//创建JsApi签名
                    };

                    //设置预支付参数
                    JSPay wmodJSPay = new JSPay(WeChat_Basicinfo.AppID, strTimeStamp, Guid.NewGuid().ToString().Replace("-", ""), wmodUnifiedOrderResult.prepay_id, PaySignatureType.MD5);
                    wmodJSPay.paySign = wechPay.CreatePaySignature(wmodJSPay, WeChat_Basicinfo.PayKey, PaySignatureType.MD5);

                    //设置ViewModel
                    vmodJSPay.JSConfigModel = wmodJSApiConfig;
                    vmodJSPay.JSPayModel = wmodJSPay;
                    vmodJSPay.OrderTotal = modOrder.ActualPrice;

                    //设置返回值
                    result.Data = vmodJSPay;
                    result.Total = 1;
                }
            }
            else { }

            //处理返回值
            if (null != result.Data)
            {
                //设置返回消息
                result.Code = ResultCodeType.Succeed;
                result.Message = "结果正确";
            }
            else { }

            return Json(result);
        }

        public ActionResult WeChatPayResult()
        {
            string result = null;

            //接收WeChat服务器推送数据
            string strRequestContent = null;
            PayResultCode wmodResultCode = new PayResultCode();
            using (Stream strmRequest = Request.InputStream)
            {
                StreamReader strmContentReader = new StreamReader(strmRequest, Encoding.UTF8);
                strRequestContent = strmContentReader.ReadToEnd();
            }

            //处理接收到的数据
            if (!String.IsNullOrEmpty(strRequestContent))
            {
                PayResultMessage ResultMessage = Helper_Serializer_Xml.XmlDeserializer<PayResultMessage>(strRequestContent);

                //查询订单记录，修改订单状态
                BLL_Order bllOrder = new BLL_Order();
                Order modOrder = bllOrder.SelectSingleOrderByNumber(ResultMessage.out_trade_no);
                if (null != modOrder)
                {
                    //修改订单状态
                    if (bllOrder.UpdateOrderStatus(modOrder.ID, OrderStatusType.Pay))
                    {
                        wmodResultCode.return_code = "SUCCESS";
                        wmodResultCode.return_msg = "OK";
                    }
                    else
                    {
                        wmodResultCode.return_code = "FAIL";
                        wmodResultCode.return_msg = "修改订单状态失败";
                    }
                }
                else
                {
                    wmodResultCode.return_code = "FAIL";
                    wmodResultCode.return_msg = "未找到订单";
                }
            }
            else
            {
                wmodResultCode.return_code = "FAIL";
                wmodResultCode.return_msg = "未接收到数据";
            }
            result = Helper_Serializer_Xml.XmlSerializer(wmodResultCode, String.Empty, String.Empty);

            return Content(result);
        }
    }
}