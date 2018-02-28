using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat服务器IP地址的Model类
    /// </summary>
    [DataContract]
    public class WeChatIP : ResultCode
    {
        /// <summary>
        /// WeChat服务器IP列表
        /// </summary>
        [DataMember]
        public string[] ip_list;
    }
}
