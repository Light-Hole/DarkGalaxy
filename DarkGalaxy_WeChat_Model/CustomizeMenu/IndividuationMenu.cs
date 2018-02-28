using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 个性菜单的Model类
    /// </summary>
    [DataContract]
    public class IndividuationMenu : CustomizeMenu
    {
        /// <summary>
        /// 菜单匹配规则
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public IndividuationMenu_Matchrule matchrule;

        /// <summary>
        /// 菜单ID
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string menuid;
    }

    /// <summary>
    /// 个性菜单匹配规则的Model类
    /// </summary>
    [DataContract]
    public class IndividuationMenu_Matchrule
    {
        /// <summary>
        /// 用户标签的id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string tag_id;

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string sex;

        /// <summary>
        /// 客户端版本
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string client_platform_type;

        /// <summary>
        /// 国家信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string country;

        /// <summary>
        /// 省份信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string province;

        /// <summary>
        /// 城市信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string city;

        /// <summary>
        /// 语言信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string language;
    }
}
