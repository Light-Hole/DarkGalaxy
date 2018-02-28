using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表OrderPassenger的Model层
 	/// </summary>
    [DataContract]
    public class OrderPassenger
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

        private GenderType _Gender = GenderType.Secrecy;

        /// <summary>
        /// 性别（0：女，1：男，2：保密），默认值：2
        /// </summary>
        [DGNotNull]
        [DataMember]
        public GenderType Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _IDCard;

        /// <summary>
        /// 身份证号码
        /// </summary>
        [DGNotNull]
        [DataMember]
        public string IDCard
        {
            get { return _IDCard; }
            set { _IDCard = value; }
        }

        private int _Order_ID;

        /// <summary>
        /// 外键，关联Order表主键，表示订单主键
        /// </summary>
        [DGNotNull]
        [DGUpdateNeglect]
        [DataMember]
        public int Order_ID
        {
            get { return _Order_ID; }
            set { _Order_ID = value; }
        }
    }
}
