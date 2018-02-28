using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat关闭订单结果的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class OrderClose_Result : PayResultCode
    {
        /// <summary>
        /// 微信开放平台审核通过的应用APPID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 微信支付分配的商户号
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
        /// 业务结果
        /// </summary>
        [DataMember]
        public string result_code;

        /// <summary>
        /// 业务结果描述
        /// </summary>
        [DataMember]
        public string result_msg;

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
    }
}
