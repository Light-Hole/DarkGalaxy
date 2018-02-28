using System.Runtime.Serialization;

namespace DarkGalaxy_Common
{
    /// <summary>
    /// 富文本图片上传
    /// </summary>
    [DataContract]
    public class LayuiEditData
    {
        /// <summary>
        /// 路径
        /// </summary>
        [DataMember]
        public string src = "/";

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string title = "图片名称";
    }
}
