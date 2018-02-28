using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat用户分析累计数量结果的Model类
    /// </summary>
    [DataContract]
    public class UserAnalyze_ResultCumulate : ResultCode
    {
        /// <summary>
        /// 统计数据列表
        /// </summary>
        [DataMember]
        public List<UserAnalyzeCumulate> list;
    }

    /// <summary>
    /// WeChat用户分析累计数量列表的Model类
    /// </summary>
    [DataContract]
    public class UserAnalyzeCumulate
    {
        /// <summary>
        /// 数据日期
        /// </summary>
        [DataMember]
        public string ref_date;

        /// <summary>
        /// 总用户量
        /// </summary>
        [DataMember]
        public int cumulate_user;
    }
}
