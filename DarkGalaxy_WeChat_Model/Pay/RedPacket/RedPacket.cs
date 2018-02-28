using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat普通红包的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RedPacket
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
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string wxappid;

        /// <summary>
        /// 商户名称
        /// </summary>
        [DataMember]
        public string send_name;

        /// <summary>
        /// 用户OpenID
        /// </summary>
        [DataMember]
        public string re_openid;

        /// <summary>
        /// 付款金额（单位：分）
        /// </summary>
        [DataMember]
        public int total_amount;

        /// <summary>
        /// 红包发放总人数
        /// </summary>
        [DataMember]
        public int total_num;

        /// <summary>
        /// 红包祝福语
        /// </summary>
        [DataMember]
        public string wishing;

        /// <summary>
        /// IP地址
        /// </summary>
        [DataMember]
        public string client_ip;

        /// <summary>
        /// 活动名称
        /// </summary>
        [DataMember]
        public string act_name;

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string remark;

        /// <summary>
        /// 场景ID
        /// </summary>
        [DataMember]
        public string scene_id;

        /// <summary>
        /// 活动信息
        /// </summary>
        [DataMember]
        public string risk_info;

        /// <summary>
        /// 资金授权商户号
        /// </summary>
        [DataMember]
        public string consume_mch_id;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected RedPacket()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="mchName">商户名称</param>
        /// <param name="openID">用户标识</param>
        /// <param name="mchOrderNumber">商户订单号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="money">付款金额</param>
        /// <param name="total">红包总数</param>
        /// <param name="greeting">红包祝福语</param>
        /// <param name="ip">IP地址</param>
        /// <param name="activityName">活动名称</param>
        /// <param name="remark">备注</param>
        /// <param name="redSceneTypes">红包场景类型（金额大于200元时必填）</param>
        public RedPacket(string appID, string mchID, string mchName, string openID, string mchOrderNumber, string nonceStr, int money, int total, string greeting, string ip, string activityName, string remark, RedPacketSceneType? redSceneTypes = null)
        {
            wxappid = appID;
            mch_id = mchID;
            send_name = mchName;
            re_openid = openID;
            mch_billno = mchOrderNumber;
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
            total_amount = money;
            total_num = total;
            wishing = greeting;
            client_ip = ip;
            act_name = activityName;
            this.remark = remark;
            if (null != redSceneTypes)
            {
                scene_id = Enum.GetName(typeof(RedPacketSceneType), redSceneTypes);
            }
            else { }
        }
    }
}
