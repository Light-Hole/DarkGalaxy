using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 订单详情的ViewModel类
    /// </summary>
    public class OrderDetailViewModel : CommodityViewModel
    {
        /// <summary>
        /// 订单详情信息
        /// </summary>
        [DataMember]
        public OrderDetail OrderDetailModel
        {
            get;
            set;
        }
    }
}