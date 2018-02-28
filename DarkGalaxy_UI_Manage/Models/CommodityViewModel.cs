using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 商品的ViewModel类
    /// </summary>
    public class CommodityViewModel
    {
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
        /// 商品详细信息集合
        /// </summary>
        [DataMember]
        public List<Model_Commodity_Details> CommodityDetailsList
        {
            get;
            set;
        }

        /// <summary>
        /// 商品规格分类信息
        /// </summary>
        [DataMember]
        public SpecificationCategory SpecCategoryModel
        {
            get;
            set;
        }

        /// <summary>
        /// 商品规格信息
        /// </summary>
        [DataMember]
        public Specification SpecificationModel
        {
            get;
            set;
        }
    }
}