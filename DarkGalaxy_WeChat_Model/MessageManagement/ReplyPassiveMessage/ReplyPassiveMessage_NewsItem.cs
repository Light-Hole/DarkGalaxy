using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复图片被动消息内容的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "item")]
    public class ReplyPassiveMessage_NewsItem : ReplyPassiveMessage_Base
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 图文消息描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 图片链接，支持JPG、PNG格式
        /// 较好的效果为大图360*200，小图200*200
        /// </summary>
        [DataMember]
        public string PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        [DataMember]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_NewsItem()
        {

        }

        /// <summary>
        /// 构造函数，初始化图文消息
        /// </summary>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="fromUserName">开发者帐号</param>
        /// <param name="createTime">消息创建时间</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="picUrl">图片地址</param>
        /// <param name="url">图文跳转地址</param>
        public ReplyPassiveMessage_NewsItem(string toUserName, string fromUserName, string createTime, string title, string description, string picUrl, string url)
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = createTime;
            Title = title;
            Description = description;
            PicUrl = picUrl;
            Url = url;
        }
    }
}
