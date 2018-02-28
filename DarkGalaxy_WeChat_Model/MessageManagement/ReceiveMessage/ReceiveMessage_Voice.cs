using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收语音、语音识别消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Voice : ReceiveMessage_Base
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        [DataMember]
        public string MediaId
        {
            get;
            set;
        }

        /// <summary>
        /// 语音格式
        /// </summary>
        [DataMember]
        public string Format
        {
            get;
            set;
        }

        /// <summary>
        /// 语音识别结果
        /// </summary>
        [DataMember]
        public string Recognition
        {
            get;
            set;
        }
    }
}
