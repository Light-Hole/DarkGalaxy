using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收文本消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Text : ReceiveMessage_Base
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        [DataMember]
        public string Content
        {
            get;
            set;
        }
    }
}
