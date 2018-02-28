using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Contacts的DAL层
    /// </summary>
    public class DAL_Contacts : BaseDAL<int, Contacts>
    {
        /// <summary>
        /// 查询用户帐户主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录或传入参数错误则返回null
        /// </summary>
        /// <param name="UserAccount_ID">用户帐户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Contacts> SelectIntoContacts_UserAccount(int UserAccount_ID)
        {
            //处理错误参数
            if (0 >= UserAccount_ID)
            {
                return null;
            }
            else { }

            List<Contacts> result = null;

            //查询联系人记录
            string Where = "UserAccount_ID = @DAL_UserAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserAccount_ID",UserAccount_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }
    }
}