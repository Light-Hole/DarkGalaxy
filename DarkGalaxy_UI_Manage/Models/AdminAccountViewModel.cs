using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 管理员帐户的ViewModel类
    /// </summary>
    [DataContract]
    public class AdminAccountViewModel
    {
        /// <summary>
        /// 管理员帐户信息
        /// </summary>
        [DataMember]
        public AdminAccount AdminAccountModel
        {
            get;
            set;
        }

        /// <summary>
        /// 管理员信息
        /// </summary>
        [DataMember]
        public AdminInformation AdminInfoModel
        {
            get;
            set;
        }
    }
}