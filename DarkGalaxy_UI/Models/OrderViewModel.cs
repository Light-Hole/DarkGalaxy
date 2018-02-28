using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// 订单的ViewModel类
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        /// <summary>
        /// 所在地区文本
        /// </summary>
        [DataMember]
        public string RegionText
        {
            get;
            set;
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        [DataMember]
        public Order OrderModel
        {
            get;
            set;
        }

        /// <summary>
        /// 订单详情信息集合
        /// </summary>
        [DataMember]
        public List<OrderDetailViewModel> OrderDetailList
        {
            get;
            set;
        }
    }
}