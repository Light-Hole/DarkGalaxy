using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat基本信息
    /// </summary>
    public class WeChat_Basicinfo
    {
        /// <summary>
        /// WeChatAPI接口链接
        /// </summary>
        public static string APIUrl
        {
            get
            {
                //查询WeChat基本信息记录
                BLL_WeChatBasicInformation BLLWeChatBasicInfo = new BLL_WeChatBasicInformation();
                var WeChatBasicInfoList = BLLWeChatBasicInfo.SelectWeChatBasicInformation();
                if (null == WeChatBasicInfoList)
                {
                    return WeChatBasicInfoList[0].APIUrl;
                }
                else
                {
                    //获取配置文件中的基本信息记录
                    return ConfigurationManager.AppSettings["APIUrl"];
                }
            }
        }

        /// <summary>
        /// WeChat开发者ID
        /// </summary>
        public static string AppID
        {
            get
            {
                //查询WeChat基本信息记录
                BLL_WeChatBasicInformation BLLWeChatBasicInfo = new BLL_WeChatBasicInformation();
                var WeChatBasicInfoList = BLLWeChatBasicInfo.SelectWeChatBasicInformation();
                if (null == WeChatBasicInfoList)
                {
                    return WeChatBasicInfoList[0].AppID;
                }
                else
                {
                    //获取配置文件中的基本信息记录
                    return ConfigurationManager.AppSettings["AppID"];
                }
            }
        }

        /// <summary>
        /// WeChat开发者密钥
        /// </summary>
        public static string AppSecret
        {
            get
            {
                //查询WeChat基本信息记录
                BLL_WeChatBasicInformation BLLWeChatBasicInfo = new BLL_WeChatBasicInformation();
                var WeChatBasicInfoList = BLLWeChatBasicInfo.SelectWeChatBasicInformation();
                if (null == WeChatBasicInfoList)
                {
                    return WeChatBasicInfoList[0].AppSecret;
                }
                else
                {
                    //获取配置文件中的基本信息记录
                    return ConfigurationManager.AppSettings["AppSecret"];
                }
            }
        }

        /// <summary>
        /// WeChatPay商户号
        /// </summary>
        public static string PayMchID
        {
            get
            {
                //查询WeChat基本信息记录
                BLL_WeChatBasicInformation BLLWeChatBasicInfo = new BLL_WeChatBasicInformation();
                var WeChatBasicInfoList = BLLWeChatBasicInfo.SelectWeChatBasicInformation();
                if (null == WeChatBasicInfoList)
                {
                    return WeChatBasicInfoList[0].PayMchID;
                }
                else
                {
                    //获取配置文件中的基本信息记录
                    return ConfigurationManager.AppSettings["PayMchID"];
                }
            }
        }

        /// <summary>
        /// WeChatPay支付密钥
        /// </summary>
        public static string PayKey
        {
            get
            {
                //查询WeChat基本信息记录
                BLL_WeChatBasicInformation BLLWeChatBasicInfo = new BLL_WeChatBasicInformation();
                var WeChatBasicInfoList = BLLWeChatBasicInfo.SelectWeChatBasicInformation();
                if (null == WeChatBasicInfoList)
                {
                    return WeChatBasicInfoList[0].PayKey;
                }
                else
                {
                    //获取配置文件中的基本信息记录
                    return ConfigurationManager.AppSettings["PayKey"];
                }
            }
        }

        /// <summary>
        /// WeChat的AccessToken
        /// </summary>
        public static AccessToken AccessToken
        {
            get
            {
                if (null == Helper_Cache.GetCache("AccessToken"))
                {
                    AccessToken wmodToken = GetAccessToken();
                    if (null == wmodToken)
                    {
                        return null;
                    }
                    else if (0 == wmodToken.errcode)
                    {
                        Helper_Cache.AddCache("AccessToken", wmodToken, DateTime.Now.AddSeconds(wmodToken.expires_in));
                        return wmodToken;
                    }
                    else
                    {
                        return wmodToken;
                    }
                }
                else
                {
                    return (AccessToken)Helper_Cache.GetCache("AccessToken");
                }
            }
        }

        /// <summary>
        /// 发送Http请求获取AccessToken，返回WeChat服务端返回的数据
        /// 发送Http请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        private static AccessToken GetAccessToken()
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(APIUrl)) || (String.IsNullOrEmpty(AppID)) || (String.IsNullOrEmpty(AppSecret)))
            {
                return null;
            }
            else { }

            AccessToken result = new AccessToken();

            //获取AccessToken请求地址
            string strUrl = APIUrl + "/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            strUrl = String.Format(strUrl, AppID, AppSecret);

            //发送Http请求，获取服务端回发数据
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<AccessToken>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取WeChatIP，返回WeChat服务端返回的数据
        /// 发送Http请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        public WeChatIP GetWeChatIP()
        {
            //处理错误参数
            if ((null == AccessToken) || (String.IsNullOrEmpty(AccessToken.access_token)))
            {
                return null;
            }
            else { }

            WeChatIP result = new WeChatIP();

            //获取WeChatIP请求地址
            string strUrl = APIUrl + "/cgi-bin/getcallbackip?access_token={0}";
            strUrl = String.Format(strUrl, AccessToken.access_token);

            //发送Http请求，获取服务端回发数据
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<WeChatIP>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 生成WeChat服务器验证签名，返回校验签名
        /// 生成失败则返回null
        /// </summary>
        /// <param name="token">凭证</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <returns>校验签名</returns>
        public string CreateServerValidationSignature(string token, string timeStamp, string nonce)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(token)) || (String.IsNullOrEmpty(timeStamp)) || (String.IsNullOrEmpty(nonce)))
            {
                return null;
            }
            else { }

            string result = null;

            //生成WeChat服务器验证签名
            string[] arrValidationArray = { token, timeStamp, nonce };
            Array.Sort(arrValidationArray);//字典排序
            string strValidation = String.Join("", arrValidationArray);//连接字符串
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_SHA1();
            result = iEncryptionAsymmetric.Encryption(strValidation, MatchCaseType.Lowercase);//进行SHA1加密

            return result;
        }
    }
}
