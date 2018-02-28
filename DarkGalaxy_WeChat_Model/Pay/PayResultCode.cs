using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付结果的Model类基类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class PayResultCode
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        [DataMember]
        public string return_code;

        /// <summary>
        /// 返回信息
        /// </summary>
        [DataMember]
        public string return_msg;
    }
}
