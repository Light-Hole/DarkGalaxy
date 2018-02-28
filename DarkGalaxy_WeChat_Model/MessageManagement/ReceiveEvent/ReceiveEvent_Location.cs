using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat接收上传地理位置事件推送消息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class ReceiveEvent_Location : ReceiveEvent_Base
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        [DataMember]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        [DataMember]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        [DataMember]
        public string Precision
        {
            get;
            set;
        }
    }
}
