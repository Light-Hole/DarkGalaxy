using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表UserAccount的DAL层
    /// </summary>
    public class DAL_UserAccount : BaseDAL<int, UserAccount>
    {
        /// <summary>
        /// 模糊查询用户帐户指定帐号名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">帐号名</param>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectIntoUserAccountLike(string AccountName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName))
            {
                return null;
            }
            else { }

            List<UserAccount> result = null;

            //查询用户帐户指定帐号名的记录
            string Where = "(Email like @DAL_likeAccountName or Phone like @DAL_likeAccountName or UserName like @DAL_likeAccountName) and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeAccountName","%" + AccountName + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页模糊查询用户帐户指定帐号名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="AccountName">帐号名</param>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectIntoUserAccountLike(int PageIndex, int PageSize, out int Total, string AccountName)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(AccountName)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<UserAccount> result = null;

            //查询用户帐户记录
            string Where = "(Email like @DAL_likeAccountName or Phone like @DAL_likeAccountName or UserName like @DAL_likeAccountName) and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeAccountName","%" + AccountName + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定帐号名（手机、邮箱、个性帐号）的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">帐号名</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleIntoUserAccount(string AccountName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定帐号名（手机、邮箱、个性帐号）的记录
            string Where = "(UserName = @DAL_AccountName or Email = @DAL_AccountName or Phone = @DAL_AccountName) and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_AccountName",AccountName){ DbType = DbType.String }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定帐号名（手机、邮箱、个性帐号）、密码的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">帐号名</param>
        /// <param name="Password">密码</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleIntoUserAccount(string AccountName, string Password)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName) || String.IsNullOrEmpty(Password))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定帐号名（手机、邮箱、个性帐号）、密码的记录
            string Where = "(UserName = @DAL_AccountName or Email = @DAL_AccountName or Phone = @DAL_AccountName) and Password = @DAL_Password and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_AccountName",AccountName){ DbType = DbType.String },
                new SqlParameter("DAL_Password",Password){ DbType = DbType.String }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定OpenID的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OpenID">WeChat用户唯一标识</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleIntoUserAccount_WeChat(string OpenID)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(OpenID))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定OpenID、密码的记录
            string Where = "OpenID = @DAL_OpenID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_OpenID",OpenID){ DbType = DbType.String }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }
    }
}