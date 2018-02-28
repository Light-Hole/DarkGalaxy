using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat红包记录查询的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RedPacketSelect
    {
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
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string mch_billno;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 公众号唯一标识
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 订单类型
        /// </summary>
        [DataMember]
        public string bill_type;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected RedPacketSelect()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="mchOrderNumber">商户订单号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="orderType">订单类型</param>
        public RedPacketSelect(string appID, string mchID, string mchOrderNumber, string nonceStr, string orderType = "MCHT")
        {
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
            mch_billno = mchOrderNumber;
            mch_id = mchID;
            appid = appID;
            bill_type = orderType;
        }
    }
}
