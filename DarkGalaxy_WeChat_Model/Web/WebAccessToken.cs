using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 网页授权凭证的Model类
    /// </summary>
    [DataContract]
    public class WebAccessToken : ResultCode
    {
        /// <summary>
        /// 凭证
        /// </summary>
        [DataMember]
        public string access_token;

        /// <summary>
        /// 凭证超时时间（单位：秒）
        /// </summary>
        [DataMember]
        public int expires_in;

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        [DataMember]
        public string refresh_token;

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 授权作用域
        /// </summary>
        [DataMember]
        public string scope;
    }
}
