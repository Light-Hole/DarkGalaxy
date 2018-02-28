using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat企业支付到零钱结果的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class EnterprisePocket_Result : PayResultCode
    {
        /// <summary>
        /// 商户appid
        /// </summary>
        [DataMember]
        public string mch_appid;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mchid;

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
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string partner_trade_no;

        /// <summary>
        /// 微信订单号
        /// </summary>
        [DataMember]
        public string payment_no;

        /// <summary>
        /// 微信支付成功时间
        /// </summary>
        [DataMember]
        public string payment_time;
    }
}
