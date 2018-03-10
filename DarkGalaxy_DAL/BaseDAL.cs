using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// DAL层基类
    /// 提供一系列对于数据库表标准的增删查改方法
    /// </summary>
    /// <typeparam name="Key">数据库表记录主键的类型</typeparam>
    /// <typeparam name="T">数据库表记录的类型</typeparam>
    public class BaseDAL<Key, T>
        where T : class, new()
    {
        /// <summary>
        /// 数据库表记录的类型
        /// </summary>
        public Type GenericsType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// 插入记录到数据库表中，返回插入是否成功
        /// </summary>
        /// <param name="GenericsObject">表记录对象</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>插入是否成功</returns>
        public bool InsertIntoTable(T GenericsObject, out Key PrimaryKeyValue)
        {
            //处理错误参数
            if ((null == GenericsObject) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())) || (false == DGAnalysis<T>.AnalysisDGNotNull(GenericsObject)))
            {
                PrimaryKeyValue = default(Key);
                return false;
            }
            else { }

            bool result = false;
            PrimaryKeyValue = default(Key);

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALInsert"];//设置默认插入语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.InsertNeglect, CommandText);
            }
            else
            {
                return false;
            }

            //插入记录到数据库表中
            SqlParameter[] SqlParameters = DGAnalysis<T>.AnalysisDGSQLParameter(AttributeType.InsertNeglect, GenericsObject);
            if ((null != SqlParameters) && (false == String.IsNullOrEmpty(CommandText)))
            {
                //插入记录到数据库表中
                object PrimaryKeyObject = Helper_DataBase_SQL.ExecuteScalar(CommandText, CommandType.Text, SqlParameters);
                if (null != PrimaryKeyObject)
                {
                    PrimaryKeyValue = (Key)Convert.ChangeType(PrimaryKeyObject, typeof(Key));
                    result = true;
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 删除数据库表中的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="Where">删除条件</param>
        /// <param name="SqlParameters">删除条件参数</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteIntoTable(string Where = null, SqlParameter[] SqlParameters = null)
        {
            bool result = false;

            //删除数据库表中的全部记录
            string CommandText = ConfigurationManager.AppSettings["BaseDALDelete"];//设置默认删除语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                //解析DGSQL语句,转换为TLSQL语句
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.DeleteNeglect, CommandText, Where);
                if (!String.IsNullOrEmpty(CommandText))
                {
                    result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, SqlParameters) == 0 ? false : true);
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 删除数据库表中的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="PrimaryKeyValues">记录主键值的集合</param>
        /// <param name="Where">删除条件</param>
        /// <param name="SqlParameters">删除条件参数</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteIntoTable(Key[] PrimaryKeyValues, string Where = null, SqlParameter[] SqlParameters = null)
        {
            //处理错误参数
            if ((null == PrimaryKeyValues) || (0 == PrimaryKeyValues.Length) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())))
            {
                return false;
            }
            else
            {
                foreach (var temp in PrimaryKeyValues)
                {
                    if ((null == temp) || (String.IsNullOrEmpty(temp.ToString())))
                    {
                        return false;
                    }
                    else { }
                }
            }

            bool result = false;

            //设置删除条件
            string PrimaryKey = DGAnalysis<T>.AnalysisDGPrimaryKey();
            if (!String.IsNullOrEmpty(Where))
            {
                Where += " and ";
            }
            else { }
            for (int i = 0; i < PrimaryKeyValues.Length; i++)
            {
                if (i == (PrimaryKeyValues.Length - 1))
                {
                    Where += (PrimaryKey + " = @" + PrimaryKey + i);
                }
                else
                {
                    Where += (PrimaryKey + " = @" + PrimaryKey + i + " or ");
                }
            }

            //设置数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            for (int i = 0; i < PrimaryKeyValues.Length; i++)
            {
                SqlParameterList.Add(new SqlParameter(PrimaryKey + i, PrimaryKeyValues[i]));
            }
            if (null != SqlParameters)
            {
                SqlParameterList.AddRange(SqlParameters);//设置条件参数
            }
            else { }

            //删除数据库表中的全部记录
            string CommandText = ConfigurationManager.AppSettings["BaseDALDelete"];//设置默认删除语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                //解析DGSQL语句,转换为TLSQL语句
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.DeleteNeglect, CommandText, Where);
                if (!String.IsNullOrEmpty(CommandText))
                {
                    result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, SqlParameterList.ToArray()) == 0 ? false : true);
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 删除数据库表中的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <param name="Where">删除条件</param>
        /// <param name="SqlParameters">删除条件参数</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleIntoTable(Key PrimaryKeyValue, string Where = null, SqlParameter[] SqlParameters = null)
        {
            //处理错误参数
            if ((null == PrimaryKeyValue) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())))
            {
                return false;
            }
            else { }

            bool result = false;

            //解析DGSQL语句,转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALDeleteSingle"];//设置默认删除语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.DeleteNeglect, CommandText, Where);
            }
            else
            {
                return false;
            }

            //设置数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            SqlParameter Parameter = new SqlParameter()//设置记录主键参数
            {
                ParameterName = DGAnalysis<T>.AnalysisDGPrimaryKey(),//获取主键名,
                Value = PrimaryKeyValue
            };
            SqlParameterList.Add(Parameter);
            if (null != SqlParameters)
            {
                SqlParameterList.AddRange(SqlParameters);//设置条件参数
            }
            else { }

            //删除记录
            if (!String.IsNullOrEmpty(CommandText))
            {
                result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, SqlParameterList.ToArray()) == 0 ? false : true);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 更新数据库表中的全部记录，返回更新是否成功
        /// </summary>
        /// <param name="GenericsObject">表记录对象</param>
        /// <param name="Where">更新条件</param>
        /// <param name="SqlParameters">更新条件参数</param>
        /// <returns>更新是否成功</returns>
        public bool UpdateIntoTable(T GenericsObject, string Where = null, SqlParameter[] SqlParameters = null)
        {
            //处理错误参数
            if ((null == GenericsObject) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())) || (false == DGAnalysis<T>.AnalysisDGNotNull(GenericsObject)))
            {
                return false;
            }
            else { }

            bool result = false;

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALUpdate"];//设置默认更新语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.UpdateNeglect, CommandText, Where);
            }
            else
            {
                return false;
            }

            //设置数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            SqlParameter[] DGSqlParameters = DGAnalysis<T>.AnalysisDGSQLParameter(AttributeType.UpdateNeglect, GenericsObject);//解析DGSQL数据库参数
            if (null != SqlParameters)
            {
                SqlParameterList.AddRange(SqlParameters);//设置条件参数
            }
            else { }
            if (null != DGSqlParameters)
            {

                SqlParameterList.AddRange(DGSqlParameters);//设置更新参数
            }
            else { }

            //更新记录
            if (!String.IsNullOrEmpty(CommandText))
            {
                result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, SqlParameterList.ToArray()) == 0 ? false : true);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 更新数据库表中的单条记录，返回更新是否成功
        /// </summary>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <param name="GenericsObject">表记录对象</param>
        /// <param name="Where">更新条件</param>
        /// <param name="SqlParameters">更新条件参数</param>
        /// <returns>更新是否成功</returns>
        public bool UpdateSingleIntoTable(Key PrimaryKeyValue, T GenericsObject, string Where = null, SqlParameter[] SqlParameters = null)
        {
            //处理错误参数
            if ((null == GenericsObject) || (null == PrimaryKeyValue) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())) || (false == DGAnalysis<T>.AnalysisDGNotNull(GenericsObject)))
            {
                return false;
            }
            else { }

            bool result = false;

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALUpdateSingle"];//设置默认更新语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.UpdateNeglect, CommandText, Where);
            }
            else
            {
                return false;
            }

            //设置数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            SqlParameter[] DGSqlParameters = DGAnalysis<T>.AnalysisDGSQLParameter(AttributeType.UpdateNeglect, GenericsObject);//解析DGSQL数据库参数
            SqlParameter Parameter = new SqlParameter()//设置主键参数
            {
                ParameterName = DGAnalysis<T>.AnalysisDGPrimaryKey(),//获取主键名
                Value = PrimaryKeyValue
            };
            SqlParameterList.Add(Parameter);
            if (null != SqlParameters)
            {
                SqlParameterList.AddRange(SqlParameters);//设置条件参数
            }
            else { }
            if (null != DGSqlParameters)
            {
                SqlParameterList.AddRange(DGSqlParameters);//设置更新参数
            }
            else { }

            //更新记录
            if (!String.IsNullOrEmpty(CommandText))
            {
                result = (Helper_DataBase_SQL.ExecuteNonQuery(CommandText, CommandType.Text, SqlParameterList.ToArray()) == 0 ? false : true);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询数据库表中的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="SqlParameters">查询条件参数</param>
        /// <returns>查询到的记录集合</returns>
        public List<T> SelectIntoTable(string Where = null, SqlParameter[] SqlParameters = null)
        {
            List<T> result = new List<T>();

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALSelect"];//设置默认查询语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.SelectNeglect, CommandText, Where);
            }
            else
            {
                return null;
            }

            //获取全部数据，加载到List集合中
            if (!String.IsNullOrEmpty(CommandText))
            {
                PropertyInfo[] PropertyInfos = this.GenericsType.GetProperties();//获取泛型类型全部公有属性
                SqlDataReader Reader = Helper_DataBase_SQL.ExecuteReader(CommandText, CommandType.Text, SqlParameters);
                while (Reader.Read())
                {
                    T Record = new T();
                    foreach (PropertyInfo temp in PropertyInfos)
                    {
                        //获取对应属性名的值，如果是DBNull则为null
                        object ColumnValue = Convert.IsDBNull(Reader[temp.Name]) ? null : Reader[temp.Name];
                        object[] ColumnValues = { ColumnValue };

                        //设置数据库表记录的值
                        MethodInfo SetMethodInfo = temp.GetSetMethod();
                        SetMethodInfo.Invoke(Record, ColumnValues);
                    }
                    result.Add(Record);
                }
                Reader.Close();
            }
            else { }

            //处理返回值
            if (0 == result.Count)
            {
                result = null;
            }
            else { }

            return result;
        }

        /// <summary>
        /// 分页查询数据库表中的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Where">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <param name="SqlParameters">查询条件参数</param>
        /// <returns>查询到的记录集合</returns>
        public List<T> SelectIntoTable(int PageIndex, int PageSize, out int Total, string Where = null, SqlParameter[] SqlParameters = null, string OrderBy = null)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<T> result = new List<T>();

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALSelectPaging"];//设置默认分页查询语句
            string CommandTextTotal = ConfigurationManager.AppSettings["BaseDALSelectPagingTotal"];//设置默认分页数据总数查询语句
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(CommandTextTotal)))
            {
                Total = 0;
                return null;
            }
            else { }
            CommandText = CommandText.Replace("{DGPageIndex}", PageIndex.ToString());
            CommandText = CommandText.Replace("{DGPageSize}", PageSize.ToString());
            CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.SelectNeglect, CommandText, Where, OrderBy);
            CommandTextTotal = DGAnalysis<T>.AnalysisDGSQL(AttributeType.SelectNeglect, CommandTextTotal, Where);
            if ((String.IsNullOrEmpty(CommandText)) || (String.IsNullOrEmpty(CommandTextTotal)))
            {
                Total = 0;
                return null;
            }
            else { }

            //查询分页数据总数
            object TotalObject = 0;
            TotalObject = Helper_DataBase_SQL.ExecuteScalar(CommandTextTotal, CommandType.Text, SqlParameters);
            if ((DBNull.Value == TotalObject) || (null == TotalObject))
            {
                Total = 0;
                return null;
            }
            else
            {
                try
                {
                    Total = Convert.ToInt32(TotalObject);
                }
                catch
                {
                    Total = 0;
                    return null;
                }
            }

            //获取全部数据，加载到List集合中
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            SqlDataReader Reader = Helper_DataBase_SQL.ExecuteReader(CommandText, CommandType.Text, SqlParameters);
            while (Reader.Read())
            {
                T Record = new T();
                foreach (PropertyInfo temp in PropertyInfos)
                {
                    //获取对应属性名的值，如果是DBNull则为null
                    object ColumnValue = Convert.IsDBNull(Reader[temp.Name]) ? null : Reader[temp.Name];
                    object[] ColumnValues = { ColumnValue };

                    //设置数据库表记录的值
                    MethodInfo SetMethodInfo = temp.GetSetMethod();
                    SetMethodInfo.Invoke(Record, ColumnValues);
                }
                result.Add(Record);
            }
            Reader.Close();

            //处理返回值
            if ((0 == result.Count) || (0 >= Total))
            {
                result = null;
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询数据库表中的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <param name="Where">查询的条件</param>
        /// <param name="SqlParameters">查询条件的参数</param>
        /// <returns>查询到的记录</returns>
        public T SelectSingleIntoTable(Key PrimaryKeyValue, string Where = null, SqlParameter[] SqlParameters = null)
        {
            //处理错误参数
            if ((null == PrimaryKeyValue) || (true == String.IsNullOrEmpty(DGAnalysis<T>.AnalysisDGPrimaryKey())))
            {
                return null;
            }
            else { }

            T result = new T();

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALSelectSingle"];//设置默认查询语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.SelectNeglect, CommandText, Where);
            }
            else
            {
                return null;
            }

            //设置数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            SqlParameter Parameter = new SqlParameter()//设置主键参数
            {
                ParameterName = DGAnalysis<T>.AnalysisDGPrimaryKey(),//获取主键名
                Value = PrimaryKeyValue
            };
            SqlParameterList.Add(Parameter);
            if (null != SqlParameters)
            {
                //设置条件参数
                SqlParameterList.AddRange(SqlParameters);
            }
            else { }

            //获取查询到的数据
            if (!String.IsNullOrEmpty(CommandText))
            {
                PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
                DataSet Data = Helper_DataBase_SQL.ExecuteDataSet(CommandText, CommandType.Text, SqlParameterList.ToArray());
                if ((null == Data) || (0 == PropertyInfos.Length))
                {
                    result = null;
                }
                else
                {
                    foreach (PropertyInfo temp in PropertyInfos)
                    {
                        //获取对应属性名的值，如果是DBNull则为null
                        object ColumnValue = Convert.IsDBNull(Data.Tables[0].Rows[0][temp.Name]) ? null : Data.Tables[0].Rows[0][temp.Name];
                        object[] ColumnValues = { ColumnValue };

                        //设置数据库表记录的值
                        MethodInfo SetMethodInfo = temp.GetSetMethod();
                        SetMethodInfo.Invoke(result, ColumnValues);
                    }
                    Data.Dispose();
                }
            }
            else
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// 查询数据库表中的单条数据，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Where">查询的条件</param>
        /// <param name="Parameters">查询的参数</param>
        /// <returns>查询到的记录</returns>
        public T SelectSingleIntoTable(string Where, params SqlParameter[] Parameters)
        {
            //处理错误参数
            if (null == Where)
            {
                return null;
            }
            else { }

            T result = new T();

            //解析DGSQL语句，转换为TLSQL语句
            string CommandText = ConfigurationManager.AppSettings["BaseDALSelectSingleWhere"];//设置默认查询语句
            if (!String.IsNullOrEmpty(CommandText))
            {
                CommandText = DGAnalysis<T>.AnalysisDGSQL(AttributeType.SelectNeglect, CommandText, Where);
            }
            else
            {
                return null;
            }

            //获取查询到的数据
            if (!String.IsNullOrEmpty(CommandText))
            {
                PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
                DataSet Data = Helper_DataBase_SQL.ExecuteDataSet(CommandText, CommandType.Text, Parameters);
                if ((null == Data) || (0 == PropertyInfos.Length))
                {
                    result = null;
                }
                else
                {
                    foreach (PropertyInfo temp in PropertyInfos)
                    {
                        //获取对应属性名的值，如果是DBNull则为null
                        object ColumnValue = Convert.IsDBNull(Data.Tables[0].Rows[0][temp.Name]) ? null : Data.Tables[0].Rows[0][temp.Name];
                        object[] ColumnValues = { ColumnValue };

                        //设置数据库表记录的值
                        MethodInfo SetMethodInfo = temp.GetSetMethod();
                        SetMethodInfo.Invoke(result, ColumnValues);
                    }
                    Data.Dispose();
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}