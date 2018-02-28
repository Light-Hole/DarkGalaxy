using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat红包记录的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RedPacketRecord_Result : PayResultCode
    {
        /// <summary>
        /// 签名
        /// </summary>
        [DataMember]
        public string sign;

        /// <summary>
        /// 业务结果
        /// </summary>
        [DataMember]
        public string result_code;

        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public string err_code;

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [DataMember]
        public string err_code_des;

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
        /// 红包单号
        /// </summary>
        [DataMember]
        public string detail_id;

        /// <summary>
        /// 红包状态
        /// </summary>
        [DataMember]
        public string status;

        /// <summary>
        /// 红包类型
        /// </summary>
        [DataMember]
        public string send_type;

        /// <summary>
        /// 红包个数
        /// </summary>
        [DataMember]
        public string total_num;

        /// <summary>
        /// 红包金额
        /// </summary>
        [DataMember]
        public string total_amount;

        /// <summary>
        /// 失败原因
        /// </summary>
        [DataMember]
        public string reason;

        /// <summary>
        /// 红包发送时间
        /// </summary>
        [DataMember]
        public string send_time;

        /// <summary>
        /// 红包退款时间
        /// </summary>
        [DataMember]
        public string refund_time;

        /// <summary>
        /// 红包退款金额
        /// </summary>
        [DataMember]
        public string refund_amount;

        /// <summary>
        /// 祝福语
        /// </summary>
        [DataMember]
        public string wishing;

        /// <summary>
        /// 活动描述
        /// </summary>
        [DataMember]
        public string remark;

        /// <summary>
        /// 活动名称
        /// </summary>
        [DataMember]
        public string act_name;

        /// <summary>
        /// 裂变红包领取列表
        /// </summary>
        [DataMember]
        public string hblist;

        /// <summary>
        /// 领取红包的Openid
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public string amount;

        /// <summary>
        /// 接收时间
        /// </summary>
        [DataMember]
        public string rcv_time;
    }
}
