using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 网页授权凭证校验的Model类
    /// </summary>
    [DataContract]
    public class WebAuthorization_Verify
    {
        /// <summary>
        /// 网页授权凭证
        /// </summary>
        [DataMember]
        public string access_token;

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="token">网页授权凭证</param>
        /// <param name="openID">用户唯一标识</param>
        public WebAuthorization_Verify(string token,string openID)
        {
            access_token = token;
            openid = openID;
        }
    }
}
