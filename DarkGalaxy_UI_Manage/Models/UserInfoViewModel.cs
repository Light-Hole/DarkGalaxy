using DarkGalaxy_Model;
using System.Runtime.Serialization;

namespace DarkGalaxy_UI_Manage.Models
{
    /// <summary>
    /// 用户信息的ViewModel类
    /// </summary>
    [DataContract]
    public class UserInfoViewModel
    {
        /// <summary>
        /// 用户帐户信息
        /// </summary>
        [DataMember]
        public UserAccount UserAccountModel
        {
            get;
            set;
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        [DataMember]
        public UserInformation UserInfoModel
        {
            get;
            set;
        }
    }
}