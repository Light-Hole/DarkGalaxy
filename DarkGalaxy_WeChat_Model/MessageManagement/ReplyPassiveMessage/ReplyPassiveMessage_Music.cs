using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复音乐被动消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReplyPassiveMessage_Music : ReplyPassiveMessage_Base
    {
        /// <summary>
        /// 音乐标题
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 音乐链接
        /// </summary>
        [DataMember]
        public string MusicURL
        {
            get;
            set;
        }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        [DataMember]
        public string HQMusicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 缩略图的媒体id，通过素材管理中的接口上传多媒体文件ID
        /// </summary>
        [DataMember]
        public string ThumbMediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_Music()
        {

        }

        /// <summary>
        /// 构造函数，初始化回复被动消息类型
        /// </summary>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="fromUserName">开发者帐号</param>
        /// <param name="createTime">消息创建时间</param>
        public ReplyPassiveMessage_Music(string toUserName, string fromUserName, string createTime)
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = createTime;
            MsgType = "music";
        }
    }
}
