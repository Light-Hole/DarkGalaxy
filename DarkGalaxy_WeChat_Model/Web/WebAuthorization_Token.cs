using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 网页授权凭证的Model类
    /// </summary>
    [DataContract]
    public class WebAuthorization_Token
    {
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 公众号密钥
        /// </summary>
        [DataMember]
        public string secret;

        /// <summary>
        /// 网页授权code
        /// </summary>
        [DataMember]
        public string code;

        /// <summary>
        /// 填写为authorization_code
        /// </summary>
        [DataMember]
        public string grant_type = "authorization_code";

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众号的唯一标识</param>
        /// <param name="secret">公众号密钥</param>
        /// <param name="code">网页授权code</param>
        public WebAuthorization_Token(string appID,string secret,string code)
        {
            appid = appID;
            this.secret = secret;
            this.code = code;
        }
    }
}
