using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表FriendLink的Model层
    /// </summary>
    [DataContract]
    public class FriendLink
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

        private string _Title_ImagePath;

        /// <summary>
        /// 标题图片地址
        /// </summary>
        [DataMember]
        public string Title_ImagePath
        {
            get { return _Title_ImagePath; }
            set { _Title_ImagePath = value; }
        }

        private string _URL;

        /// <summary>
        /// 链接地址
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
    }
}

