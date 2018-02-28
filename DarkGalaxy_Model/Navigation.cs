using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表Navigation的Model层
    /// </summary>
    [DataContract]
    public class Navigation
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

        private int _SortIndex;

        /// <summary>
        /// 记录排序索引
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
        [DataMember]
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private string _IDPath = "/";

        /// <summary>
        /// ID路径
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

        private string _Title_ImagePath;

        /// <summary>
        /// 图片标题地址
        /// </summary>
        [DataMember]
        public string Title_ImagePath
        {
            get { return _Title_ImagePath; }
            set { _Title_ImagePath = value; }
        }

        private string _URL = "/";

        /// <summary>
        /// 链接地址，默认值："/"
        /// </summary>
        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
    }
}

