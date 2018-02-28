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
    /// 表Product的DAL层
    /// </summary>
    public class DAL_Product : BaseDAL<int, Product>
    {
        /// <summary>
        /// 删除分类主键对应的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="Category_ID">分类主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteIntoProduct_Category(int Category_ID)
        {
            //处理错误参数
            if (0 >= Category_ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除产品主键对应的全部记录
            string Where = "Category_ID = @DAL_Category_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Category_ID",Category_ID){ DbType = DbType.Int32 }
            };
            result = DeleteIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询分类主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Category_ID">分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProduct_Category(int Category_ID)
        {
            //处理错误参数
            if (0 >= Category_ID)
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //查询产品主键对应的全部记录
            string Where = "Category_ID = @DAL_Category_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Category_ID",Category_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页查询分类主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Category_ID">分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProduct_Category(int PageIndex, int PageSize, out int Total, int Category_ID)
        {
            //处理错误参数
            if ((0 >= Category_ID) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //分页查询产品主键对应的全部记录
            string Where = "Category_ID = @DAL_Category_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_Category_ID",Category_ID){ DbType = DbType.Int32 }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }

        /// <summary>
        /// 查询分类主键集合对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Category_IDArray">分类主键集合</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProduct_Category(int[] Category_IDArray)
        {
            //处理错误参数
            if ((null == Category_IDArray) || (0 == Category_IDArray.Length))
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //查询产品主键对应的全部记录
            string Where = "Category_ID in ({0}) and Enabled = 1";
            string WhereIn = null;
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            for (int i = 0; i < Category_IDArray.Length; i++)
            {
                //设置参数查询条件
                string ParametersName = ("DAL_Category_ID" + i);
                WhereIn += ("@" + ParametersName + ",");

                //设置参数
                SqlParameter Parameter = new SqlParameter(ParametersName, Category_IDArray[i]);
                ParameterList.Add(Parameter);
            }
            WhereIn = WhereIn.TrimEnd(',');
            Where = String.Format(Where, WhereIn);
            result = SelectIntoTable(Where, ParameterList.ToArray());

            return result;
        }

        /// <summary>
        /// 分页查询分类主键集合对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Category_IDArray">分类主键集合</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProduct(int PageIndex, int PageSize, out int Total, int[] Category_IDArray)
        {
            //处理错误参数
            if ((null == Category_IDArray) || (0 == Category_IDArray.Length) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //查询产品产品主键对应的全部记录
            string Where = "Category_ID in ({0}) and Enabled = 1";
            string WhereIn = null;
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            for (int i = 0; i < Category_IDArray.Length; i++)
            {
                //设置参数查询条件
                string ParametersName = ("DAL_Category_ID" + i);
                WhereIn += ("@" + ParametersName + ",");

                //设置参数
                SqlParameter Parameter = new SqlParameter(ParametersName, Category_IDArray[i]);
                ParameterList.Add(Parameter);
            }
            WhereIn = WhereIn.TrimEnd(',');
            Where = String.Format(Where, WhereIn);
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, ParameterList.ToArray());

            return result;
        }

        /// <summary>
        /// 模糊查询产品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProductLike(string Title)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Title))
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //查询产品指定标题的记录
            string Where = "Title like @DAL_likeTitle and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeTitle","%" + Title + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(Where, Parameters);

            return result;
        }

        /// <summary>
        /// 分页模糊查询产品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectIntoProductLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //查询产品记录
            string Where = "Title like @DAL_likeTitle and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_likeTitle","%" + Title + "%"){ DbType = DbType.String }
            };
            result = SelectIntoTable(PageIndex, PageSize, out Total, Where, Parameters);

            return result;
        }
    }
}