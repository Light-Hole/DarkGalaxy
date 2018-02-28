using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表Product的Model层
    /// </summary>
    [DataContract]
    public class Product
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

        private string _SubTitle;

        /// <summary>
        /// 副标题
        /// </summary>
        [DataMember]
        public string SubTitle
        {
            get { return _SubTitle; }
            set { _SubTitle = value; }
        }

        private string _SubTitle_English;

        /// <summary>
        /// 英文副标题
        /// </summary>
        [DataMember]
        public string SubTitle_English
        {
            get { return _SubTitle_English; }
            set { _SubTitle_English = value; }
        }

        private bool _Recommend = false;

        /// <summary>
        /// 是否推荐：默认值：false
        /// </summary>
        public bool Recommend
        {
            get { return _Recommend; }
            set { _Recommend = value; }
        }

        private string _Keywords;

        /// <summary>
        /// 关键词
        /// </summary>
        [DataMember]
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }

        private DateTime _ArticleTime = DateTime.Now;

        /// <summary>
        /// 发布时间，默认值：DateTime.Now
        /// </summary>
        [DataMember]
        public DateTime ArticleTime
        {
            get { return _ArticleTime; }
            set { _ArticleTime = value; }
        }

        private int _BrowseCount = 0;

        /// <summary>
        /// 浏览次数，默认值：0
        /// </summary>
        [DataMember]
        public int BrowseCount
        {
            get { return _BrowseCount; }
            set { _BrowseCount = value; }
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

        private string _ImagePath;

        /// <summary>
        /// 图片地址
        /// </summary>
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

        private string _DetailedContent;

        /// <summary>
        /// 内容（产品详情）
        /// </summary>
        [DataMember]
        public string DetailedContent
        {
            get { return _DetailedContent; }
            set { _DetailedContent = value; }
        }

        private string _URL;

        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        private string _QRCodePath;

        /// <summary>
        /// 二维码地址
        /// </summary>
        [DataMember]
        public string QRCodePath
        {
            get { return _QRCodePath; }
            set { _QRCodePath = value; }
        }

        private string _PhysicalAddress;

        /// <summary>
        /// 物理地址（所在实际地址）
        /// </summary>
        [DataMember]
        public string PhysicalAddress
        {
            get { return _PhysicalAddress; }
            set { _PhysicalAddress = value; }
        }

        private int _Category_ID;

        /// <summary>
        /// 外键，关联Category表主键，表示分类主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Category_ID
        {
            get { return _Category_ID; }
            set { _Category_ID = value; }
        }
    }
}

