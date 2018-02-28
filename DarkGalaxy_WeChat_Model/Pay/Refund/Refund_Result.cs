using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付退款结果的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class Refund_Result : PayResultCode
    {
        /// <summary>
        /// 业务结果
        /// </summary>
        [DataMember]
        public string result_code;

        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public string err_code;

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [DataMember]
        public string err_code_des;

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
        /// 退款金额
        /// </summary>
        [DataMember]
        public int refund_fee;

        /// <summary>
        /// 应结退款金额
        /// </summary>
        [DataMember]
        public int settlement_refund_fee;

        /// <summary>
        /// 标价金额
        /// </summary>
        [DataMember]
        public int total_fee;

        /// <summary>
        /// 应结订单金额
        /// </summary>
        [DataMember]
        public int settlement_total_fee;

        /// <summary>
        /// 标价币种
        /// </summary>
        [DataMember]
        public string fee_type;

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [DataMember]
        public int cash_fee;

        /// <summary>
        /// 现金支付币种
        /// </summary>
        [DataMember]
        public string cash_fee_type;

        /// <summary>
        /// 现金退款金额
        /// </summary>
        [DataMember]
        public int cash_refund_fee;

        /// <summary>
        /// 代金券类型
        /// </summary>
        [DataMember]
        public string coupon_type_n;

        /// <summary>
        /// 代金券退款总金额
        /// </summary>
        [DataMember]
        public int coupon_refund_fee;

        /// <summary>
        /// 单个代金券退款金额
        /// </summary>
        [DataMember]
        public int coupon_refund_fee_n;

        /// <summary>
        /// 现金退款金额
        /// </summary>
        [DataMember]
        public int coupon_refund_count;

        /// <summary>
        /// 退款代金券ID
        /// </summary>
        [DataMember]
        public string coupon_refund_id_n;
    }
}
