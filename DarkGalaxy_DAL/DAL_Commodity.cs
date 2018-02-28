using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Commodity的DAL层
    /// </summary>
    public class DAL_Commodity : BaseDAL<int, Commodity>
    {
        /// <summary>
        /// 模糊查询商品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectIntoCommodityLike(string Title)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Title))
            {
                return null;
            }
            else { }

            List<Commodity> result = null;

            //查询商品指定标题的记录
            string Where = "Title like @DAL_likeTitle and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeTitle","%" + Title + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页模糊查询商品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectIntoCommodityLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //查询商品记录
            string Where = "Title like @DAL_likeTitle and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeTitle","%" + Title + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页查询商品的全部有效记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectIntoCommodityValid(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //查询商品记录
            string Where = "DepartureDate > @DAL_Nowdate and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Nowdate",DateTime.Now){ DbType = DbType.DateTime }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页模糊查询商品的全部有效记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Site">地点</param>
        /// <param name="DepartureDate">出发日期</param>
        /// <param name="RegressionDate">返回日期</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectIntoCommodityValidLike(int PageIndex, int PageSize, out int Total, string Site = null, DateTime? DepartureDate = null, DateTime? RegressionDate = null)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //查询商品记录
            string Where = "DepartureDate > @DAL_Nowdate and Enabled = 1";
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("DAL_Nowdate", DateTime.Now) { DbType = DbType.DateTime });
            if (!String.IsNullOrEmpty(Site))
            {
                Where += " and (DepartureSite like @DAL_Site or RegressionSite like @DAL_Site)";
                ParameterList.Add(new SqlParameter("DAL_Site", "%" + Site + "%") { DbType = DbType.String });
            }
            else { }
            if (null != DepartureDate)
            {
                Where += " and DepartureDate >= @DAL_DepartureDate";
                ParameterList.Add(new SqlParameter("DAL_DepartureDate", DepartureDate) { DbType = DbType.DateTime });
            }
            else { }
            if (null != RegressionDate)
            {
                Where += " and RegressionDate <= @DAL_RegressionDate";
                ParameterList.Add(new SqlParameter("DAL_RegressionDate", RegressionDate) { DbType = DbType.DateTime });
            }
            else { }
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, ParameterList.ToArray());

            return result;
        }
    }
}