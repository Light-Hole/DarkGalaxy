using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收视频消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Video : ReceiveMessage_Base
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        [DataMember]
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        [DataMember]
        public string ThumbMediaId
        {
            get;
            set;
        }
    }
}
