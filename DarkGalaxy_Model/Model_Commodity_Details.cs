using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 表Commodity的Details字段Model层
    /// </summary>
    [DataContract]
    public class Model_Commodity_Details
    {
        /// <summary>
        /// 行程时间
        /// </summary>
        [DataMember]
        public string Date
        {
            get;
            set;
        }

        /// <summary>
        /// 行程标题
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 行程内容
        /// </summary>
        [DataMember]
        public string Content
        {
            get;
            set;
        }
    }
}
