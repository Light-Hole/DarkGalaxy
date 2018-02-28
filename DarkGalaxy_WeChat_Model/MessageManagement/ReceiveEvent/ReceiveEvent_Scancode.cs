using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收带参数二维码扫码事件推送消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveEvent_Scancode : ReceiveEvent_Base
    {
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        [DataMember]
        public string EventKey
        {
            get;
            set;
        }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        [DataMember]
        public string Ticket
        {
            get;
            set;
        }
    }
}
