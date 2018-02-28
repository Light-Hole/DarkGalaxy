using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat退款结果通知的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RefundResultMessage : PayResultCode
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 退款的商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember]
        public string nonce_str;

        /// <summary>
        /// 加密信息
        /// </summary>
        [DataMember]
        public string req_info;
    }
}
