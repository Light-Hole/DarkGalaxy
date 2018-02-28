using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表AdminInformation的DAL层
    /// </summary>
    public class DAL_AdminInformation : BaseDAL<int, AdminInformation>
    {
        /// <summary>
        /// 删除管理员帐户主键对应的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="AdminAccount_IDArray">管理员帐户主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleIntoAdminInformation_AdminAccount(int[] AdminAccount_IDArray)
        {
            //处理错误参数
            if (0 == AdminAccount_IDArray.Length)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除管理员帐户主键对应的单条记录
            string Where = "AdminAccount_ID in ({0}) and Enabled = 1";
            string WhereIn = null;
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            for (int i = 0; i < AdminAccount_IDArray.Length; i++)
            {
                //设置参数查询条件
                string ParametersName = ("DAL_AdminAccount_ID" + i);
                WhereIn += ("@" + ParametersName + ",");

                //设置参数
                SqlParameter Parameter = new SqlParameter(ParametersName, AdminAccount_IDArray[i]);
                ParameterList.Add(Parameter);
            }
            WhereIn = WhereIn.TrimEnd(',');
            Where = String.Format(Where, WhereIn);
            result = DeleteIntoTable(Where, ParameterList.ToArray());

            return result;
        }

        /// <summary>
        /// 删除管理员帐户主键对应的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="AdminAccount_ID">管理员帐户主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleIntoAdminInformation_AdminAccount(int AdminAccount_ID)
        {
            //处理错误参数
            if (0 >= AdminAccount_ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除管理员帐户主键对应的单条记录
            string Where = "AdminAccount_ID = @DAL_AdminAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_AdminAccount_ID",AdminAccount_ID){ DbType = DbType.Int32 }
            };
            result = DeleteIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 修改管理员帐户主键对应的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="AdminAccount_ID">管理员信息主键</param>
        /// <param name="UpdateModel">管理员信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleIntoAdminInformation_AdminAccount(int AdminAccount_ID, AdminInformation UpdateModel)
        {
            //处理错误参数
            if ((0 >= AdminAccount_ID) || (null == UpdateModel))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改管理员帐户主键对应的单条记录
            string Where = "AdminAccount_ID = @DAL_AdminAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_AdminAccount_ID",AdminAccount_ID){ DbType = DbType.Int32 }
            };
            result = UpdateIntoTable(UpdateModel, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询传入管理员帐户主键的单条记录，返回查询到的记录
        /// 未查询到记录或传入参数错误则返回null
        /// </summary>
        /// <param name="AdminAccount_ID">管理员帐户主键</param>
        /// <returns>查询到的记录</returns>
        public AdminInformation SelectSingleIntoAdminInformation_AdminAccount(int AdminAccount_ID)
        {
            //处理错误参数
            if (0 >= AdminAccount_ID)
            {
                return null;
            }
            else { }

            AdminInformation result = new AdminInformation();

            //查询传入管理员帐户主键的单条记录
            string Where = "AdminAccount_ID = @DAL_AdminAccount_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_AdminAccount_ID",AdminAccount_ID){ DbType = DbType.Int32 }
            };
            result = SelectSingleIntoTable(Where, Parameters);

            return result;
        }
    }
}