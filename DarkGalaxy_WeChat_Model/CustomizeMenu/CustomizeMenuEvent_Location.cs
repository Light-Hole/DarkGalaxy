using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单地理位置事件推送的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenuEvent_Location : CustomizeMenuEvent_Base
    {
        /// <summary>
        /// 位置信息
        /// </summary>
        [DataMember]
        public string SendLocationInfo
        {
            get;
            set;
        }

        /// <summary>
        /// X坐标信息
        /// </summary>
        [DataMember]
        public string Location_X
        {
            get;
            set;
        }

        /// <summary>
        /// Y坐标信息
        /// </summary>
        [DataMember]
        public string Location_Y
        {
            get;
            set;
        }

        /// <summary>
        /// 精度
        /// </summary>
        [DataMember]
        public string Scale
        {
            get;
            set;
        }

        /// <summary>
        /// 地理位置字符串信息
        /// </summary>
        [DataMember]
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// 朋友圈POI的名字
        /// </summary>
        [DataMember]
        public string Poiname
        {
            get;
            set;
        }
    }
}
