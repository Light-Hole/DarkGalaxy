using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat关闭订单的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class OrderClose
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string out_trade_no;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember]
        public string nonce_str;

        /// <summary>
        /// 签名
        /// </summary>
        [DataMember]
        public string sign;

        /// <summary>
        /// 签名类型
        /// </summary>
        [DataMember]
        public string sign_type;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected OrderClose()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="orderNumber">商户订单号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="signatureTypes">签名类型</param>
        public OrderClose(string appID, string mchID, string orderNumber, string nonceStr, PaySignatureType signatureTypes = PaySignatureType.MD5)
        {
            appid = appID;
            mch_id = mchID;
            out_trade_no = orderNumber;
            sign_type = Enum.GetName(typeof(PaySignatureType), signatureTypes);

            //设置随机字符串
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
        }
    }
}
