using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 联系人的ViewModel类
    /// </summary>
    [DataContract]
    public class ContactsViewModel
    {
        /// <summary>
        /// 联系人信息
        /// </summary>
        [DataMember]
        public Contacts ContactsModel
        {
            get;
            set;
        }

        /// <summary>
        /// 联系人所在地区文本
        /// </summary>
        [DataMember]
        public string RegionText
        {
            get;
            set;
        }
    }
}