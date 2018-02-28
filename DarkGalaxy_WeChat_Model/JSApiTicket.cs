using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat全局JS-SDK接口调用凭证JSApiTicket的Model类
    /// </summary>
    [DataContract]
    public class JSApiTicket : ResultCode
    {
        /// <summary>
        /// 凭证
        /// </summary>
        [DataMember]
        public string ticket;

        /// <summary>
        /// 获取到的凭证有效时间（单位：秒）
        /// </summary>
        [DataMember]
        public int expires_in;
    }
}
