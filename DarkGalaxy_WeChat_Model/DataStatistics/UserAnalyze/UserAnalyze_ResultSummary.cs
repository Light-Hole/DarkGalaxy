using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat用户分析增减数据结果的Model类
    /// </summary>
    [DataContract]
    public class UserAnalyze_ResultSummary : ResultCode
    {
        /// <summary>
        /// 统计数据列表
        /// </summary>
        [DataMember]
        public List<UserAnalyzeSummary> list;
    }

    /// <summary>
    /// WeChat用户分析增减数据列表的Model类
    /// </summary>
    [DataContract]
    public class UserAnalyzeSummary
    {
        /// <summary>
        /// 数据日期
        /// </summary>
        [DataMember]
        public string ref_date;

        /// <summary>
        /// 用户渠道
        /// </summary>
        [DataMember]
        public int user_source;

        /// <summary>
        /// 新增用户数量
        /// </summary>
        [DataMember]
        public int new_user;

        /// <summary>
        /// 取消关注用户数量
        /// </summary>
        [DataMember]
        public int cancel_user;
    }
}
