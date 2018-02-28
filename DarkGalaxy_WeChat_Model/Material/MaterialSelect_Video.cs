using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat查询视频素材的Model类
    /// </summary>
    [DataContract]
    public class MaterialSelect_Video : ResultCode
    {
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string description;

        /// <summary>
        /// 下载链接地址
        /// </summary>
        [DataMember]
        public string down_url;
    }
}
