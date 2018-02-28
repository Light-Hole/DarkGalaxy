using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 产品的ViewModel类
    /// </summary>
    [DataContract]
    public class ProductViewModel
    {
        /// <summary>
        /// 全部分类集合
        /// </summary>
        [DataMember]
        public List<Category> CategoryList
        {
            get;
            set;
        }

        /// <summary>
        /// 产品分类信息
        /// </summary>
        [DataMember]
        public Category CategoryModel
        {
            get;
            set;
        }

        /// <summary>
        /// 产品信息
        /// </summary>
        [DataMember]
        public Product ProductModel
        {
            get;
            set;
        }
    }
}