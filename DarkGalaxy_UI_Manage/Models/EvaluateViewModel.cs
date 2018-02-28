using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 评价的ViewModel类
    /// </summary>
    public class EvaluateViewModel
    {
        /// <summary>
        /// 评价信息
        /// </summary>
        [DataMember]
        public Evaluate EvaluateModel
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
    }
}