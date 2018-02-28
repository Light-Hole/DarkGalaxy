using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付结果通知的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class PayResultMessage : PayResultCode
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
        /// 设备号
        /// </summary>
        [DataMember]
        public string device_info;

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
        /// 用户标识
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 是否关注公众账号
        /// </summary>
        [DataMember]
        public string is_subscribe;

        /// <summary>
        /// 交易类型
        /// </summary>
        [DataMember]
        public string trade_type;

        /// <summary>
        /// 付款银行
        /// </summary>
        [DataMember]
        public string bank_type;

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
        /// 现金支付货币类型
        /// </summary>
        [DataMember]
        public string cash_fee_type;

        /// <summary>
        /// 总代金券金额
        /// </summary>
        [DataMember]
        public int coupon_fee;

        /// <summary>
        /// 代金券使用数量
        /// </summary>
        [DataMember]
        public int coupon_count;

        /// <summary>
        /// 代金券类型
        /// </summary>
        [DataMember]
        public string coupon_type_n;

        /// <summary>
        /// 代金券ID
        /// </summary>
        [DataMember]
        public string coupon_id_n;

        /// <summary>
        /// 单个代金券支付金额
        /// </summary>
        [DataMember]
        public int coupon_fee_n;

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [DataMember]
        public string transaction_id;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string out_trade_no;

        /// <summary>
        /// 商家数据包
        /// </summary>
        [DataMember]
        public string attach;

        /// <summary>
        /// 支付完成时间
        /// </summary>
        [DataMember]
        public string time_end;
    }
}
