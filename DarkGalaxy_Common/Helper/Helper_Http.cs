using DarkGalaxy_Common.DarkGalaxy;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// Http帮助类
    /// 提供一系列对于Http协议的操作
    /// </summary>
    public static class Helper_Http
    {
        /// <summary>
        /// 发送Http请求，返回服务器端回发的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="HttpMethodTypes">请求类型</param>
        /// <param name="HttpContentTypes">请求内容类型</param>
        /// <param name="HttpContent">请求内容</param>
        /// <returns>服务器端回发的数据</returns>
        public static string SendHttpRequest(string Url, HttpMethodType HttpMethodTypes, HttpContentType HttpContentTypes, string HttpContent = null)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Url))
            {
                return null;
            }
            else { }

            string result = null;

            //设置Http基本参数
            HttpWebRequest RequestHttpMessage = null;

            if (HttpMethodType.GET == HttpMethodTypes)
            {
                if (!String.IsNullOrEmpty(HttpContent))
                {
                    HttpContent = HttpContent.Trim();
                    if (HttpContent.StartsWith("?"))
                    {
                        Url += HttpContent;
                    }
                    else
                    {
                        Url += ("?" + HttpContent);
                    }
                }
                else { }
                RequestHttpMessage = WebRequest.Create(Url) as HttpWebRequest;
                RequestHttpMessage.Method = Enum.GetName(typeof(HttpMethodType), HttpMethodTypes);
                RequestHttpMessage.ContentType = DGEnum.HttpContentTypeToContentTypeString(HttpContentTypes);
            }
            else if (HttpMethodType.POST == HttpMethodTypes)
            {
                RequestHttpMessage = WebRequest.Create(Url) as HttpWebRequest;
                RequestHttpMessage.Method = Enum.GetName(typeof(HttpMethodType), HttpMethodTypes);
                RequestHttpMessage.ContentType = DGEnum.HttpContentTypeToContentTypeString(HttpContentTypes);
                if (!String.IsNullOrEmpty(HttpContent))
                {
                    byte[] HttpContentBytes = Encoding.UTF8.GetBytes(HttpContent);
                    RequestHttpMessage.ContentLength = HttpContentBytes.Length;

                    //设置Http发送内容
                    using (Stream OutStream = RequestHttpMessage.GetRequestStream())
                    {
                        OutStream.Write(HttpContentBytes, 0, HttpContentBytes.Length);
                    }
                }
                else { }
            }
            else { }

            //发送Http请求，获取Http返回的数据
            using (WebResponse ResponseHttpMessage = RequestHttpMessage.GetResponse())
            {
                if (ResponseHttpMessage != null)
                {
                    Stream HttpResponseStream = ResponseHttpMessage.GetResponseStream();
                    using (StreamReader ReaderHttpResponseMessage = new StreamReader(HttpResponseStream, Encoding.UTF8))
                    {
                        result = ReaderHttpResponseMessage.ReadToEnd();
                    }
                }
                else { }
            }

            return result;
        }

        /// <summary>
        /// 发送Http请求，返回服务器端回发的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="HttpMethodTypes">请求类型</param>
        /// <param name="HttpContentTypes">请求内容类型</param>
        /// <param name="CertificatePath">证书路径</param>
        /// <param name="CertificatePassword">证书密码</param>
        /// <param name="HttpContent">请求内容</param>
        /// <returns>服务器端回发的数据</returns>
        public static string SendHttpRequest(string Url, HttpMethodType HttpMethodTypes, HttpContentType HttpContentTypes, string CertificatePath, string CertificatePassword, string HttpContent = null)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(Url)) || (String.IsNullOrEmpty(CertificatePath)) || (String.IsNullOrEmpty(CertificatePassword)) || (false == File.Exists(CertificatePath)))
            {
                return null;
            }
            else { }

            string result = null;

            //设置安全证书
            X509Certificate2 Certificate = new X509Certificate2(CertificatePath, CertificatePassword, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            //设置Http基本参数
            HttpWebRequest RequestHttpMessage = null;
            if (HttpMethodType.GET == HttpMethodTypes)
            {
                if (!String.IsNullOrEmpty(HttpContent))
                {
                    HttpContent = HttpContent.Trim();
                    if (HttpContent.StartsWith("?"))
                    {
                        Url += HttpContent;
                    }
                    else
                    {
                        Url += ("?" + HttpContent);
                    }
                }
                else { }
                RequestHttpMessage = WebRequest.Create(Url) as HttpWebRequest;
            }
            else
            {
                RequestHttpMessage = WebRequest.Create(Url) as HttpWebRequest;
                if (!String.IsNullOrEmpty(HttpContent))
                {
                    byte[] HttpContentBytes = Encoding.UTF8.GetBytes(HttpContent);
                    RequestHttpMessage.ContentLength = HttpContentBytes.Length;

                    //设置Http发送内容
                    using (Stream OutStream = RequestHttpMessage.GetRequestStream())
                    {
                        OutStream.Write(HttpContentBytes, 0, HttpContentBytes.Length);
                    }
                }
                else { }
            }
            RequestHttpMessage.ClientCertificates.Add(Certificate);
            RequestHttpMessage.Method = Enum.GetName(typeof(HttpMethodType), HttpMethodTypes);
            RequestHttpMessage.ContentType = DGEnum.HttpContentTypeToContentTypeString(HttpContentTypes);

            //发送Http请求，获取Http返回的数据
            using (WebResponse ResponseHttpMessage = RequestHttpMessage.GetResponse())
            {
                if (ResponseHttpMessage != null)
                {
                    Stream HttpResponseStream = ResponseHttpMessage.GetResponseStream();
                    using (StreamReader ReaderHttpResponseMessage = new StreamReader(HttpResponseStream, Encoding.UTF8))
                    {
                        result = ReaderHttpResponseMessage.ReadToEnd();
                    }
                }
                else { }
            }

            return result;
        }

        /// <summary>
        /// Http请求转换为泛型对象，返回转换后的类型
        /// </summary>
        /// <typeparam name="T">转换的类型</typeparam>
        /// <param name="HttpTransitTypes">Http传值方式类型</param>
        /// <returns>转换后的类型</returns>
        public static T HttpRequestToGenerics<T>(HttpTransitType HttpTransitTypes)
            where T : class, new()
        {
            T result = new T();

            //Http请求转换为泛型对象
            PropertyInfo[] PropertyInfos = typeof(T).GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                //获取Http请求数据
                string RequestValue = null;
                switch (HttpTransitTypes)
                {
                    case HttpTransitType.Form:
                        RequestValue = HttpContext.Current.Request.Params.Get(temp.Name);
                        break;
                    case HttpTransitType.QueryString:
                        RequestValue = HttpContext.Current.Request.QueryString.Get(temp.Name);
                        break;
                    case HttpTransitType.ServerVariables:
                        RequestValue = HttpContext.Current.Request.ServerVariables.Get(temp.Name);
                        break;
                    case HttpTransitType.Params:
                        RequestValue = HttpContext.Current.Request.Params.Get(temp.Name);
                        break;
                    default:
                        RequestValue = HttpContext.Current.Request.Params.Get(temp.Name);
                        break;
                }

                //转换泛型对象
                if (!String.IsNullOrEmpty(RequestValue))
                {
                    MethodInfo SetMethodInfo = temp.GetSetMethod();
                    object ModelValue = null;
                    if (temp.PropertyType.IsEnum)
                    {
                        //枚举类型转换
                        ModelValue = Enum.Parse(temp.PropertyType, RequestValue);
                    }
                    else if ((temp.PropertyType.IsGenericType) && (temp.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))))
                    {
                        //可空数据类型转换
                        NullableConverter nullableConverter = new NullableConverter(temp.PropertyType);
                        Type UnderlyingTypes = nullableConverter.UnderlyingType;
                        ModelValue = Convert.ChangeType(RequestValue, UnderlyingTypes);
                    }
                    else
                    {
                        ModelValue = Convert.ChangeType(RequestValue, temp.PropertyType);
                    }
                    SetMethodInfo.Invoke(result, new object[] { ModelValue });
                }
                else { }
            }

            return result;
        }
    }
}
