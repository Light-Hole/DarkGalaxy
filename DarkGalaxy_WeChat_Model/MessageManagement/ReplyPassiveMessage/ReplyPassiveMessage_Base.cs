using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复被动消息的Model类基类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReplyPassiveMessage_Base
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        [DataMember]
        public string ToUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 开发者微信号
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
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_Base()
        {

        }
    }
}
