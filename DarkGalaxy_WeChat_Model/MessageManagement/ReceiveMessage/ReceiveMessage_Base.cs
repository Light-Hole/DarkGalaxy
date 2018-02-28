using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收消息的Model类基类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Base
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [DataMember]
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 发送方帐号（OpenID）
        /// </summary>
        [DataMember]
        public string FromUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 消息创建时间（时间戳）
        /// </summary>
        [DataMember]
        public string CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember]
        public string MsgType
        {
            get;
            set;
        }

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        [DataMember]
        public string MsgId
        {
            get;
            set;
        }
    }
}
