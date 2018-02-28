using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_IBLL
{
    /// <summary>
    /// 统计接口
    /// </summary>
    public interface IStatistics<T>
    {
        /// <summary>
        /// 统计数据，返回统计获取的数据值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="days">统计天数</param>
        /// <returns>统计获取的数据值</returns>
        T StatisticsData(int days);

        /// <summary>
        /// 统计数据，返回统计获取的数据值
        /// </summary>
        /// <param name="StartDateTime">起始时间</param>
        /// <param name="EndDateTime">结束时间</param>
        /// <returns>统计获取的数据值</returns>
        T StatisticsData(DateTime startDateTime, DateTime endDateTime);
    }
}
