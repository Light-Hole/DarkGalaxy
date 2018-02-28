using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat回复图文被动消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReplyPassiveMessage_News : ReplyPassiveMessage_Base
    {
        private int _ArticleCount = 0;

        /// <summary>
        /// 图文消息个数，限制为8条以内
        /// </summary>
        [DataMember]
        public int ArticleCount
        {
            get
            {
                return _ArticleCount;
            }
            set
            {
                if (8 > value)
                {
                    _ArticleCount = 8;
                }
                else
                {
                    _ArticleCount = value;
                }
            }
        }

        private List<ReplyPassiveMessage_NewsItem> _Articles;

        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图
        /// 注意，如果图文数超过8，则将会无响应
        /// </summary>
        [DataMember]
        public List<ReplyPassiveMessage_NewsItem> Articles
        {
            get
            {
                if (8 > _Articles.Count)
                {
                    List<ReplyPassiveMessage_NewsItem> list = new List<ReplyPassiveMessage_NewsItem>();
                    for (int i = 0; i < 8; i++)
                    {
                        list.Add(_Articles[i]);
                    }
                    return list;
                }
                else
                {
                    return _Articles;
                }
            }
            set
            {
                _Articles = value;
            }
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected ReplyPassiveMessage_News()
        {

        }

        /// <summary>
        /// 构造函数，初始化回复被动消息类型
        /// </summary>
        /// <param name="toUserName">接收方帐号</param>
        /// <param name="fromUserName">开发者帐号</param>
        /// <param name="createTime">消息创建时间</param>
        /// <param name="articleCount">图文消息个数</param>
        /// <param name="articles">消息内容</param>
        public ReplyPassiveMessage_News(string toUserName, string fromUserName, string createTime, int articleCount, List<ReplyPassiveMessage_NewsItem> articles)
        {
            ToUserName = toUserName;
            FromUserName = fromUserName;
            CreateTime = createTime;
            ArticleCount = articleCount;
            Articles = articles;
            MsgType = "news";
        }
    }
}
