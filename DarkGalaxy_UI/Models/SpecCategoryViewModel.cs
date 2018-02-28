using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// 规格分类的ViewModel类
    /// </summary>
    [DataContract]
    public class SpecCategoryViewModel
    {
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
        /// 规格信息集合
        /// </summary>
        [DataMember]
        public List<Specification> SpecificationList
        {
            get;
            set;
        }
    }
}