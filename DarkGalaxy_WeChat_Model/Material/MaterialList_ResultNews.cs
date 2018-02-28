using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat图文素材列表结果的Model类
    /// </summary>
    [DataContract]
    public class MaterialList_ResultNews : ResultCode
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
        /// 图文素材列表
        /// </summary>
        [DataMember]
        public List<NewsList> item;
    }

    /// <summary>
    /// WeChat图文素材列表的Model类
    /// </summary>
    [DataContract]
    public class NewsList : MaterialMediaID
    {
        /// <summary>
        /// 图文素材内容
        /// </summary>
        [DataMember]
        public NewsListContent content;

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public string update_time;
    }

    /// <summary>
    /// WeChat图文素材内容的Model类
    /// </summary>
    [DataContract]
    public class NewsListContent
    {
        /// <summary>
        /// 图文素材列表
        /// </summary>
        [DataMember]
        public List<Material_News> news_item;
    }
}
