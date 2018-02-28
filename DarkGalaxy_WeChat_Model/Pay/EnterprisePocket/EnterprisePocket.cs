using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat企业支付到零钱的Model类基类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class EnterprisePocket
    {
        /// <summary>
        /// 商户账号appid
        /// </summary>
        [DataMember]
        public string mch_appid;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mchid;

        /// <summary>
        /// 设备号
        /// </summary>
        [DataMember]
        public string device_info;

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
        public string partner_trade_no;

        /// <summary>
        /// 用户openid
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 校验用户姓名选项
        /// </summary>
        [DataMember]
        public string check_name;

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [DataMember]
        public string re_user_name;

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public int amount;

        /// <summary>
        /// 企业付款描述信息
        /// </summary>
        [DataMember]
        public string desc;

        /// <summary>
        /// Ip地址
        /// </summary>
        [DataMember]
        public string spbill_create_ip;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected EnterprisePocket()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="mchOrderNumber">商户订单号</param>
        /// <param name="openID">用户标识</param>
        /// <param name="money">付款金额</param>
        /// <param name="desc">付款描述</param>
        /// <param name="ip">IP地址</param>
        /// <param name="userName">用户姓名</param>
        public EnterprisePocket(string appID, string mchID, string nonceStr, string mchOrderNumber, string openID, int money, string desc, string ip, string userName = null)
        {
            mch_appid = appID;
            mchid = mchID;
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
            partner_trade_no = mchOrderNumber;
            openid = openID;
            re_user_name = userName;
            if(string.IsNullOrEmpty(userName))
            {
                check_name = "NO_CHECK";
            }
            else
            {
                check_name = "FORCE_CHECK";
            }
            amount = money;
            this.desc = desc;
            spbill_create_ip = ip;
        }
    }
}
