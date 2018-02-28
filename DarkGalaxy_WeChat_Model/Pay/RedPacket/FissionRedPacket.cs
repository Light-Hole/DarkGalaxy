using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat裂变红包的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class FissionRedPacket : RedPacket
    {
        /// <summary>
        /// 红包金额设置方式 
        /// </summary>
        [DataMember]
        public string amt_type;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected FissionRedPacket()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="mchName">商户名称</param>
        /// <param name="openid">用户标识</param>
        /// <param name="mchOrderNumber">商户订单号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="amount">付款金额</param>
        /// <param name="total">红包总数</param>
        /// <param name="greeting">红包祝福语</param>
        /// <param name="ip">IP地址</param>
        /// <param name="activityName">活动名称</param>
        /// <param name="remark">备注</param>
        /// <param name="redSceneTypes">红包场景类型（金额大于200元时必填）</param>
        /// <param name="amtType">红包金额设置方式</param>
        public FissionRedPacket(string appID, string mchID, string mchName, string openid, string mchOrderNumber, string nonceStr, int amount, int total, string greeting, string ip, string activityName, string remark, RedPacketSceneType? redSceneTypes = null, string amtType = "ALL_RAND") : base(appID, mchID, mchName, openid, mchOrderNumber, nonceStr, amount, total, greeting, ip, activityName, remark, redSceneTypes)
        {
            amt_type = amtType;
        }
    }
}
