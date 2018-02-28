using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表WeChatMenu的DAL层
    /// </summary>
    public class DAL_WeChatMenu : BaseDAL<int, WeChatMenu>
    {
        /// <summary>
        /// 修改WeChat菜单的全部记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="IDArray">WeChat菜单主键集合</param>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateIntoWeChatMenuSetEmploy(int[] IDArray, bool Employ)
        {
            //处理错误参数
            if ((null == IDArray) || (0 >= IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的全部记录的Employ字段值
            string CommandText = "update WeChatMenu set Employ = @DAL_Employ where ID in ({0}) and Enabled = 1";
            string WhereIn = null;
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(new SqlParameter("DAL_Employ", Employ) { DbType = DbType.Boolean });
            for (int i = 0; i < IDArray.Length; i++)
            {
                //设置参数查询条件
                string ParametersName = ("DAL_IDArray" + i);
                WhereIn += ("@" + ParametersName + ",");

                //设置参数
                SqlParameter Parameter = new SqlParameter(ParametersName, IDArray[i]);
                ParameterList.Add(Parameter);
            }
            WhereIn = WhereIn.TrimEnd(',');
            CommandText = String.Format(CommandText, WhereIn);
            result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, ParameterList.ToArray()) == 0 ? false : true);

            return result;
        }

        /// <summary>
        /// 修改WeChat菜单的单条记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleIntoWeChatMenuSetEmploy(int ID, bool Employ)
        {
            //处理错误参数
            if (0 > ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的单条记录的Employ字段值
            string CommandText = "update WeChatMenu set Employ = @DAL_Employ where ID = @DAL_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Employ",Employ){ DbType = DbType.Boolean },
                new SqlParameter("DAL_ID",ID){ DbType = DbType.Int32 }
            };
            result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, Parameters) == 0 ? false : true);

            return result;
        }

        /// <summary>
        /// 修改顶级WeChat菜单的全部记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateTopIntoWeChatMenuSetEmploy(bool Employ)
        {
            bool result = false;

            //修改WeChat菜单的全部记录的Employ字段值
            string CommandText = "update WeChatMenu set Employ = @DAL_Employ where ParentID = 0 and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Employ",Employ){ DbType = DbType.Boolean }
            };
            result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, Parameters) == 0 ? false : true);

            return result;
        }
    }
}
