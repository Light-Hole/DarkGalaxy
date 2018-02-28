using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表SpecificationCategory的DAL层
    /// </summary>
    public class DAL_SpecificationCategory : BaseDAL<int, SpecificationCategory>
    {
        /// <summary>
        /// 查询商品规格分类主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Commodity_ID">商品规格分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<SpecificationCategory> SelectIntoSpecificationCategory_Commodity(int Commodity_ID)
        {
            //处理错误参数
            if (0 >= Commodity_ID)
            {
                return null;
            }
            else { }

            List<SpecificationCategory> result = null;

            //查询商品规格分类主键对应的全部记录
            string Where = "Commodity_ID = @DAL_Commodity_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Commodity_ID",Commodity_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }
    }
}