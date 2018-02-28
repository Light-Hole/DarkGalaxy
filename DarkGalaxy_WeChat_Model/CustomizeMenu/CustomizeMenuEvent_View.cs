using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单跳转链接事件推送的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenuEvent_View : CustomizeMenuEvent_Base
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [DataMember]
        public string MenuID
        {
            get;
            set;
        }
    }
}
