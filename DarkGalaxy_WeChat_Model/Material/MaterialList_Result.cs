using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat素材列表结果的Model类
    /// </summary>
    [DataContract]
    public class MaterialList_Result : ResultCode
    {
        /// <summary>
        /// 素材总数
        /// </summary>
        [DataMember]
        public int total_count;

        /// <summary>
        /// 获取的素材数量
        /// </summary>
        [DataMember]
        public int item_count;

        /// <summary>
        /// 素材列表
        /// </summary>
        [DataMember]
        public List<MaterialItemList> item;
    }

    /// <summary>
    /// WeChat素材列表的Model类
    /// </summary>
    public class MaterialItemList : MaterialMediaID
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string name;

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public string update_time;

        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember]
        public string url;
    }
}
