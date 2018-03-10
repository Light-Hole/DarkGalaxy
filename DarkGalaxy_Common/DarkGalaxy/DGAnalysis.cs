using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace DarkGalaxy_Common.DarkGalaxy
{
    /// <summary>
    /// DarkGalaxy项目自定义解析类
    /// 提供一系列对于DarkGalaxy项目自定义规范的解析操作
    /// </summary>
    /// <typeparam name="T">解析的类型</typeparam>
    public static class DGAnalysis<T>
    {
        /// <summary>
        /// 解析的类型
        /// </summary>
        public static Type GenericsType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// 解析DGSQL语句，返回TLSQL字符串
        /// 解析失败则返回null
        /// </summary>
        /// <param name="NeglectType">不解析的特性类型</param>
        /// <param name="DGSQLText">DGSQL语句</param>
        /// <param name="Where">Where条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <returns>TLSQL字符串</returns>
        public static string AnalysisDGSQL(AttributeType NeglectType, string DGSQLText, string Where = null, string OrderBy = null)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(DGSQLText))
            {
                return null;
            }
            else { }

            string result = null;

            //初始化解析后的字符串
            string DGColumns = null;
            string DGColumnValues = null;
            string DGColumnsAndDGColumnValues = null;

            //设置DGSQL解析后的字符串
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                //过滤DG特性
                if (0 == (NeglectType & AttributeType.None))
                {
                    //判断属性存在的DG特性
                    bool ISDGInsertNeglect = false;
                    bool ISDGDeleteNeglect = false;
                    bool ISDGUpdateNeglect = false;
                    bool ISDGSelectNeglect = false;
                    foreach (var Attribute in temp.CustomAttributes)
                    {
                        if ("DGInsertNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGInsertNeglect = true;
                        }
                        else { }
                        if ("DGDeleteNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGDeleteNeglect = true;
                        }
                        else { }
                        if ("DGUpdateNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGUpdateNeglect = true;
                        }
                        else { }
                        if ("DGSelectNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGSelectNeglect = true;
                        }
                        else { }
                    }

                    //判断是否解析[DGInsertNeglect]特性
                    if ((true == ISDGInsertNeglect) && (0 != (NeglectType & AttributeType.InsertNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGDeleteNeglect]特性
                    if ((true == ISDGDeleteNeglect) && (0 != (NeglectType & AttributeType.DeleteNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGUpdateNeglect]特性
                    if ((true == ISDGUpdateNeglect) && (0 != (NeglectType & AttributeType.UpdateNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGSelectNeglect]特性
                    if ((true == ISDGSelectNeglect) && (0 != (NeglectType & AttributeType.SelectNeglect)))
                    {
                        continue;
                    }
                    else { }
                }
                else { }

                //设置解析后的字符串
                DGColumns += temp.Name + ",";
                DGColumnValues += ("@" + temp.Name + ",");
                DGColumnsAndDGColumnValues += (temp.Name + " = " + "@" + temp.Name + ",");
            }

            //处理DGSQL解析后的字符串
            if ((String.IsNullOrEmpty(DGColumns)) || (String.IsNullOrEmpty(DGColumnValues)) || (String.IsNullOrEmpty(DGColumnsAndDGColumnValues)))
            {
                return result;
            }
            else
            {
                DGColumns = DGColumns.TrimEnd(',');
                DGColumnValues = DGColumnValues.TrimEnd(',');
                DGColumnsAndDGColumnValues = DGColumnsAndDGColumnValues.TrimEnd(',');
            }

            //解析DGSQL
            if (DGSQLText.Contains("{DGWhere}"))//解析where条件
            {
                //设置Where条件
                string DefaultWhere = ConfigurationManager.AppSettings["BaseDALWhere"];//设置默认Where条件
                if (String.IsNullOrEmpty(DefaultWhere))
                {
                    DefaultWhere = "1 = 1";
                }
                else { }
                if (String.IsNullOrEmpty(Where))
                {
                    DGSQLText = DGSQLText.Replace("{DGWhere}", DefaultWhere);
                }
                else
                {
                    DGSQLText = DGSQLText.Replace("{DGWhere}", Where);
                }
            }
            else { }
            if (DGSQLText.Contains("{DGPrimaryKey = PrimaryKey}"))//解析主键名与主键值相等
            {
                string PrimaryKey = AnalysisDGPrimaryKey();
                if (String.IsNullOrEmpty(PrimaryKey))
                {
                    return result;
                }
                else
                {
                    PrimaryKey = (PrimaryKey + " = @" + PrimaryKey);
                    DGSQLText = DGSQLText.Replace("{DGPrimaryKey = PrimaryKey}", PrimaryKey);
                }
            }
            else { }
            if (DGSQLText.Contains("{DGTable}"))//解析表名
            {
                DGSQLText = DGSQLText.Replace("{DGTable}", GenericsType.Name);
            }
            else { }
            if (DGSQLText.Contains("{DGColumns}"))//解析列名
            {
                DGSQLText = DGSQLText.Replace("{DGColumns}", DGColumns);
            }
            else { }
            if (DGSQLText.Contains("{DGColumnValues}"))//解析列值
            {
                DGSQLText = DGSQLText.Replace("{DGColumnValues}", DGColumnValues);
            }
            else { }
            if (DGSQLText.Contains("{DGColumns = DGColumnValues}"))//解析列名与列值相等
            {
                DGSQLText = DGSQLText.Replace("{DGColumns = DGColumnValues}", DGColumnsAndDGColumnValues);
            }
            else { }
            if (DGSQLText.Contains("{DGOrderBy}"))//解析排序
            {
                if (String.IsNullOrEmpty(OrderBy))
                {
                    DGSQLText = DGSQLText.Replace("{DGOrderBy}", "SortIndex asc");
                }
                else
                {
                    DGSQLText = DGSQLText.Replace("{DGOrderBy}", OrderBy);
                }
            }
            else { }
            result = DGSQLText;

            return result;
        }

        /// <summary>
        /// 解析DGSQL数据库参数，返回数据库参数集合
        /// 解析失败则返回null
        /// </summary>
        /// <param name="NeglectType">不解析的特性类型</param>
        /// <param name="GenericsObject">解析的对象</param>
        /// <returns>数据库参数集合</returns>
        public static SqlParameter[] AnalysisDGSQLParameter(AttributeType NeglectType, T GenericsObject)
        {
            //处理错误参数
            if (null == GenericsObject)
            {
                return null;
            }
            else { }

            SqlParameter[] result = null;

            //解析DGSQL数据库参数
            List<SqlParameter> SqlParameterList = new List<SqlParameter>();
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                //过滤DG特性
                if (0 == (NeglectType & AttributeType.None))
                {
                    //判断属性是否存在DG特性
                    bool ISDGInsertNeglect = false;
                    bool ISDGDeleteNeglect = false;
                    bool ISDGUpdateNeglect = false;
                    bool ISDGSelectNeglect = false;
                    foreach (var Attribute in temp.CustomAttributes)
                    {
                        if ("DGInsertNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGInsertNeglect = true;
                        }
                        else { }
                        if ("DGDeleteNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGDeleteNeglect = true;
                        }
                        else { }
                        if ("DGUpdateNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGUpdateNeglect = true;
                        }
                        else { }
                        if ("DGSelectNeglect" == Attribute.AttributeType.Name)
                        {
                            ISDGSelectNeglect = true;
                        }
                        else { }
                    }

                    //判断是否解析[DGInsertNeglect]特性
                    if ((true == ISDGInsertNeglect) && (0 != (NeglectType & AttributeType.InsertNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGDeleteNeglect]特性
                    if ((true == ISDGDeleteNeglect) && (0 != (NeglectType & AttributeType.DeleteNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGUpdateNeglect]特性
                    if ((true == ISDGUpdateNeglect) && (0 != (NeglectType & AttributeType.UpdateNeglect)))
                    {
                        continue;
                    }
                    else { }

                    //判断是否解析[DGSelectNeglect]特性
                    if ((true == ISDGSelectNeglect) && (0 != (NeglectType & AttributeType.SelectNeglect)))
                    {
                        continue;
                    }
                    else { }
                }
                else { }

                //获取公有GET访问器的返回值
                SqlParameter Parameter = new SqlParameter();
                MethodInfo GetMethodInfo = temp.GetGetMethod();
                object GetMethodReturn = GetMethodInfo.Invoke(GenericsObject, null);

                //设置数据库命令参数的List集合
                Parameter.ParameterName = temp.Name;
                if (null == GetMethodReturn)
                {
                    Parameter.Value = DBNull.Value;
                }
                else
                {
                    Parameter.Value = GetMethodReturn;
                }
                SqlParameterList.Add(Parameter);
            }

            //处理返回值
            if (0 == SqlParameterList.Count)
            {
                result = null;
            }
            else
            {
                result = SqlParameterList.ToArray();
            }

            return result;
        }

        /// <summary>
        /// 解析具有[DGPrimaryKey]特性的属性名，返回获取的属性名
        /// 未找到具有[DGPrimaryKey]特性的属性名则返回null
        /// </summary>
        /// <returns>具有[DGPrimaryKey]特性的属性名</returns>
        public static string AnalysisDGPrimaryKey()
        {
            string result = null;

            //获取具有[DGPrimaryKey]特性的属性名
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                foreach (var Attribute in temp.CustomAttributes)
                {
                    //判断是否具有[DGPrimaryKey]特性
                    if ("DGPrimaryKey" == Attribute.AttributeType.Name)
                    {
                        result = temp.Name;
                    }
                    else { }
                }
            }

            return result;
        }

        /// <summary>
        /// 解析具有[DGPrimaryKey]特性的属性值，返回获取的属性值
        /// 未找到具有[DGPrimaryKey]特性的值则返回null
        /// </summary>
        /// <param name="GenericsObject">解析的对象</param>
        /// <returns>具有[DGPrimaryKey]特性的属性值</returns>
        public static object AnalysisDGPrimaryKeyValue(T GenericsObject)
        {
            //处理错误参数
            if ((null == GenericsObject) || (String.IsNullOrEmpty(AnalysisDGPrimaryKey())))
            {
                return null;
            }
            else { }

            object result = null;

            //获取具有[DGPrimaryKey]特性的属性值
            string PrimaryKey = AnalysisDGPrimaryKey();
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                if (PrimaryKey == temp.Name)
                {
                    SqlParameter Parameter = new SqlParameter();
                    MethodInfo GetMethodInfo = temp.GetGetMethod();
                    result = GetMethodInfo.Invoke(GenericsObject, null);
                }
                else { }
            }

            return result;
        }

        /// <summary>
        /// 解析具有[DGNotNull]特性的属性值是否符合非空约束，返回属性值是否非null
        /// </summary>
        /// <param name="GenericsObject">解析的对象</param>
        /// <returns>属性值是否非null</returns>
        public static bool AnalysisDGNotNull(T GenericsObject)
        {
            //处理错误参数
            if (null == GenericsObject)
            {
                return false;
            }
            else { }

            bool result = true;

            //判断具有[DGNotNull]特性的属性值是否为null
            PropertyInfo[] PropertyInfos = GenericsType.GetProperties();//获取泛型类型全部公有属性
            foreach (PropertyInfo temp in PropertyInfos)
            {
                foreach (var Attribute in temp.CustomAttributes)
                {
                    if ("DGNotNull" == Attribute.AttributeType.Name)
                    {
                        MethodInfo GetMethodInfo = temp.GetGetMethod();
                        object GetMethodReturn = GetMethodInfo.Invoke(GenericsObject, null);
                        if (null == GetMethodReturn)
                        {
                            return false;
                        }
                        else { }
                    }
                    else { }
                }
            }

            return result;
        }
    }
}