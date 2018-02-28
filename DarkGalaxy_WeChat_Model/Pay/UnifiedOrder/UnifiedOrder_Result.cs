using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付统一下单结果的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class UnifiedOrder_Result : PayResultCode
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
        /// 交易类型
        /// </summary>
        [DataMember]
        public string trade_type;

        /// <summary>
        /// 预支付交易会话标识
        /// </summary>
        [DataMember]
        public string prepay_id;

        /// <summary>
        /// 二维码链接
        /// </summary>
        [DataMember]
        public string code_url;
    }
}
