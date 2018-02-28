using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat全局JS-SDK支付的Model类
    /// </summary>
    [DataContract]
    public class JSPay
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string appId;

        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string timeStamp;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string nonceStr;

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string package;

        /// <summary>
        /// 签名
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string paySign;

        /// <summary>
        /// 签名类型
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string signType;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="package">订单详情扩展字符串（预支付ID）</param>
        /// <param name="signatureTypes">签名类型</param>
        public JSPay(string appID, string timeStamp, string nonceStr, string package, PaySignatureType signatureTypes)
        {
            appId = appID;
            this.timeStamp = timeStamp;
            if (32 < nonceStr.Length)
            {
                this.nonceStr = nonceStr.Substring(0, 32);
            }
            else
            {
                this.nonceStr = nonceStr;
            }
            package = package.Trim();
            if (package.StartsWith("prepay_id="))
            {
                this.package = package;
            }
            else
            {
                this.package = ("prepay_id=" + package);
            }
            signType = Enum.GetName(typeof(PaySignatureType), signatureTypes);
        }
    }
}
