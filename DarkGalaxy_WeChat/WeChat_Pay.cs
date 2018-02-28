using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat支付
    /// 提供一系列对于WeChat支付的操作
    /// </summary>
    public class WeChat_Pay
    {
        /// <summary>
        /// 发送Http请求统一下单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="unifiedOrderModel">统一下单</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public UnifiedOrder_Result UnifiedOrder(UnifiedOrder unifiedOrderModel)
        {
            //处理错误参数
            if (null == unifiedOrderModel)
            {
                return null;
            }
            else { }

            UnifiedOrder_Result result = new UnifiedOrder_Result();

            //发送统一下单请求
            string strUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(unifiedOrderModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Xml.XmlDeserializer<UnifiedOrder_Result>(strResponseContent);

            return result;

        }

        /// <summary>
        /// 发送Http请求查询订单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="orderSelectModel">订单查询</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public OrderSelect_Result SelectOrder(OrderSelect orderSelectModel)
        {
            //处理错误参数
            if (null == orderSelectModel)
            {
                return null;
            }
            else { }

            OrderSelect_Result result = new OrderSelect_Result();

            //查询订单
            string strUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(orderSelectModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Xml.XmlDeserializer<OrderSelect_Result>(strResponseContent);

            return result;

        }

        /// <summary>
        /// 发送Http请求关闭订单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="orderCloseModel">订单关闭</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public OrderClose_Result CloseOrder(OrderClose orderCloseModel)
        {
            //处理错误参数
            if (null == orderCloseModel)
            {
                return null;
            }
            else { }

            OrderClose_Result result = new OrderClose_Result();

            //关闭订单
            string strUrl = "https://api.mch.weixin.qq.com/pay/closeorder";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(orderCloseModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Xml.XmlDeserializer<OrderClose_Result>(strResponseContent);

            return result;

        }

        /// <summary>
        /// 发送Http请求申请退款，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="refundModel">退款</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public Refund_Result ApplyRefund(Refund refundModel)
        {
            //处理错误参数
            if (null == refundModel)
            {
                return null;
            }
            else { }

            Refund_Result result = new Refund_Result();

            //申请退款
            string strUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(refundModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Xml.XmlDeserializer<Refund_Result>(strResponseContent);

            return result;

        }

        /// <summary>
        /// 发送Http请求查询退款，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="refundSelectModel">退款查询</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public RefundSelect_Result SelectRefund(RefundSelect refundSelectModel)
        {
            //处理错误参数
            if (null == refundSelectModel)
            {
                return null;
            }
            else { }

            RefundSelect_Result result = new RefundSelect_Result();

            //查询退款
            string strUrl = "https://api.mch.weixin.qq.com/pay/refundquery";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(refundSelectModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Xml.XmlDeserializer<RefundSelect_Result>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 生成WeChatPay签名，返回WeChatPay签名
        /// 生成失败则返回null
        /// </summary>
        /// <typeparam name="T">生成签名对象类型</typeparam>
        /// <param name="genericsObject">生成签名原始对象</param>
        /// <param name="payKey">WeChatPay支付密钥</param>
        /// <param name="signatureTypes">签名类型</param>
        /// <returns>WeChatPay签名</returns>
        public string CreatePaySignature<T>(T genericsObject, string payKey, PaySignatureType signatureTypes)
        {
            //处理错误参数
            if ((null == genericsObject) || (String.IsNullOrEmpty(payKey)))
            {
                return null;
            }
            else { }

            string result = null;

            //签名数据集合
            Dictionary<string, string> dicSignatureDatas = new Dictionary<string, string>();
            FieldInfo[] arrFieldInfo = typeof(T).GetFields();//获取泛型类型全部公有字段
            foreach (FieldInfo temp in arrFieldInfo)
            {
                //设置签名数据集合
                object objFieldValue = temp.GetValue(genericsObject);
                if ((null != objFieldValue) && (false == String.IsNullOrEmpty(objFieldValue.ToString())))
                {
                    dicSignatureDatas.Add(temp.Name, objFieldValue.ToString());
                }
                else { }
            }

            //生成签名字符串
            string strSignature = null;
            IEncryptionAsymmetric iEncryptionAsymmetric = null;
            var SignatureSort = from Data in dicSignatureDatas orderby Data.Key select Data;
            foreach (var temp in SignatureSort)
            {
                strSignature += (temp.Key + "=" + temp.Value + "&");
            }
            strSignature += ("key=" + payKey);
            if (PaySignatureType.MD5 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_MD5();
            }
            else if (PaySignatureType.SHA1 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_SHA1();
            }
            else { }
            result = iEncryptionAsymmetric.Encryption(strSignature, MatchCaseType.Uppercase);

            return result;
        }

        /// <summary>
        /// 发送Http请求发放普通红包，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="redPacketModel">普通红包</param>
        /// <param name="certificateaPath">安全证书路径</param>
        /// <param name="certificateaPassword">安全证书密码</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public RedPacket_Result GrantRedPacket(RedPacket redPacketModel, string certificateaPath, string certificateaPassword)
        {
            //处理错误参数
            if ((null == redPacketModel) || (String.IsNullOrEmpty(certificateaPath)) || (String.IsNullOrEmpty(certificateaPassword)))
            {
                return null;
            }
            else { }

            RedPacket_Result result = null;

            //发放普通红包
            string strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(redPacketModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, certificateaPath, certificateaPassword, strRequestContent);
            if (!String.IsNullOrEmpty(strResponseContent))
            {
                result = Helper_Serializer_Xml.XmlDeserializer<RedPacket_Result>(strResponseContent);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 发送Http请求发放裂变红包，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="fissionRedPacketModel">裂变红包</param>
        /// <param name="certificateaPath">安全证书路径</param>
        /// <param name="certificateaPassword">安全证书密码</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public RedPacket_Result GrantFissionRedPacket(FissionRedPacket fissionRedPacketModel, string certificateaPath, string certificateaPassword)
        {
            //处理错误参数
            if ((null == fissionRedPacketModel) || (String.IsNullOrEmpty(certificateaPath)) || (String.IsNullOrEmpty(certificateaPassword)))
            {
                return null;
            }
            else { }

            RedPacket_Result result = null;

            //发放裂变红包
            string strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendgroupredpack";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(fissionRedPacketModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, certificateaPath, certificateaPassword, strRequestContent);
            if (!String.IsNullOrEmpty(strResponseContent))
            {
                result = Helper_Serializer_Xml.XmlDeserializer<RedPacket_Result>(strResponseContent);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 发送Http请求查询红包记录，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="redPacketSelectModel">查询红包</param>
        /// <param name="certificateaPath">安全证书路径</param>
        /// <param name="certificateaPassword">安全证书密码</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public RedPacketRecord_Result SelectRedPacketRecord(RedPacketSelect redPacketSelectModel, string certificateaPath, string certificateaPassword)
        {
            //处理错误参数
            if ((null == redPacketSelectModel) || (String.IsNullOrEmpty(certificateaPath)) || (String.IsNullOrEmpty(certificateaPassword)))
            {
                return null;
            }
            else { }

            RedPacketRecord_Result result = null;

            //查询红包记录
            string strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gethbinfo";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(redPacketSelectModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, certificateaPath, certificateaPassword, strRequestContent);
            if (!String.IsNullOrEmpty(strResponseContent))
            {
                result = Helper_Serializer_Xml.XmlDeserializer<RedPacketRecord_Result>(strResponseContent);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 发送Http请求企业付款到零钱，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="enterpriseModel">企业付款</param>
        /// <param name="certificateaPath">安全证书路径</param>
        /// <param name="certificateaPassword">安全证书密码</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public EnterprisePocket_Result SendEnterprisePocketPayer(EnterprisePocket enterpriseModel, string certificateaPath, string certificateaPassword)
        {
            //处理错误参数
            if ((null == enterpriseModel) || (String.IsNullOrEmpty(certificateaPath)) || (String.IsNullOrEmpty(certificateaPassword)))
            {
                return null;
            }
            else { }

            EnterprisePocket_Result result = null;

            //请求企业付款
            string strUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            string strRequestContent = Helper_Serializer_Xml.XmlSerializer(enterpriseModel, String.Empty, String.Empty);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, certificateaPath, certificateaPassword, strRequestContent);
            if (!String.IsNullOrEmpty(strResponseContent))
            {
                result = Helper_Serializer_Xml.XmlDeserializer<EnterprisePocket_Result>(strResponseContent);
            }
            else { }

            return result;
        }
    }
}
