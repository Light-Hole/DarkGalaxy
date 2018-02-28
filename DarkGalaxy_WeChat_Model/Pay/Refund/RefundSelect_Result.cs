using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付退款查询的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RefundSelect_Result : PayResultCode
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
        /// 订单总退款次数
        /// </summary>
        [DataMember]
        public int total_refund_count;

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
        /// 订单金额
        /// </summary>
        [DataMember]
        public int total_fee;

        /// <summary>
        /// 应结订单金额
        /// </summary>
        [DataMember]
        public int settlement_total_fee;

        /// <summary>
        /// 货币种类
        /// </summary>
        [DataMember]
        public string fee_type;

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [DataMember]
        public int cash_fee;

        /// <summary>
        /// 退款笔数
        /// </summary>
        [DataMember]
        public int refund_count;

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [DataMember]
        public string out_refund_no_n;

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [DataMember]
        public string refund_id_n;

        /// <summary>
        /// 退款渠道
        /// </summary>
        [DataMember]
        public string refund_channel_n;

        /// <summary>
        /// 申请退款金额
        /// </summary>
        [DataMember]
        public int refund_fee_n;

        /// <summary>
        /// 退款金额
        /// </summary>
        [DataMember]
        public int settlement_refund_fee_n;

        /// <summary>
        /// 代金券类型
        /// </summary>
        [DataMember]
        public string coupon_type_n_m;

        /// <summary>
        /// 总代金券退款金额
        /// </summary>
        [DataMember]
        public int coupon_refund_fee_n;

        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [DataMember]
        public int coupon_refund_count_n;

        /// <summary>
        /// 退款代金券ID
        /// </summary>
        [DataMember]
        public string coupon_refund_id_n_m;

        /// <summary>
        /// 单个代金券退款金额
        /// </summary>
        [DataMember]
        public int coupon_refund_fee_n_m;

        /// <summary>
        /// 退款状态
        /// </summary>
        [DataMember]
        public string refund_status_n;

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [DataMember]
        public string refund_account_n;

        /// <summary>
        /// 退款入账账户
        /// </summary>
        [DataMember]
        public string refund_recv_accout_n;

        /// <summary>
        /// 退款成功时间
        /// </summary>
        [DataMember]
        public string refund_success_time_n;
    }
}
