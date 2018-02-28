using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat全局唯一接口调用凭据AccessToken的Model类
    /// </summary>
    [DataContract]
    public class AccessToken : ResultCode
    {
        /// <summary>
        /// 凭证
        /// </summary>
        [DataMember]
        public string access_token;

        /// <summary>
        /// 获取到的凭证有效时间（单位：秒）
        /// </summary>
        [DataMember]
        public int expires_in;
    }
}
