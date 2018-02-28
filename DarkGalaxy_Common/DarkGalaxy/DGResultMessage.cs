using System.Runtime.Serialization;

namespace DarkGalaxy_Common.DarkGalaxy
{
    /// <summary>
    /// DarkGalaxy项目自定义返回消息类
    /// </summary>
    [DataContract]
    public class DGResultMessage
    {
        private ResultCodeType _Code = ResultCodeType.UnknownError;

        /// <summary>
        /// Json状态码，默认值：DGJsonCodeType.UnknownError
        /// </summary>
        [DataMember]
        public ResultCodeType Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Message = "未知错误";

        /// <summary>
        /// Json消息，默认值："UnknownError"
        /// </summary>
        [DataMember]
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
    }
}
