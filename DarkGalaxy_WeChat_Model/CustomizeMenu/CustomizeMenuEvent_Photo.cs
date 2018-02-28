using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单图片相关事件推送的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenuEvent_Photo : CustomizeMenuEvent_Base
    {
        /// <summary>
        /// 图片信息
        /// </summary>
        [DataMember]
        public string SendPicsInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 图片数量
        /// </summary>
        [DataMember]
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// 图片列表
        /// </summary>
        [DataMember]
        public string PicList
        {
            get;
            set;
        }

        /// <summary>
        /// 图片MD5值
        /// </summary>
        [DataMember]
        public string PicMd5Sum
        {
            get;
            set;
        }
    }
}
