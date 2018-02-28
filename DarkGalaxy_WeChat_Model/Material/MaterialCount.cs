using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat素材数量的Model类
    /// </summary>
    [DataContract]
    public class MaterialCount : ResultCode
    {
        /// <summary>
        /// 语音总数量
        /// </summary>
        [DataMember]
        public int voice_count;

        /// <summary>
        /// 视频总数量
        /// </summary>
        [DataMember]
        public int video_count;

        /// <summary>
        /// 图片总数量
        /// </summary>
        [DataMember]
        public int image_count;

        /// <summary>
        /// 图文总数量
        /// </summary>
        [DataMember]
        public int news_count;
    }
}
