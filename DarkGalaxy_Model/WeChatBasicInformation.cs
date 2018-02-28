using DarkGalaxy_Common.Attribute;
using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_Model
{
    /// <summary>
 	/// 表WeChatBasicInformation的Model层
 	/// </summary>
    [DataContract]
    public class WeChatBasicInformation
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

        private string _APIUrl = "https://api.weixin.qq.com";

        /// <summary>
        /// 接口域名
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string APIUrl
        {
            get { return _APIUrl; }
            set { _APIUrl = value; }
        }

        private string _AppID;

        /// <summary>
        /// 开发者ID
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }

        private string _AppSecret;

        /// <summary>
        /// 开发者密码
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string AppSecret
        {
            get { return _AppSecret; }
            set { _AppSecret = value; }
        }

        private string _PayKey;

        /// <summary>
        /// 支付密钥
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string PayKey
        {
            get { return _PayKey; }
            set { _PayKey = value; }
        }

        private string _PayMchID;

        /// <summary>
        /// 微信支付商户号
        /// </summary>
        [DGInsertNeglect]
        [DataMember]
        public string PayMchID
        {
            get { return _PayMchID; }
            set { _PayMchID = value; }
        }
    }
}
