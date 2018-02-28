using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// SQLServer数据库帮助类
    /// 提供一系列对于SQLServer数据库的操作
    /// 默认使用配置文件的connectionStrings节[name="DefaultConnectionString"]作为数据库连接字符串
    /// </summary>
    public static class Helper_DataBase_SQL
    {
        private static string _DefaultConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

        /// <summary>
        /// 默认数据库连接字符串，默认值：配置文件connectionStrings节[name="ConnectionString"]
        /// </summary>
        public static string DefaultConnectionString
        {
            get { return _DefaultConnectionString; }
            set { _DefaultConnectionString = value; }
        }

        /// <summary>
        /// 数据库执行传入的命令，返回数据库中受影响的行数
        /// 无受影响行数则返回0
        /// </summary>
        /// <param name="CommandText">执行的命令(SQL语句/表名/存储过程)</param>
        /// <param name="CommandTypes">执行的类型</param>
        /// <param name="Parameters">执行所需的参数</param>
        /// <returns>数据库中受影响的行数</returns>
        public static int ExecuteNonQuery(string CommandText, CommandType CommandTypes, params SqlParameter[] Parameters)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(DefaultConnectionString)))
            {
                return 0;
            }
            else { }

            int result = 0;

            //数据库执行传入的命令
            using (SqlConnection Connection = new SqlConnection())
            {
                using (SqlCommand Command = new SqlCommand())
                {
                    //设置数据库对象参数，开启数据库连接
                    Connection.ConnectionString = DefaultConnectionString;
                    Command.Connection = Connection;
                    Command.CommandType = CommandTypes;
                    Command.CommandText = CommandText;

                    //处理数据库命令传入参数
                    if ((null != Parameters) && (0 != Parameters.Length))
                    {
                        Command.Parameters.AddRange(Parameters);
                    }
                    else { }

                    //执行传入的命令
                    Connection.Open();
                    result = Command.ExecuteNonQuery();
                    Command.Parameters.Clear();
                }
            }

            return result;
        }

        /// <summary>
        /// 数据库执行传入的命令，返回数据库中唯一的数据(第一行第一列)
        /// 未找到数据则返回null
        /// </summary>
        /// <param name="CommandText">执行的命令(SQL语句/表名/存储过程)</param>
        /// <param name="CommandTypes">执行的类型</param>
        /// <param name="Parameters">执行所需的参数</param>
        /// <returns>数据库中唯一的数据(第一行第一列)</returns>
        public static object ExecuteScalar(string CommandText, CommandType CommandTypes, params SqlParameter[] Parameters)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(DefaultConnectionString)))
            {
                return null;
            }
            else { }

            object result = null;

            //数据库执行传入的命令
            using (SqlConnection Connection = new SqlConnection())
            {
                using (SqlCommand Command = new SqlCommand())
                {
                    //设置数据库对象参数，开启数据库连接
                    Connection.ConnectionString = DefaultConnectionString;
                    Command.Connection = Connection;
                    Command.CommandType = CommandTypes;
                    Command.CommandText = CommandText;

                    //处理SQL命令传入参数
                    if ((null != Parameters) && (0 != Parameters.Length))
                    {
                        Command.Parameters.AddRange(Parameters);
                    }
                    else { }

                    //执行传入的命令
                    Connection.Open();
                    result = Command.ExecuteScalar();
                    Command.Parameters.Clear();
                }
            }

            return result;
        }

        /// <summary>
        /// 数据库执行传入的命令，返回执行完成后的SqlDataReader(使用完注意关闭)
        /// 传入参数错误则返回null
        /// </summary>
        /// <param name="CommandText">执行的命令(SQL语句/表名/存储过程)</param>
        /// <param name="CommandTypes">执行的类型</param>
        /// <param name="Parameters">执行所需的参数</param>
        /// <returns>执行完成后的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string CommandText, CommandType CommandTypes, params SqlParameter[] Parameters)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(DefaultConnectionString)))
            {
                return null;
            }
            else { }

            SqlDataReader result = null;

            //设置数据库连接与数据库对象参数，开启数据库连接
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            Connection.ConnectionString = DefaultConnectionString;
            Command.Connection = Connection;
            Command.CommandType = CommandTypes;
            Command.CommandText = CommandText;

            //处理SQL命令传入参数
            if ((null != Parameters) && (0 != Parameters.Length))
            {
                Command.Parameters.AddRange(Parameters);
            }
            else { }

            //执行传入的命令
            Connection.Open();
            result = Command.ExecuteReader(CommandBehavior.CloseConnection);
            Command.Parameters.Clear();

            return result;
        }

        /// <summary>
        /// 数据库执行传入的命令填充数据集，返回查询到的数据集合
        /// 未找到数据则返回null
        /// </summary>
        /// <param name="CommandText">执行的命令(SQL语句/表名/存储过程)</param>
        /// <param name="CommandTypes">执行的类型</param>
        /// <param name="Parameters">执行所需的参数</param>
        /// <returns>查询到的数据集合</returns>
        public static DataSet ExecuteDataSet(string CommandText, CommandType CommandTypes, params SqlParameter[] Parameters)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(DefaultConnectionString)))
            {
                return null;
            }
            else { }

            DataSet result = new DataSet();

            //数据库执行传入的命令
            int ResultRow = 0;
            using (SqlConnection Connection = new SqlConnection())
            {
                using (SqlCommand Command = new SqlCommand())
                {
                    //设置数据库对象参数，开启数据库连接
                    Connection.ConnectionString = DefaultConnectionString;
                    Command.Connection = Connection;
                    Command.CommandType = CommandTypes;
                    Command.CommandText = CommandText;

                    //处理SQL命令传入参数
                    if ((null != Parameters) && (0 != Parameters.Length))
                    {
                        Command.Parameters.AddRange(Parameters);
                    }
                    else { }

                    //填充数据集合
                    using (SqlDataAdapter Adapter = new SqlDataAdapter(Command))
                    {
                        Connection.Open();
                        ResultRow = Adapter.Fill(result);
                        Command.Parameters.Clear();
                    }
                }
            }

            //处理返回值
            if (0 == ResultRow)
            {
                result = null;
            }
            else { }

            return result;
        }
    }
}
