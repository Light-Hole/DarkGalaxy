using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表UserInformation的DAL层
    /// </summary>
    public class DAL_UserInformation : BaseDAL<int, UserInformation>
    {
        /// <summary>
        /// 删除用户帐户主键对应的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="UserAccount_ID">用户帐户主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleIntoUserInformation_UserAccount(int UserAccount_ID)
        {
            //处理错误参数
            if (0 >= UserAccount_ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除用户帐户主键对应的单条记录
            string Where = "UserAccount_ID = @DAL_UserAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserAccount_ID",UserAccount_ID){ DbType = DbType.Int32 }
            };
            result = DeleteIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 修改用户帐户主键对应的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="UserAccount_ID">用户信息主键</param>
        /// <param name="UpdateModel">用户信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleIntoUserInformation_UserAccount(int UserAccount_ID, UserInformation UpdateModel)
        {
            //处理错误参数
            if ((0 >= UserAccount_ID) || (null == UpdateModel))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户帐户主键对应的单条记录
            string Where = "UserAccount_ID = @DAL_UserAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserAccount_ID",UserAccount_ID){ DbType = DbType.Int32 }
            };
            result = UpdateIntoTable(UpdateModel, Where,Parameters);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的单条记录，返回查询到的记录
        /// 未查询到记录或传入参数错误则返回null
        /// </summary>
        /// <param name="UserAccount_ID">用户帐户主键</param>
        /// <returns>查询到的记录</returns>
        public UserInformation SelectSingleIntoUserInformation_UserAccount(int UserAccount_ID)
        {
            //处理错误参数
            if (0 >= UserAccount_ID)
            {
                return null;
            }
            else { }

            UserInformation result = new UserInformation();

            //查询用户帐户主键对应的单条记录
            string Where = "UserAccount_ID = @DAL_UserAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_UserAccount_ID",UserAccount_ID){ DbType = DbType.Int32 }
            };
            result = SelectSingleIntoTable(Where, Parameters);
            
            return result;
        }
    }
}