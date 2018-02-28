using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表Contacts的Model层
 	/// </summary>
    [DataContract]
    public class Contacts
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

        private string _Name;

        /// <summary>
        /// 姓名
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Phone;

        /// <summary>
        /// 手机号
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
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

        private string _RegionsID;

        /// <summary>
        /// 地区，表Region主键，格式：1级ID/2级ID/3级ID/4级ID（国家/省/市/区）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string RegionsID
        {
            get { return _RegionsID; }
            set { _RegionsID = value; }
        }

        private string _DetailedAddress;

        /// <summary>
        /// 详细地址
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string DetailedAddress
        {
            get { return _DetailedAddress; }
            set { _DetailedAddress = value; }
        }

        private int _UserAccount_ID;

        /// <summary>
        /// 外键，关联UserAccount表主键，表示用户帐户主键
        /// </summary>
        [DGNotNull]
        [DGUpdateNeglect]
        [DataMember]
        public int UserAccount_ID
        {
            get { return _UserAccount_ID; }
            set { _UserAccount_ID = value; }
        }
    }
}
