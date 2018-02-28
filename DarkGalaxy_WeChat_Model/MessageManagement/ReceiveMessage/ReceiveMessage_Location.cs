using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收地理位置消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveMessage_Location : ReceiveMessage_Base
    {
        /// <summary>
        /// 地理位置维度
        /// </summary>
        [DataMember]
        public string Location_X
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        [DataMember]
        public string Location_Y
        {
            get;
            set;
        }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        [DataMember]
        public string Scale
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        [DataMember]
        public string Label
        {
            get;
            set;
        }
    }
}
