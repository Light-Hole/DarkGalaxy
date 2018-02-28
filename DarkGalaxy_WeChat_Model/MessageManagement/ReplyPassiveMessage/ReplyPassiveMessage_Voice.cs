using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复语音被动消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReplyPassiveMessage_Voice : ReplyPassiveMessage_Base
    {
        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件ID
        /// </summary>
        [DataMember]
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_Voice()
        {

        }

        /// <summary>
        /// 构造函数，初始化回复被动消息类型
        /// </summary>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="fromUserName">开发者帐号</param>
        /// <param name="createTime">消息创建时间</param>
        /// <param name="mediaId">媒体文件ID</param>
        public ReplyPassiveMessage_Voice(string toUserName, string fromUserName, string createTime, string mediaId)
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = createTime;
            MediaId = mediaId;
            MsgType = "voice";
        }
    }
}
