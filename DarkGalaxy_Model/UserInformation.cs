using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表UserInformation的Model层
    /// </summary>
    [DataContract]
    public class UserInformation
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

        private string _NickName;

        /// <summary>
        /// 昵称
        /// </summary>
        [DataMember]
        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }

        private string _PicturePath = "/Images/DefaultHeadPortrait.png";

        /// <summary>
        /// 头像地址
        /// </summary>
        [DataMember]
        public string PicturePath
        {
            get { return _PicturePath; }
            set { _PicturePath = value; }
        }

        private string _Description;

        /// <summary>
        /// 描述（个性签名）
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private GenderType _Gender = GenderType.Secrecy;

        /// <summary>
        /// 性别（0：女，1：男，2：保密），默认值：GenderType.Secrecy（保密）
        /// </summary>
        [DGNotNull]
        [DataMember]
        public GenderType Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private DateTime? _Birthdate = null;

        /// <summary>
        /// 生日，默认值：null
        /// </summary>
        [DataMember]
        public DateTime? Birthdate
        {
            get { return _Birthdate; }
            set { _Birthdate = value; }
        }

        private int _UserAccount_ID;

        /// <summary>
        /// 外键，关联UserAccount表主键，表示用户帐户主键
        /// </summary>
        [DGUpdateNeglect]
        [DataMember]
        public int UserAccount_ID
        {
            get { return _UserAccount_ID; }
            set { _UserAccount_ID = value; }
        }
    }
}
