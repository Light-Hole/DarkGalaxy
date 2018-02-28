using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表Order的Model层
 	/// </summary>
    [DataContract]
    public class Order
    {
        private int _ID;

        /// <summary>
        /// 主键
        /// </summary>
        [DGPrimaryKey]
        [DGInsertNeglect]
        [DGUpdateNeglect]
        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private bool _Enabled = true;

        /// <summary>
        /// 记录是否可用，默认值：true
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        private DateTime _CreateDateTime;

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [DGInsertNeglect]
        [DGUpdateNeglect]
        [DataMember]
        public DateTime CreateDateTime
        {
            get { return _CreateDateTime; }
            set { _CreateDateTime = value; }
        }

        private int _SortIndex = 0;

        /// <summary>
        /// 记录排序索引，默认值：0
        /// </summary>
        [DataMember]
        public int SortIndex
        {
            get { return _SortIndex; }
            set { _SortIndex = value; }
        }

        private string _OrderNumber;

        /// <summary>
        /// 订单号
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }

        private string _WeChatOrderNumber;

        /// <summary>
        /// 微信订单号
        /// </summary>
        [DataMember]
        public string WeChatOrderNumber
        {
            get { return _WeChatOrderNumber; }
            set { _WeChatOrderNumber = value; }
        }

        private string _RefundOrderNumber;

        /// <summary>
        /// 退款订单号
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string RefundOrderNumber
        {
            get { return _RefundOrderNumber; }
            set { _RefundOrderNumber = value; }
        }

        private string _RefundWeChatOrderNumber;

        /// <summary>
        /// 微信退款订单号
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string RefundWeChatOrderNumber
        {
            get { return _RefundWeChatOrderNumber; }
            set { _RefundWeChatOrderNumber = value; }
        }

        private int _TotalPrice;

        /// <summary>
        /// 总价格（单位：分）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }

        private int _TotalQuantity;

        /// <summary>
        /// 总数量
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int TotalQuantity
        {
            get { return _TotalQuantity; }
            set { _TotalQuantity = value; }
        }

        private int _PreferentialPrice = 0;

        /// <summary>
        /// 优惠价格（单位：分），默认值：0
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int PreferentialPrice
        {
            get { return _PreferentialPrice; }
            set { _PreferentialPrice = value; }
        }

        private int _ActualPrice;

        /// <summary>
        /// 实付价格（单位：分）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int ActualPrice
        {
            get { return _ActualPrice; }
            set { _ActualPrice = value; }
        }

        private OrderStatusType _Status = OrderStatusType.WaitPay;

        /// <summary>
        /// 订单状态，默认值：OrderStatusType.WaitPay（待付款）
        /// </summary>
        [DGInsertNeglect]
        [DGNotNull]
        [DataMember]
        public OrderStatusType Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Name;

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Phone;

        /// <summary>
        /// 联系人手机号
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email;

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _RegionsID;

        /// <summary>
        /// 联系人所在地区，表Region主键，格式：1级ID/2级ID/3级ID/4级ID（国家/省/市/区）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string RegionsID
        {
            get { return _RegionsID; }
            set { _RegionsID = value; }
        }

        private string _DetailedAddress;

        /// <summary>
        /// 联系人详细地址
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string DetailedAddress
        {
            get { return _DetailedAddress; }
            set { _DetailedAddress = value; }
        }

        private int _UserAccount_ID;

        /// <summary>
        /// 外键，关联UserAccount表主键，表示用户帐户主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int UserAccount_ID
        {
            get { return _UserAccount_ID; }
            set { _UserAccount_ID = value; }
        }

        private int? _AdminAccount_ID = null;

        /// <summary>
        /// 外键，关联AdminAccount表主键，表示管理员帐户主键（退款审核人），默认值：null
        /// </summary>
        [DataMember]
        public int? AdminAccount_ID
        {
            get { return _AdminAccount_ID; }
            set { _AdminAccount_ID = value; }
        }
    }
}
