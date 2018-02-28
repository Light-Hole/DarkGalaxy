using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付退款的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class Refund
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
        /// 订单金额
        /// </summary>
        [DataMember]
        public int total_fee;

        /// <summary>
        /// 退款金额
        /// </summary>
        [DataMember]
        public int refund_fee;

        /// <summary>
        /// 货币种类
        /// </summary>
        [DataMember]
        public string refund_fee_type;

        /// <summary>
        /// 退款原因
        /// </summary>
        [DataMember]
        public string refund_desc;

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [DataMember]
        public string refund_account;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected Refund()
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
        /// <param name="refundNumber">退款订单号</param>
        /// <param name="money">订单金额</param>
        /// <param name="refundMoney">退款金额</param>
        /// <param name="signatureTypes">签名类型</param>
        public Refund(string appID, string mchID, string nonceStr, PayOrderNumberType orderNumberTypes, string orderNumber, string refundNumber, int money, int refundMoney, PaySignatureType signatureTypes = PaySignatureType.MD5)
        {
            appid = appID;
            mch_id = mchID;
            sign_type = Enum.GetName(typeof(PaySignatureType), signatureTypes);
            out_refund_no = refundNumber;
            total_fee = money;
            refund_fee = refundMoney;

            //设置订单号类型
            if (PayOrderNumberType.WeChat == orderNumberTypes)
            {
                transaction_id = orderNumber;
            }
            else if (PayOrderNumberType.Merchant == orderNumberTypes)
            {
                out_trade_no = orderNumber;
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
