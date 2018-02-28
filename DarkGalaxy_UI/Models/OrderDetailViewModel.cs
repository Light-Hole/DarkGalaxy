using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// 订单详情的ViewModel类
    /// </summary>
    [DataContract]
    public class OrderDetailViewModel
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

        /// <summary>
        /// 商品信息
        /// </summary>
        [DataMember]
        public Commodity CommodityModel
        {
            get;
            set;
        }

        /// <summary>
        /// 规格分类信息
        /// </summary>
        [DataMember]
        public SpecificationCategory SpecCategoryModel
        {
            get;
            set;
        }

        /// <summary>
        /// 规格信息
        /// </summary>
        [DataMember]
        public Specification SpecificationModel
        {
            get;
            set;
        }
    }
}