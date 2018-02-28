using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表Category的Model层
    /// </summary>
    [DataContract]
    public class Category
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

        private int _TopID = 0;

        /// <summary>
        /// 顶级ID，默认值：0
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public int TopID
        {
            get { return _TopID; }
            set { _TopID = value; }
        }

        private int _ParentID = 0;

        /// <summary>
        /// 父级ID，默认值：0
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private string _IDPath = "/";

        /// <summary>
        /// ID路径，默认值："/"
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public string IDPath
        {
            get { return _IDPath; }
            set { _IDPath = value; }
        }

        private int _Depth = 1;

        /// <summary>
        /// 深度，默认值：1
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public int Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
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

        private string _Title_ImageURL;

        /// <summary>
        /// 标题图片地址
        /// </summary>
        [DataMember]
        public string Title_ImagePath
        {
            get { return _Title_ImageURL; }
            set { _Title_ImageURL = value; }
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
    }
}

