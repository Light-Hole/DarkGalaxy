using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 时间帮助类
    /// 提供一系列对于时间的操作
    /// </summary>
    public static class Helper_Time
    {
        /// <summary>
        /// 根据起始时间与结束时间生成时间戳，返回生成的时间戳
        /// 生成失败则返回null
        /// </summary>
        /// <param name="startDateTime">起始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <returns>生成的时间戳</returns>
        public static string CreateTimeStamp(DateTime startDateTime, DateTime endDateTime)
        {
            //处理错误参数
            if ((startDateTime > DateTime.MaxValue) || (startDateTime < DateTime.MinValue) || (endDateTime > DateTime.MaxValue) || (endDateTime < DateTime.MinValue) || (startDateTime < endDateTime))
            {
                return null;
            }
            else { }

            string result = null;

            //创建时间戳
            TimeSpan tmsStampSpan = startDateTime - endDateTime;
            result = Convert.ToInt64(tmsStampSpan.TotalSeconds).ToString();

            return result;
        }
    }
}
