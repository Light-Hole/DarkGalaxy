using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// 结算的ViewModel类
    /// </summary>
    [DataContract]
    public class DenominateViewModel
    {
        /// <summary>
        /// 规格主键
        /// </summary>
        [DataMember]
        public int SpecID
        {
            get;
            set;
        }

        /// <summary>
        /// 商品规格数量
        /// </summary>
        [DataMember]
        public int SpecNumber
        {
            get;
            set;
        }
    }
}