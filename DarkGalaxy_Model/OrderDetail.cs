using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表OrderDetail的Model层
 	/// </summary>
    [DataContract]
    public class OrderDetail
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

        private int _Price;

        /// <summary>
        /// 价格（单位：分）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private int _Quantity;

        /// <summary>
        /// 数量
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
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

        private int _Specification_ID;

        /// <summary>
        /// 外键，关联Specification表主键，表示船舱主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Specification_ID
        {
            get { return _Specification_ID; }
            set { _Specification_ID = value; }
        }

        private int _SpecificationCategory_ID;

        /// <summary>
        /// 外键，关联SpecificationCategory表主键，表示船舱分类主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int SpecificationCategory_ID
        {
            get { return _SpecificationCategory_ID; }
            set { _SpecificationCategory_ID = value; }
        }

        private int _Commodity_ID;

        /// <summary>
        /// 外键，关联Commodity表主键，表示商品主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Commodity_ID
        {
            get { return _Commodity_ID; }
            set { _Commodity_ID = value; }
        }

        private int _Order_ID;

        /// <summary>
        /// 外键，关联Order表主键，表示订单主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
    }
}
