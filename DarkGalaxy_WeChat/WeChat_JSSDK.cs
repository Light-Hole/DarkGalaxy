using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat的JS-SDK
    /// 提供一系列对于JS-SDK的操作
    /// </summary>
    public class WeChat_JSSDK
    {
        /// <summary>
        /// WeChat的JSApiTicket
        /// </summary>
        public static JSApiTicket JSApiTicket
        {
            get
            {
                if (null == Helper_Cache.GetCache("JSApiTicket"))
                {
                    JSApiTicket wmodTicket = GetJSApiTicket();
                    if (null == wmodTicket)
                    {
                        return null;
                    }
                    else if (0 == wmodTicket.errcode)
                    {
                        Helper_Cache.AddCache("JSApiTicket", wmodTicket, DateTime.Now.AddSeconds(wmodTicket.expires_in));
                        return wmodTicket;
                    }
                    else
                    {
                        return wmodTicket;
                    }
                }
                else
                {
                    return (JSApiTicket)Helper_Cache.GetCache("JSApiTicket");
                }
            }
        }

        /// <summary>
        /// 发送Http请求获取JSApiTicket，返回WeChat服务端返回的数据
        /// 发送Http请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        private static JSApiTicket GetJSApiTicket()
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            JSApiTicket result = new JSApiTicket();

            //获取JSApiTicket请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //发送Http请求，获取服务端回发数据
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<JSApiTicket>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 生成JSPay签名，返回JSPay签名
        /// 生成失败则返回null
        /// </summary>
        /// <typeparam name="T">生成签名对象类型</typeparam>
        /// <param name="genericsObject">生成签名原始对象</param>
        /// <param name="signatureTypes">签名类型</param>
        /// <returns>JSPay签名</returns>
        public string CreateJSPaySignature<T>(T genericsObject, PaySignatureType signatureTypes)
        {
            //处理错误参数
            if (null == genericsObject)
            {
                return null;
            }
            else { }

            string result = null;

            //签名数据集合
            Dictionary<string, string> dicSignatureDatas = new Dictionary<string, string>();
            FieldInfo[] arrFieldInfo = typeof(T).GetFields(); ;//获取泛型类型全部公有字段
            foreach (FieldInfo temp in arrFieldInfo)
            {
                //设置签名数据集合
                object objFieldValue = temp.GetValue(genericsObject);
                if ((null != objFieldValue) && (false == String.IsNullOrEmpty(objFieldValue.ToString())))
                {
                    dicSignatureDatas.Add(temp.Name, objFieldValue.ToString());
                }
                else { }
            }

            //生成签名字符串
            string strSignature = null;
            IEncryptionAsymmetric iEncryptionAsymmetric = null;
            var iSignatureSort = from Data in dicSignatureDatas orderby Data.Key select Data;
            foreach (var temp in iSignatureSort)
            {
                strSignature += (temp.Key + "=" + temp.Value + "&");
            }
            strSignature = strSignature.TrimEnd('&');
            if (PaySignatureType.MD5 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_MD5();
            }
            else if (PaySignatureType.SHA1 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_SHA1();
            }
            else { }
            result = iEncryptionAsymmetric.Encryption(strSignature, MatchCaseType.Uppercase);

            return result;
        }

        /// <summary>
        /// 生成JSApi签名，返回JSApi签名
        /// 生成失败则返回null
        /// </summary>
        /// <param name="url">页面地址</param>
        /// <param name="jsApiConfigModel">JSApi配置信息</param>
        /// <param name="signatureTypes">签名类型</param>
        /// <returns>JSApi签名</returns>
        public string CreateJsApiSignature(string url, JSApiConfig jsApiConfigModel, PaySignatureType signatureTypes = PaySignatureType.SHA1)
        {
            //处理错误参数
            if ((null == JSApiTicket) || (null == jsApiConfigModel) || (String.IsNullOrEmpty(JSApiTicket.ticket)) || (String.IsNullOrEmpty(url)) || (String.IsNullOrEmpty(jsApiConfigModel.nonceStr)) || (String.IsNullOrEmpty(jsApiConfigModel.timestamp)))
            {
                return null;
            }
            else { }

            string result = null;

            //签名数据集合
            Dictionary<string, string> dicSignatureDatas = new Dictionary<string, string>
            {
                { "noncestr", jsApiConfigModel.nonceStr },
                { "jsapi_ticket", JSApiTicket.ticket },
                { "timestamp", jsApiConfigModel.timestamp },
                { "url", url.Split('#')[0] }
            };

            //生成签名字符串
            string strSignature = null;
            IEncryptionAsymmetric iEncryptionAsymmetric = null;
            var iSignatureSort = from SignatureData in dicSignatureDatas orderby SignatureData.Key select SignatureData;
            foreach (var temp in iSignatureSort)
            {
                strSignature += (temp.Key + "=" + temp.Value + "&");
            }
            strSignature = strSignature.TrimEnd('&');
            if (PaySignatureType.SHA1 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_SHA1();
            }
            else if (PaySignatureType.MD5 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_MD5();
            }
            else { }
            result = iEncryptionAsymmetric.Encryption(strSignature, MatchCaseType.Lowercase);

            return result;
        }

        /// <summary>
        /// 生成JSApi签名，返回JSApi签名
        /// 生成失败则返回null
        /// </summary>
        /// <param name="url">页面地址</param>
        /// <param name="nonecStr">随机字符串</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="signatureTypes">签名类型</param>
        /// <returns>JSApi签名</returns>
        public string CreateJsApiSignature(string url, string nonecStr, string timeStamp, PaySignatureType signatureTypes = PaySignatureType.SHA1)
        {
            //处理错误参数
            if ((null == JSApiTicket) || (String.IsNullOrEmpty(JSApiTicket.ticket)) || (String.IsNullOrEmpty(url)) || (String.IsNullOrEmpty(nonecStr)) || (String.IsNullOrEmpty(timeStamp)))
            {
                return null;
            }
            else { }

            string result = null;

            //签名数据集合
            Dictionary<string, string> dicSignatureDatas = new Dictionary<string, string>
            {
                { "noncestr", nonecStr },
                { "jsapi_ticket", JSApiTicket.ticket },
                { "timestamp", timeStamp },
                { "url", url.Split('#')[0] }
            };

            //生成签名字符串
            string strSignature = null;
            IEncryptionAsymmetric iEncryptionAsymmetric = null;
            var iSignatureSort = from SignatureData in dicSignatureDatas orderby SignatureData.Key select SignatureData;
            foreach (var temp in iSignatureSort)
            {
                strSignature += (temp.Key + "=" + temp.Value + "&");
            }
            strSignature = strSignature.TrimEnd('&');
            if (PaySignatureType.SHA1 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_SHA1();
            }
            else if (PaySignatureType.MD5 == signatureTypes)
            {
                iEncryptionAsymmetric = new Helper_Encryption_MD5();
            }
            else { }
            result = iEncryptionAsymmetric.Encryption(strSignature, MatchCaseType.Lowercase);

            return result;
        }
    }
}
