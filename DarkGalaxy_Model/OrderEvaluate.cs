using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表Evaluate的Model层
 	/// </summary>
    [DataContract]
    public class Evaluate
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

        private string _DetailedContent;

        /// <summary>
        /// 内容
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string DetailedContent
        {
            get { return _DetailedContent; }
            set { _DetailedContent = value; }
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

        private bool _AuditStatus = false;

        /// <summary>
        /// 审核状态，默认值：false
        /// </summary>
        [DGNotNull]
        [DataMember]
        public bool AuditStatus
        {
            get { return _AuditStatus; }
            set { _AuditStatus = value; }
        }

        private int? _AdminAccount_ID = null;

        /// <summary>
        /// 外键，关联AdminAccount表主键，表示管理员帐户主键，默认值：null
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public int? AdminAccount_ID
        {
            get { return _AdminAccount_ID; }
            set { _AdminAccount_ID = value; }
        }

        private int _UserAccount_ID;

        /// <summary>
        /// 外键，关联UserAccount表主键，表示用户帐户主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int UserAccount_ID
        {
            get { return _UserAccount_ID; }
            set { _UserAccount_ID = value; }
        }

        private int _UserInformation_ID;

        /// <summary>
        /// 外键，关联UserInformation表主键，表示用户帐户信息主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int UserInformation_ID
        {
            get { return _UserInformation_ID; }
            set { _UserInformation_ID = value; }
        }

        private int _Commodity_ID;

        /// <summary>
        /// 外键，关联Commodity表主键，表示商品主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Commodity_ID
        {
            get { return _Commodity_ID; }
            set { _Commodity_ID = value; }
        }

        private int _Order_ID;

        /// <summary>
        /// 外键，关联Order表主键，表示订单主键
        /// </summary>
        [DGNotNull]
        [DataMember]
        public int Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
    }
}
