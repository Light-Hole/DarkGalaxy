using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表OrderPassenger的DAL层
    /// </summary>
    public class DAL_OrderPassenger : BaseDAL<int, OrderPassenger>
    {
        /// <summary>
        /// 查询用户订单主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录或传入参数错误则返回null
        /// </summary>
        /// <param name="Order_ID">订单主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderPassenger> SelectIntoOrderPassenger_Order(int Order_ID)
        {
            //处理错误参数
            if (0 >= Order_ID)
            {
                return null;
            }
            else { }

            List<OrderPassenger> result = null;

            //查询用户订单主键对应的全部记录
            string Where = "Order_ID = @DAL_Order_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Order_ID",Order_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }
    }
}