using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Order的DAL层
    /// </summary>
    public class DAL_Order : BaseDAL<int, Order>
    {
        /// <summary>
        /// 修改订单指定主键的订单状态，返回修改是否成功
        /// </summary>
        /// <param name="ID">订单主键</param>
        /// <param name="Status">订单状态</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateIntoOrderSetStatus(int ID, int Status)
        {
            bool result = false;

            //修改订单指定主键的订单状态
            string CommandText = "update [Order] set Status = @DAL_Status where ID = @DAL_ID";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_ID",ID){ DbType = DbType.Int32 },
                new SqlParameter("DAL_Status",Status){ DbType = DbType.Int32 }
            };
            result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, Parameters) == 0 ? false : true);

            return result;
        }

        /// <summary>
        /// 查询订单指定订单号的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderNumber">订单号/微信订单号</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectIntoOrder(int PageIndex, int PageSize, out int Total, string OrderNumber)
        {
            List<Order> result = null;

            //查询订单记录
            string Where = "OrderNumber = @DAL_OrderNumber or WeChatOrderNumber = @DAL_OrderNumber and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_OrderNumber",OrderNumber){ DbType = DbType.String }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询订单指定条件的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <param name="StartDate">创建订单起始时间</param>
        /// <param name="EndDate">创建订单结束时间</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectIntoOrder(int PageIndex, int PageSize, out int Total, OrderStatusType? OrderStatus = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            //处理错误参数
            if ((null != StartDate) && (null != EndDate) && (EndDate <= StartDate))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //查询订单记录
            string Where = "Enabled = 1";
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            if (null != OrderStatus)
            {
                Where += " and Status = @DAL_Status";
                ParameterList.Add(new SqlParameter("DAL_Status", OrderStatus) { DbType = DbType.Int32 });
            }
            else { }
            if (null != StartDate)
            {
                Where += " and CreateDateTime >= @DAL_StartDate";
                ParameterList.Add(new SqlParameter("DAL_StartDate", StartDate) { DbType = DbType.DateTime });
            }
            else { }
            if (null != EndDate)
            {
                Where += " and CreateDateTime < @DAL_EndDate";
                ParameterList.Add(new SqlParameter("DAL_EndDate", EndDate) { DbType = DbType.DateTime });
            }
            else { }
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, ParameterList.ToArray());

            return result;
        }

        /// <summary>
        /// 查询订单指定状态的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderStatues">订单状态集合</param>
        /// <param name="UserAccount_ID">用户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectIntoOrder_UserAccount(int PageIndex, int PageSize, out int Total, OrderStatusType[] OrderStatues, int UserAccount_ID)
        {
            List<Order> result = null;

            //查询订单指定状态的全部记录
            string strWhere = "Enabled = 1 and Status in ({0}) and UserAccount_ID = @DAL_UserAccount_ID";
            string strIn = null;
            List<SqlParameter> lisParameter = new List<SqlParameter>();
            lisParameter.Add(new SqlParameter("DAL_UserAccount_ID", UserAccount_ID) { DbType = DbType.Int32 });
            for (int i = 0; i < OrderStatues.Length; i++)
            {
                string strInName = ("@DAL_Status" + i);
                if (0 != i)
                {
                    strIn = String.Join(",", strIn, strInName);
                }
                else
                {
                    strIn = strInName;
                }
                lisParameter.Add(new SqlParameter(strInName, Convert.ToInt32(OrderStatues[i])) { DbType = DbType.Int32 });
            }
            strWhere = String.Format(strWhere, strIn);
            result = SelectIntoTable(PageIndex, PageSize, out Total, strWhere, lisParameter.ToArray());

            return result;
        }

        /// <summary>
        /// 查询退款订单号的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="RefundNumber">退款订单号</param>
        /// <returns>查询到的记录</returns>
        public Order SelectSingleIntoOrderByRefund(string RefundNumber)
        {
            Order result = null;

            string Where = "RefundNumber = @DAL_RefundNumber";
            SqlParameter Parameter = new SqlParameter("DAL_RefundNumber", RefundNumber) { DbType = DbType.String };
            result = SelectSingleIntoTable(Where, Parameter);

            return result;
        }

        /// <summary>
        /// 查询订单号的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OrderNumber">订单号</param>
        /// <returns>查询到的记录</returns>
        public Order SelectSingleIntoOrderByNumber(string OrderNumber)
        {
            Order result = null;

            string Where = "OrderNumber = @DAL_OrderNumber";
            SqlParameter Parameter = new SqlParameter("DAL_OrderNumber", OrderNumber) { DbType = DbType.String };
            result = SelectSingleIntoTable(Where, Parameter);

            return result;
        }

        /// <summary>
        /// 查询订单总价数据，返回查询到的数据
        /// </summary>
        /// <param name="startDateTime">起始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <returns>查询到的数据</returns>
        public double SelectOrderTotalPrice(DateTime startDateTime, DateTime endDateTime)
        {
            double result = 0;

            //查询订单价格
            string strCommandText = "select sum(TotalPrice) from [Order] where Status = 80 and CreateDateTime >= @DAL_StartDateTime and CreateDateTime < @DAL_EndDateTime and Enabled = 1";
            SqlParameter[] arrSqlParameter =
            {
                new SqlParameter("DAL_StartDateTime",startDateTime){ DbType = DbType.DateTime },
                new SqlParameter("DAL_EndDateTime",endDateTime){ DbType = DbType.DateTime }
            };
            result = (double)Helper_DataBase_SQL.ExecuteScalar(strCommandText, CommandType.Text, arrSqlParameter);

            return result;
        }
    }
}