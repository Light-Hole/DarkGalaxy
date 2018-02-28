using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 个性菜单ID的Model类
    /// </summary>
    [DataContract]
    public class IndividuationMenu_MenuID : ResultCode
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [DataMember]
        public string menuid;
    }
}
