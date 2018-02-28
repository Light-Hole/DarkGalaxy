using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 产品的BLL层
    /// 提供一系列对于产品的操作
    /// </summary>
    public class BLL_Product
    {
        /// <summary>
        /// 添加产品的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">产品记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertProduct(Product InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加产品的记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除产品的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteProduct()
        {
            bool result = false;

            //删除产品的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除产品的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">产品主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteProduct(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除产品的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除产品的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">产品主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleProduct(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除产品的单条记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改产品的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">产品记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateProduct(Product UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改产品的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改产品的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">产品主键</param>
        /// <param name="UpdateModel">产品记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleProduct(int ID, Product UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改产品的单条记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询产品的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectProduct()
        {
            List<Product> result = new List<Product>();

            //查询产品的全部记录
            DAL_Product ProductDAL = null;
            result = ProductDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询产品的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectProduct(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //分页查询产品的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询产品的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">产品主键</param>
        /// <returns>查询到的记录</returns>
        public Product SelectSingleProduct(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Product result = null;

            //查询产品的单条记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 删除分类主键对应的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="CategoryID">分类主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteProduct_Category(int CategoryID)
        {
            //处理错误参数
            if (0 >= CategoryID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除分类主键对应的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.DeleteIntoProduct_Category(CategoryID);

            return result;
        }

        /// <summary>
        /// 查询分类主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="CategoryID">分类主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Product> SelectProduct_Category(int CategoryID)
        {
            //处理错误参数
            if (0 >= CategoryID)
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //查询分类主键对应的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProduct_Category(CategoryID);

            return result;
        }

        /// <summary>
        /// 分页查询分类主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="CategoryID">分类主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Product> SelectProduct_Category(int PageIndex, int PageSize, out int Total, int CategoryID)
        {
            //处理错误参数
            if ((0 >= CategoryID) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //分页查询分类主键对应的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProduct_Category(PageIndex, PageSize, out Total, CategoryID);

            return result;
        }

        /// <summary>
        /// 查询分类主键集合对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="CategoryIDArray">分类主键集合</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Product> SelectProduct_Category(int[] CategoryIDArray)
        {
            //处理错误参数
            if ((null == CategoryIDArray) || (0 >= CategoryIDArray.Length))
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //查询分类主键对应的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProduct_Category(CategoryIDArray);

            return result;
        }

        /// <summary>
        /// 分页查询分类主键集合对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="CategoryIDArray">分类主键集合</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Product> SelectProduct_Category(int PageIndex, int PageSize, out int Total, int[] CategoryIDArray)
        {
            //处理错误参数
            if ((null == CategoryIDArray) || (0 == CategoryIDArray.Length) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //分页查询分类主键对应的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProduct(PageIndex, PageSize, out Total, CategoryIDArray);

            return result;
        }

        /// <summary>
        /// 模糊查询产品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Product> SelectProductLike(string Title)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Title))
            {
                return null;
            }
            else { }

            List<Product> result = null;

            //模糊查询产品指定标题的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProductLike(Title);

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
        public List<Product> SelectProductLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Product> result = null;

            //分页模糊查询产品指定标题的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            result = ProductDAL.SelectIntoProductLike(PageIndex, PageSize, out Total, Title);

            return result;
        }
    }
}
