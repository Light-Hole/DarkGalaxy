using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单事件推送的Model类基类
    /// </summary>
    [DataContract]
    public class CustomizeMenuEvent_Base
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
        /// 事件类型
        /// </summary>
        [DataMember]
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// 事件KEY值
        /// </summary>
        [DataMember]
        public string EventKey
        {
            get;
            set;
        }
    }
}
