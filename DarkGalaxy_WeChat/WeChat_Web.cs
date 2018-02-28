using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat_Model;
using System;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat网页
    /// 提供一系列对于WeChat网页授权的操作
    /// </summary>
    public class WeChat_Web
    {
        /// <summary>
        /// 生成获取网页授权Code的Url，返回获取网页授权Code的Url
        /// 生成失败则返回null
        /// </summary>
        /// <param name="codeModel">授权Code信息</param>
        /// <returns>获取网页授权Code的Url</returns>
        public string CreateWebAuthorizationCodeUrl(WebAuthorization_Code codeModel)
        {
            //处理错误参数
            if (null == codeModel)
            {
                return null;
            }
            else { }

            string result = null;

            //生成获取网页授权Code的Url
            string strUrl = @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect";
            result = String.Format(strUrl, codeModel.appid, codeModel.redirect_uri, codeModel.response_type, codeModel.scope, codeModel.state);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取网页授权凭证，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="tokenModel">授权凭证信息</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public WebAccessToken GetWebAuthorizationAccessToken(WebAuthorization_Token tokenModel)
        {
            //处理错误参数
            if (null == tokenModel)
            {
                return null;
            }
            else { }

            WebAccessToken result = null;

            //生成获取网页授权凭证的Url
            string strUrl = @"https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}";
            strUrl = String.Format(strUrl, tokenModel.appid, tokenModel.secret, tokenModel.code, tokenModel.grant_type);

            //获取网页授权凭证
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(tokenModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<WebAccessToken>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求刷新网页授权凭证，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="refreshModel">刷新凭证信息</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public WebAccessToken RefreshWebAuthorizationAccessToken(WebAuthorization_Refresh refreshModel)
        {
            //处理错误参数
            if (null == refreshModel)
            {
                return null;
            }
            else { }

            WebAccessToken result = null;

            //生成刷新网页授权凭证的Url
            string strUrl = @"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type={1}&refresh_token={2}";
            strUrl = String.Format(strUrl, refreshModel.appid, refreshModel.grant_type, refreshModel.refresh_token);

            //刷新网页授权凭证
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(refreshModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<WebAccessToken>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求校验网页授权凭证，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="verifyModel">校验凭证信息</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode VerifyWebAuthorizationAccessToken(WebAuthorization_Verify verifyModel)
        {
            //处理错误参数
            if (null == verifyModel)
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //生成校验网页授权凭证的Url
            string strUrl = @"https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}&lang=zh_CN";
            strUrl = String.Format(strUrl, verifyModel.access_token, verifyModel.openid);

            //校验网页授权凭证
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(verifyModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }
    }
}
