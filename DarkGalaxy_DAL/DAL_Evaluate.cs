using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Evaluate的DAL层
    /// </summary>
    public class DAL_Evaluate : BaseDAL<int, Evaluate>
    {
        /// <summary>
        /// 修改评价指定主键的记录的AuditStatus与AdminAccount_ID字段值，返回修改是否成功
        /// </summary>
        /// <param name="ID">评价主键</param>
        /// <param name="AuditStatus">审核状态</param>
        /// <param name="AdminAccount_ID">管理员账户主键</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateIntoEvaluateSetAuditStatus(int ID, bool AuditStatus, int AdminAccount_ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //修改评价审核状态
            string CommandText = "update OrderEvaluate set AuditStatus = @DAL_AuditStatus,AdminAccount_ID = @DAL_AdminAccount_ID where ID = @DAL_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_ID",ID){ DbType = DbType.Int32 },
                new SqlParameter("DAL_AuditStatus",AuditStatus){ DbType = DbType.Boolean },
                new SqlParameter("DAL_AdminAccount_ID",AdminAccount_ID){ DbType = DbType.Int32 }
            };
            result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, Parameters) == 0 ? false : true);

            return result;
        }

        /// <summary>
        /// 查询未审核的记录数量，返回查询到的未审核记录数量
        /// </summary>
        /// <param name="Order_ID">订单主键</param>
        /// <returns></returns>
        public int SelectIntoEvaluateNotAudit(int Order_ID)
        {
            //处理错误参数
            if (0 >= Order_ID)
            {
                return 0;
            }
            else { }

            int result = 0;

            //查询未审核的全部记录
            string CommandText = "select count(*) from OrderEvaluate where Order_ID = @DAL_Order_ID and AdminAccount_ID is null";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Order_ID",Order_ID){ DbType = DbType.Int32 }
            };
            result = (int)Helper_DataBase_SQL.ExecuteScalar(CommandText, CommandType.Text, Parameters);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserAccount_ID">用户帐户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Evaluate> SelectIntoEvaluate_UserAccount(int UserAccount_ID)
        {
            //处理错误参数
            if (0 >= UserAccount_ID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

            //查询用户帐户主键对应的全部记录
            string Where = "UserAccount_ID = @DAL_UserAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserAccount_ID",UserAccount_ID){ DbType = DbType.Int32 }
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
        public List<Evaluate> SelectIntoEvaluate_Commodity(int Commodity_ID)
        {
            //处理错误参数
            if (0 >= Commodity_ID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

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
        public List<Evaluate> SelectIntoEvaluate_Order(int Order_ID)
        {
            //处理错误参数
            if (0 >= Order_ID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

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