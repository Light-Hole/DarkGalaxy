using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表BasicInformation的Model层
    /// </summary>
    [DataContract]
    public class BasicInformation
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

        private string _SEO_Title;

        /// <summary>
        /// SEO优化标题
        /// </summary>
        [DataMember]
        public string SEO_Title
        {
            get { return _SEO_Title; }
            set { _SEO_Title = value; }
        }

        private string _SEO_Keywords;

        /// <summary>
        /// SEO优化关键词
        /// </summary>
        [DataMember]
        public string SEO_Keywords
        {
            get { return _SEO_Keywords; }
            set { _SEO_Keywords = value; }
        }

        private string _SEO_Description;

        /// <summary>
        /// SEO优化描述
        /// </summary>
        [DataMember]
        public string SEO_Description
        {
            get { return _SEO_Description; }
            set { _SEO_Description = value; }
        }

        private string _Title;

        /// <summary>
        /// 标题
        /// </summary>
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

        private string _LogoPath;

        /// <summary>
        /// Logo地址
        /// </summary>
        [DataMember]
        public string LogoPath
        {
            get { return _LogoPath; }
            set { _LogoPath = value; }
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

        private string _DetailedContent;

        /// <summary>
        /// 详情介绍
        /// </summary>
        [DataMember]
        public string DetailedContent
        {
            get { return _DetailedContent; }
            set { _DetailedContent = value; }
        }

        private string _Telephone;

        /// <summary>
        /// 电话号
        /// </summary>
        [DataMember]
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }

        private string _QQ;

        /// <summary>
        /// QQ帐号
        /// </summary>
        [DataMember]
        public string QQ
        {
            get { return _QQ; }
            set { _QQ = value; }
        }

        private string _EMail;

        /// <summary>
        /// EMail
        /// </summary>
        [DataMember]
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        private double? _Longitude = null;

        /// <summary>
        /// 经度，默认值：null
        /// </summary>
        [DataMember]
        public double? Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        private double? _Latitude = null;

        /// <summary>
        /// 纬度，默认值：null
        /// </summary>
        [DataMember]
        public double? Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        private string _PlaceAddress;

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string PlaceAddress
        {
            get { return _PlaceAddress; }
            set { _PlaceAddress = value; }
        }
    }
}

