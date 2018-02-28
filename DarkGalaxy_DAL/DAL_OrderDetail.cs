using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表OrderDetail的DAL层
    /// </summary>
    public class DAL_OrderDetail : BaseDAL<int, OrderDetail>
    {
        /// <summary>
        /// 查询商品规格主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Specification_ID">商品规格主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectIntoOrderDetail_Specification(int Specification_ID)
        {
            //处理错误参数
            if (0 >= Specification_ID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品规格主键对应的全部记录
            string Where = "Specification_ID = @DAL_Specification_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Specification_ID",Specification_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询商品规格分类主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="SpecificationCategory_ID">商品规格分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectIntoOrderDetail_SpecificationCategory(int SpecificationCategory_ID)
        {
            //处理错误参数
            if (0 >= SpecificationCategory_ID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品规格分类主键对应的全部记录
            string Where = "SpecificationCategory_ID = @DAL_SpecificationCategory_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_SpecificationCategory_ID",SpecificationCategory_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询商品主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Commodity_ID">商品主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectIntoOrderDetail_Commodity(int Commodity_ID)
        {
            //处理错误参数
            if (0 >= Commodity_ID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品主键对应的全部记录
            string Where = "Commodity_ID = @DAL_Commodity_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Commodity_ID",Commodity_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询订单主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Order_ID">订单主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectIntoOrderDetail_Order(int Order_ID)
        {
            //处理错误参数
            if (0 >= Order_ID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询订单主键对应的全部记录
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