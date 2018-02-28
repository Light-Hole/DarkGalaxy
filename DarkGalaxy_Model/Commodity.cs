using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表Commodity的Model层
 	/// </summary>
    [DataContract]
    public class Commodity
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

        private string _Title_English;

        /// <summary>
        /// 英文标题
        /// </summary>
        [DataMember]
        public string Title_English
        {
            get { return _Title_English; }
            set { _Title_English = value; }
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

        private string _Details;

        /// <summary>
        /// 详细信息
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }

        private DateTime _DepartureDate;

        /// <summary>
        /// 出发日期
        /// </summary>
        [DGNotNull]
        [DataMember]
        public DateTime DepartureDate
        {
            get { return _DepartureDate; }
            set { _DepartureDate = value; }
        }

        private DateTime _RegressionDate;

        /// <summary>
        /// 返回日期
        /// </summary>
        [DGNotNull]
        [DataMember]
        public DateTime RegressionDate
        {
            get { return _RegressionDate; }
            set { _RegressionDate = value; }
        }

        private string _DepartureSite;

        /// <summary>
        /// 出发地点
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string DepartureSite
        {
            get { return _DepartureSite; }
            set { _DepartureSite = value; }
        }

        private string _RegressionSite;

        /// <summary>
        /// 目的地点
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string RegressionSite
        {
            get { return _RegressionSite; }
            set { _RegressionSite = value; }
        }

        private int _DaytimeNumber;

        /// <summary>
        /// 白天数量
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int DaytimeNumber
        {
            get { return _DaytimeNumber; }
            set { _DaytimeNumber = value; }
        }

        private int _NightNumber;

        /// <summary>
        /// 夜晚数量
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int NightNumber
        {
            get { return _NightNumber; }
            set { _NightNumber = value; }
        }
    }
}
