using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单事件推送消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveEvent_CustomizeMenu : ReceiveEvent_Base
    {
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
