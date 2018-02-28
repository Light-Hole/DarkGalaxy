using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表Specification的Model层
 	/// </summary>
    [DataContract]
    public class Specification
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

        private string _ImagePaths;

        /// <summary>
        /// 图片地址（多图）
        /// </summary>
        [DataMember]
        public string ImagePaths
        {
            get { return _ImagePaths; }
            set { _ImagePaths = value; }
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
        /// 价格（单位：分）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private int _Guest;

        /// <summary>
        /// 客人数量
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Guest
        {
            get { return _Guest; }
            set { _Guest = value; }
        }

        private string _Floors;

        /// <summary>
        /// 楼层数
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Floors
        {
            get { return _Floors; }
            set { _Floors = value; }
        }

        private int _Area;

        /// <summary>
        /// 面积
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Area
        {
            get { return _Area; }
            set { _Area = value; }
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

        private int _SpecificationCategory_ID;

        /// <summary>
        /// 外键，关联SpecificationCategory表主键，表示商品船舱分类主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int SpecificationCategory_ID
        {
            get { return _SpecificationCategory_ID; }
            set { _SpecificationCategory_ID = value; }
        }
    }
}
