using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat发放红包结果的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RedPacket_Result : PayResultCode
    {
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
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string mch_billno;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 用户OpenID
        /// </summary>
        [DataMember]
        public string re_openid;

        /// <summary>
        /// 付款金额（单位：分）
        /// </summary>
        [DataMember]
        public int total_amount;

        /// <summary>
        /// 微信单号
        /// </summary>
        [DataMember]
        public string send_listid;
    }
}
