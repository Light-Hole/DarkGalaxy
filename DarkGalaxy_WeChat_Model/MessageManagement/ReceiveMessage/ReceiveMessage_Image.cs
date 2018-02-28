using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收图片消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Image : ReceiveMessage_Base
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        [DataMember]
        public string PicUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        [DataMember]
        public string MediaId
        {
            get;
            set;
        }
    }
}
