using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复文本被动消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReplyPassiveMessage_Text : ReplyPassiveMessage_Base
    {
        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
        /// </summary>
        [DataMember]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_Text()
        {

        }

        /// <summary>
        /// 构造函数，初始化回复被动消息类型
        /// </summary>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="fromUserName">开发者帐号</param>
        /// <param name="createTime">消息创建时间</param>
        /// <param name="content">消息内容</param>
        public ReplyPassiveMessage_Text(string toUserName,string fromUserName, string createTime,string content)
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = createTime;
            Content = content;
            MsgType = "text";
        }
    }
}
