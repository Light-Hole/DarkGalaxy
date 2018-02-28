﻿using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付退款查询的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RefundSelect
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember]
        public string nonce_str;

        /// <summary>
        /// 签名
        /// </summary>
        [DataMember]
        public string sign;

        /// <summary>
        /// 签名类型
        /// </summary>
        [DataMember]
        public string sign_type;

        /// <summary>
        /// 微信订单号
        /// </summary>
        [DataMember]
        public string transaction_id;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string out_trade_no;

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [DataMember]
        public string out_refund_no;

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [DataMember]
        public string refund_id;

        /// <summary>
        /// 偏移量
        /// </summary>
        [DataMember]
        public int offset;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected RefundSelect()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="orderNumberTypes">订单号类型</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="signatureTypes">签名类型</param>
        public RefundSelect(string appID, string mchID, string nonceStr, RefundOrderNumberType orderNumberTypes, string orderNumber, PaySignatureType signatureTypes = PaySignatureType.MD5)
        {
            appid = appID;
            mch_id = mchID;
            sign_type = Enum.GetName(typeof(PaySignatureType), signatureTypes);

            //设置订单号类型
            if (RefundOrderNumberType.WeChat == orderNumberTypes)
            {
                transaction_id = orderNumber;
            }
            else if (RefundOrderNumberType.Merchant == orderNumberTypes)
            {
                out_trade_no = orderNumber;
            }
            else if (RefundOrderNumberType.WeChatRefund == orderNumberTypes)
            {
                refund_id = orderNumber;
            }
            else if (RefundOrderNumberType.MerchantRefund == orderNumberTypes)
            {
                out_refund_no = orderNumber;
            }
            else { }

            //设置随机字符串
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
        }
    }
}
