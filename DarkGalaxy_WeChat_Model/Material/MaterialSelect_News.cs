using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat查询图文素材的Model类
    /// </summary>
    [DataContract]
    public class MaterialSelect_News : ResultCode
    {
        /// <summary>
        /// 永久素材列表
        /// </summary>
        [DataMember]
        public List<Material_News> news_item;
    }
}
