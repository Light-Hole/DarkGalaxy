using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat用户分析的Model类
    /// </summary>
    [DataContract]
    public class UserAnalyze
    {
        /// <summary>
        /// 起始日期（格式：yyyy-MM-dd）
        /// </summary>
        [DataMember]
        public string begin_date;

        /// <summary>
        /// 结束日期（格式：yyyy-MM-dd）
        /// </summary>
        [DataMember]
        public string end_date;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="beginDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        public UserAnalyze(DateTime beginDate, DateTime endDate)
        {
            TimeSpan SpanDate = endDate - beginDate;
            DateTime StartDate = new DateTime(2014, 12, 1);
            DateTime LastDate = DateTime.Now.AddDays(-1);
            if (StartDate > beginDate)
            {
                beginDate = StartDate;
            }
            else { }
            if (LastDate < endDate)
            {
                endDate = LastDate;
            }
            else { }
            if (7 < SpanDate.TotalDays)
            {
                begin_date = beginDate.ToString("yyyy-MM-dd");
                end_date = beginDate.AddDays(7).ToString("yyyy-MM-dd");
            }
            else
            {
                begin_date = beginDate.ToString("yyyy-MM-dd");
                end_date = endDate.ToString("yyyy-MM-dd");
            }
        }
    }
}
