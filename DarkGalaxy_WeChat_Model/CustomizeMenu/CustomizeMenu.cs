using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 自定义菜单的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenu
    {
        /// <summary>
        /// 自定义菜单按钮列表
        /// </summary>
        [DataMember]
        public List<CustomizeMenu_Button> button;
    }

    /// <summary>
    /// 自定义菜单按钮的Model类
    /// </summary>
    [DataContract]
    public class CustomizeMenu_Button
    {
        /// <summary>
        /// 按钮类型
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string type;

        /// <summary>
        /// 按钮标题
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name;

        /// <summary>
        /// 消息接口推送key值
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string key;

        /// <summary>
        /// 按钮网页链接
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string url;

        /// <summary>
        /// 调用新增永久素材接口返回的合法media_id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string media_id;

        /// <summary>
        /// 小程序appid
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string appid;

        /// <summary>
        /// 小程序页面路径
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string pagepath;

        /// <summary>
        /// 二级自定义菜单按钮
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<CustomizeMenu_Button> sub_button;

        /// <summary>
        /// 构造函数，初始化按钮类型
        /// </summary>
        /// <param name="name">按钮标题</param>
        /// <param name="customizeMenusEventTypes">WeChat自定义菜单事件类型</param>
        public CustomizeMenu_Button(string name, CustomizeMenusEventType customizeMenusEventTypes)
        {
            this.name = name;
            type = Enum.GetName(typeof(CustomizeMenusEventType), customizeMenusEventTypes);
        }
    }
}
