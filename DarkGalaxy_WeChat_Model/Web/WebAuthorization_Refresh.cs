using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 网页授权刷新凭证的Model类
    /// </summary>
    [DataContract]
    public class WebAuthorization_Refresh
    {
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 授权类型
        /// </summary>
        [DataMember]
        public string grant_type = "refresh_token";

        /// <summary>
        /// 刷新的凭证
        /// </summary>
        [DataMember]
        public string refresh_token;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众号的唯一标识</param>
        /// <param name="refreshToken">刷新的凭证</param>
        public WebAuthorization_Refresh(string appID,string refreshToken)
        {
            appid = appID;
            refresh_token = refreshToken;
        }
    }
}
