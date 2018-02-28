using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 查询自定义菜单的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenuSelect_Result : IndividuationMenu_MenuID
    {
        /// <summary>
        /// 自定义菜单
        /// </summary>
        [DataMember]
        public CustomizeMenu menu;

        /// <summary>
        /// 个性化菜单
        /// </summary>
        [DataMember]
        public IndividuationMenu conditionalmenu;
    }
}
