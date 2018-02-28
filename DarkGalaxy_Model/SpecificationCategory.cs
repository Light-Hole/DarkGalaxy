using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表SpecificationCategory的Model层
 	/// </summary>
    [DataContract]
    public class SpecificationCategory
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

        private string _Title;

        /// <summary>
        /// 标题
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _ImagePath;

        /// <summary>
        /// 图片地址
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        private string _Description;

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private int _Price;

        /// <summary>
        /// 价格
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private bool _Balcony = false;

        /// <summary>
        /// 阳台，默认值：false
        /// </summary>
        [DGNotNull]
        [DataMember]
        public bool Balcony
        {
            get { return _Balcony; }
            set { _Balcony = value; }
        }

        private bool _Window = false;

        /// <summary>
        /// 窗户，默认值：false
        /// </summary>
        [DGNotNull]
        [DataMember]
        public bool Window
        {
            get { return _Window; }
            set { _Window = value; }
        }

        private int _GuestMin;

        /// <summary>
        /// 客人数量（最少）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int GuestMin
        {
            get { return _GuestMin; }
            set { _GuestMin = value; }
        }

        private int _GuestMax;

        /// <summary>
        /// 客人数量（最多）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int GuestMax
        {
            get { return _GuestMax; }
            set { _GuestMax = value; }
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
    }
}
