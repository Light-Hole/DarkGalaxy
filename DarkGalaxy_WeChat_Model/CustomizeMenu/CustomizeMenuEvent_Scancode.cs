using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单扫码事件推送的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenuEvent_Scancode : CustomizeMenuEvent_Base
    {
        /// <summary>
        /// 扫描信息
        /// </summary>
        [DataMember]
        public string ScanCodeInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 扫描类型
        /// </summary>
        [DataMember]
        public string ScanType
        {
            get;
            set;
        }

        /// <summary>
        /// 扫描结果
        /// </summary>
        [DataMember]
        public string ScanResult
        {
            get;
            set;
        }
    }
}
