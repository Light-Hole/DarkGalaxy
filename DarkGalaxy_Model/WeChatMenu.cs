using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表WeChatMenu的Model层
 	/// </summary>
    [DataContract]
    public class WeChatMenu
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

        private int _Grade = 1;

        /// <summary>
        /// 级别，默认值：1
        /// 1：一级菜单，2：二级菜单
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Grade
        {
            get { return _Grade; }
            set { _Grade = value; }
        }

        private string _Genre;

        /// <summary>
        /// 类型
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        private int _ParentID = 0;

        /// <summary>
        /// 上级ID，默认值：0
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private string _DetailedContent;

        /// <summary>
        /// 内容
        /// </summary>
        [DataMember]
        public string DetailedContent
        {
            get { return _DetailedContent; }
            set { _DetailedContent = value; }
        }

        private bool _Employ = false;

        /// <summary>
        /// 启用
        /// </summary>
        [DGNotNull]
        [DataMember]
        public bool Employ
        {
            get { return _Employ; }
            set { _Employ = value; }
        }
    }
}
