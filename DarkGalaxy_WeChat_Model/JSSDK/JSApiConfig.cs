using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat全局JS-SDK接口配置的Model类
    /// </summary>
    [DataContract]
    public class JSApiConfig
    {
        /// <summary>
        /// 公众号唯一标识
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string appId;

        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string timestamp;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string nonceStr;

        /// <summary>
        /// 签名
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string signature;

        /// <summary>
        /// JS接口列表
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string[] jsApiList;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="jsApiTypes">JS接口类型列表</param>
        public JSApiConfig(string appID,string timeStamp,string nonceStr,JSApiType[] jsApiTypes)
        {
            appId = appID;
            timestamp = timeStamp;
            this.nonceStr = nonceStr;
            List<string> JSApiTypeList = new List<string>();
            foreach(var temp in jsApiTypes)
            {
                JSApiTypeList.Add(Enum.GetName(typeof(JSApiType),temp));
            }
            jsApiList = JSApiTypeList.ToArray();
        }
    }
}
