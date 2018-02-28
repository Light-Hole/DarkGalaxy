using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 商品规格的ViewModel类
    /// </summary>
    [DataContract]
    public class SpecCategoryViewModel
    {
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
        /// 商品规格集合
        /// </summary>
        [DataMember]
        public List<Specification> SpecificationList
        {
            get;
            set;
        }
    }
}