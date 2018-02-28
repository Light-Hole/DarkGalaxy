using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表UserAccount的Model层
    /// </summary>
    [DataContract]
    public class UserAccount
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

        private string _UserName;

        /// <summary>
        /// 帐号名
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Email;

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Phone;

        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Password;

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _OpenID;

        /// <summary>
        /// WeChat用户唯一标识
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public string OpenID
        {
            get { return _OpenID; }
            set { _OpenID = value; }
        }
    }
}

