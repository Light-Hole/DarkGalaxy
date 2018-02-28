using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_Common.DarkGalaxy
{
    /// <summary>
    /// DarkGalaxy项目自定义返回数据类
    /// </summary>
    /// <typeparam name="T">主体数据类型</typeparam>
    [DataContract]
    public class DGResultData<T>
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

        private int _PageIndex = 0;

        /// <summary>
        /// 分页索引，默认值：0
        /// </summary>
        [DataMember]
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private int _PageSize = 0;

        /// <summary>
        /// 分页大小，默认值：0
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        private int _Total = 0;

        /// <summary>
        /// 分页数据总数，默认值：0
        /// </summary>
        [DataMember]
        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        /// <summary>
        /// Json主体数据
        /// </summary>
        [DataMember]
        public T Data
        {
            get;
            set;
        }

        /// <summary>
        /// Json主体数据集合
        /// </summary>
        [DataMember]
        public List<T> Datas
        {
            get;
            set;
        }
    }
}
