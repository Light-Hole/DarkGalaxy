using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat图文的Model类
    /// </summary>
    [DataContract]
    public class Material_News
    {
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string title;

        /// <summary>
        /// 封面图片素材ID
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string thumb_media_id;

        /// <summary>
        /// 作者
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string author;

        /// <summary>
        /// 图文摘要
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string digest;

        /// <summary>
        /// 显示封面（0：不显示，1：显示）
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int show_cover_pic;

        /// <summary>
        /// 图文内容
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string content;

        /// <summary>
        /// 图文消息原文URL
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string content_source_url;

        /// <summary>
        /// 图文页链接地址
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string url;
    }
}
