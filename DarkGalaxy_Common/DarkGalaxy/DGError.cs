using System.Runtime.Serialization;

namespace DarkGalaxy_Common.DarkGalaxy
{
    /// <summary>
    /// DarkGalaxy项目自定义错误类
    /// </summary>
    [DataContract]
    public class DGError
    {
        private string _ErrorCode = "500";

        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public string ErrorCode
        {
            get
            {
                return _ErrorCode;
            }
            set
            {
                _ErrorCode = value;
            }
        }

        private string _ErrorDescribe = "未知错误";

        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember]
        public string ErrorDescribe
        {
            get
            {
                return _ErrorDescribe;
            }
            set
            {
                _ErrorDescribe = value;
            }
        }

        private string _ErrorContent = "这是一个未知的错误";

        /// <summary>
        /// 错误详细信息
        /// </summary>
        [DataMember]
        public string ErrorContent
        {
            get
            {
                return _ErrorContent;
            }
            set
            {
                _ErrorContent = value;
            }
        }
    }
}
