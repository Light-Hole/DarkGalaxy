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
    /// WeChat退款结果通知信息的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class RefundResultInfo
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        [DataMember]
        public string transaction_id;

        /// <summary>
        /// 微信订单号
        /// </summary>
        [DataMember]
        public string out_trade_no;

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [DataMember]
        public string refund_id;

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [DataMember]
        public string out_refund_no;

        /// <summary>
        /// 订单金额（单位：分）
        /// </summary>
        [DataMember]
        public int total_fee;

        /// <summary>
        /// 应结订单金额
        /// </summary>
        [DataMember]
        public int settlement_total_fee;

        /// <summary>
        /// 申请退款金额（单位：分）
        /// </summary>
        [DataMember]
        public int refund_fee;

        /// <summary>
        /// 退款金额（单位：分）
        /// </summary>
        [DataMember]
        public int settlement_refund_fee;

        /// <summary>
        /// 退款状态
        /// </summary>
        [DataMember]
        public string refund_status;

        /// <summary>
        /// 退款成功时间
        /// </summary>
        [DataMember]
        public string success_time;

        /// <summary>
        /// 退款入账账户
        /// </summary>
        [DataMember]
        public string refund_recv_accout;

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [DataMember]
        public string refund_account;

        /// <summary>
        /// 退款发起来源
        /// </summary>
        [DataMember]
        public string refund_request_source;
    }
}
