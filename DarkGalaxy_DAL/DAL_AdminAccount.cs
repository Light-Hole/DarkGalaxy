using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表AdminAccount的DAL层
    /// </summary>
    public class DAL_AdminAccount : BaseDAL<int, AdminAccount>
    {
        /// <summary>
        /// 查询管理员帐户指定用户名的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录</returns>
        public AdminAccount SelectSingleIntoAdminAccount(string UserName)
        {
            AdminAccount result = null;

            //查询管理员帐户指定用户名的单条记录
            string Where = "UserName = @DAL_UserName and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserName",UserName){ DbType = DbType.String }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户指定用户名、密码的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>查询到的记录</returns>
        public AdminAccount SelectSingleIntoAdminAccount(string UserName, string Password)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                return null;
            }
            else { }

            AdminAccount result = null;

            //查询管理员帐户指定用户名、密码的单条记录
            string Where = "UserName = @DAL_UserName and Password = @DAL_Password  and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserName",UserName){ DbType = DbType.String },
                new SqlParameter("DAL_Password",Password){ DbType = DbType.String }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 模糊查询管理员帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectIntoAdminAccountLike(string UserName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(UserName))
            {
                return null;
            }
            else { }

            List<AdminAccount> result = null;

            //模糊查询管理员帐户指定用户名的全部记录
            string Where = "UserName like @DAL_likeUserName and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeUserName","%" + UserName + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页模糊查询管理员帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectIntoAdminAccountLike(int PageIndex, int PageSize, out int Total, string UserName)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(UserName)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<AdminAccount> result = null;

            //分页模糊查询管理员帐户指定用户名的全部记录
            string Where = "UserName like @DAL_likeUserName and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeUserName","%" + UserName + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }
    }
}