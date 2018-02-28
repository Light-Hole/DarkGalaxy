using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 商品规格分类的BLL层
    /// 提供一系列对于商品规格分类的操作
    /// </summary>
    public class BLL_SpecificationCategory
    {
        /// <summary>
        /// 添加商品规格分类的记录，返回添加的记录主键
        /// </summary>
        /// <param name="InsertModel">商品规格分类记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加的记录主键</returns>
        public bool InsertSpecificationCategory(SpecificationCategory InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加商品规格分类的记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除商品规格分类的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteSpecificationCategory()
        {
            bool result = false;

            //删除商品规格的全部记录
            DAL_Specification SpecificationDAL = new DAL_Specification();
            SpecificationDAL.DeleteIntoTable();

            //删除商品规格分类的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除商品规格分类的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">商品规格分类主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSpecificationCategory(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除商品规格的全部记录
            DAL_Specification SpecificationDAL = new DAL_Specification();
            SpecificationDAL.DeleteIntoTable(IDArray);

            //删除商品规格分类的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除商品规格分类的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">商品规格分类主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleSpecificationCategory(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除商品规格的单条记录
            DAL_Specification SpecificationDAL = new DAL_Specification();
            SpecificationDAL.DeleteIntoSpecification_SpecificationCategory(ID);

            //删除商品规格分类的单条记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改商品规格分类的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">商品规格分类记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSpecificationCategory(SpecificationCategory UpdateModel)
        {
            bool result = false;

            //修改商品规格分类的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改商品规格分类的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">商品规格分类主键</param>
        /// <param name="UpdateModel">商品规格分类记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleSpecificationCategory(int ID, SpecificationCategory UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改商品规格分类的单条记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询商品规格分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<SpecificationCategory> SelectSpecificationCategory()
        {
            List<SpecificationCategory> result = null;

            //查询商品规格分类的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询商品规格分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<SpecificationCategory> SelectSpecificationCategory(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<SpecificationCategory> result = null;

            //分页查询商品规格分类的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询商品规格分类的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">商品规格分类主键</param>
        /// <returns>查询到的记录</returns>
        public SpecificationCategory SelectSingleSpecificationCategory(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            SpecificationCategory result = null;

            //查询商品规格分类的单条记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询商品规格分类的单条记录（包括失效记录），返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">商品规格分类主键</param>
        /// <returns>查询到的记录</returns>
        public SpecificationCategory SelectSingleSpecificationCategoryAll(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            SpecificationCategory result = null;

            //查询商品规格分类的单条记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.SelectSingleIntoTable(ID,"1 = 1");

            return result;
        }

        /// <summary>
        /// 查询商品规格分类主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="CommodityID">商品规格分类主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<SpecificationCategory> SelectSpecCategory_Commodity(int CommodityID)
        {
            //处理错误参数
            if (0 >= CommodityID)
            {
                return null;
            }
            else { }

            List<SpecificationCategory> result = null;

            //查询商品规格分类主键对应的全部记录
            DAL_SpecificationCategory SpecificationCategoryDAL = new DAL_SpecificationCategory();
            result = SpecificationCategoryDAL.SelectIntoSpecificationCategory_Commodity(CommodityID);

            return result;
        }
    }
}