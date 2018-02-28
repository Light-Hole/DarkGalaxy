using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// 规格的ViewModel类
    /// </summary>
    [DataContract]
    public class SpecificationViewModel
    {
        /// <summary>
        /// 规格信息
        /// </summary>
        [DataMember]
        public Specification SpecificationModel
        {
            get;
            set;
        }

        /// <summary>
        /// 规格购买数量
        /// </summary>
        [DataMember]
        public int Number
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