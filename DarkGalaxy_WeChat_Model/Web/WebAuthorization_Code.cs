using System;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 网页授权Code的Model类
    /// </summary>
    [DataContract]
    public class WebAuthorization_Code
    {
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 授权后重定向的回调链接地址，请使用urlEncode对链接进行处理
        /// </summary>
        [DataMember]
        public string redirect_uri;

        /// <summary>
        /// 返回类型，请填写code
        /// </summary>
        [DataMember]
        public string response_type = "code";

        /// <summary>
        /// 应用授权作用域（授权类型）
        /// </summary>
        [DataMember]
        public string scope;

        /// <summary>
        /// 重定向后会带上state参数
        /// </summary>
        [DataMember]
        public string state;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众号的唯一标识</param>
        /// <param name="redirectUrl">回调链接地址</param>
        /// <param name="webAuthorizationTypes">网页授权类型</param>
        /// <param name="state">重定向state参数</param>
        public WebAuthorization_Code(string appID, string redirectUrl, WebAuthorizationType webAuthorizationTypes, string state = null)
        {
            appid = appID;
            redirectUrl = HttpUtility.UrlDecode(redirectUrl);
            redirect_uri = HttpUtility.UrlEncode(redirectUrl);
            scope = Enum.GetName(typeof(WebAuthorizationType), webAuthorizationTypes);
            if(String.IsNullOrEmpty(state))
            {
                state = "None";
            }
            else
            {
                this.state = state;
            }
        }
    }
}
