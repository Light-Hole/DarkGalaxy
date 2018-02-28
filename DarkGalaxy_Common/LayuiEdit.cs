using System.Runtime.Serialization;

namespace DarkGalaxy_Common
{
    /// <summary>
    /// Layui富文本
    /// </summary>
    [DataContract]
    public class LayuiEdit
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [DataMember]
        public int code = 1;

        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember]
        public string msg = "未知错误";

        /// <summary>
        /// 返回数据
        /// </summary>
        [DataMember]
        public LayuiEditData data;
    }
}
