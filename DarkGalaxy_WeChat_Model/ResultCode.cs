using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat返回状态的Model类
    /// </summary>
    [DataContract]
    public class ResultCode
    {
        /// <summary>
        /// 返回的状态码，请求成功：0
        /// </summary>
        [DataMember]
        public int errcode;

        /// <summary>
        /// 返回的状态消息
        /// </summary>
        [DataMember]
        public string errmsg;
    }
}
