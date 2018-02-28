using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Web.Caching;
using System.Linq;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 分类的BLL层
    /// 提供一系列对于分类的操作
    /// </summary>
    public class BLL_Category
    {
        /// <summary>
        /// 分类表中的全部记录缓存
        /// </summary>
        private static List<Category> CacheCategoryList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLCategory"))
                {
                    //查询分类的全部记录，写入缓存
                    DAL_Category CategoryDAL = new DAL_Category();
                    List<Category> Datas = CategoryDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "Category");
                    Helper_Cache.AddCache("ALLCategory", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<Category>)Helper_Cache.GetCache("ALLCategory");
                }
            }
        }

        /// <summary>
        /// 添加分类的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">分类记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertCategory(Category InsertModel,out int PrimaryKeyValue)
        {
            //处理错误参数
            if (null == InsertModel)
            {
                PrimaryKeyValue = 0;
                return false;
            }
            else { }

            bool result = false;

            //添加分类的记录
            DAL_Category CategoryDAL = new DAL_Category();
            Category ParentCategory = CategoryDAL.SelectSingleIntoTable(InsertModel.ParentID);
            if (null != ParentCategory)
            {
                InsertModel.Depth = ParentCategory.Depth + 1;
                InsertModel.IDPath = ParentCategory.IDPath + ParentCategory.ID + "/";
                result = CategoryDAL.InsertIntoTable(InsertModel,out PrimaryKeyValue);
            }
            else
            {
                result = CategoryDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);
            }

            return result;
        }

        /// <summary>
        /// 删除分类的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteCategory()
        {
            bool result = false;

            //删除产品的全部记录
            DAL_Product ProductDAL = new DAL_Product();
            ProductDAL.DeleteIntoTable();

            //删除分类的全部记录
            DAL_Category CategoryDAL = new DAL_Category();
            result = CategoryDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除分类的单条记录，返回删除是否成功
        /// 注意：会同时删除分类下的所有子分类
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleCategory(int ID)
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
            ProductDAL.DeleteIntoProduct_Category(ID);

            //删除分类的单条记录
            DAL_Category CategoryDAL = new DAL_Category();
            CategoryDAL.DeleteChildIntoCategory(ID);//删除后代分类
            result = CategoryDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改分类的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">分类记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateCategory(Category UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改分类的全部记录
            DAL_Category CategoryDAL = new DAL_Category();
            result = CategoryDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改分类的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <param name="UpdateModel">分类记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleCategory(int ID, Category UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改分类的单条记录
            DAL_Category CategoryDAL = new DAL_Category();
            result = CategoryDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectCategory()
        {
            //查询分类的全部记录
            return CacheCategoryList;
        }

        /// <summary>
        /// 分页查询分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectCategory(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheCategoryList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Category> result = null;

            //分页查询分类的全部记录
            var Categorys = CacheCategoryList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (Categorys.Any())
            {
                Total = CacheCategoryList.Count;
                result = Categorys.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询分类的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>查询到的记录</returns>
        public Category SelectSingleCategory(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheCategoryList))
            {
                return null;
            }
            else { }

            Category result = null;

            //查询分类的单条记录
            var SingleCategory =
                from Categorys in CacheCategoryList
                where Categorys.ID == ID
                select Categorys;

            //处理返回值
            if (SingleCategory.Any())
            {
                result = result = SingleCategory.First();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询顶级分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectTopCategory()
        {
            //处理错误参数
            if (null == CacheCategoryList)
            {
                return null;
            }
            else { }

            List<Category> result = null;

            //查询顶级分类的全部记录
            var TopCategory =
                from Categorys in CacheCategoryList
                where 0 == Categorys.ParentID
                select Categorys;

            //处理返回值
            if (TopCategory.Any())
            {
                result = TopCategory.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询父级分类的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>询到的记录</returns>
        public Category SelectParentCategory(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheCategoryList))
            {
                return null;
            }
            else { }

            Category result = null;

            //查询父级分类的主键集合
            var ParentIDs =
                from Categorys in CacheCategoryList
                where Categorys.ID == ID
                select Categorys.ParentID;

            //查询父级分类的单条记录
            if (ParentIDs.Any())
            {
                int ParentID = ParentIDs.First();
                var ParentCategory =
                    from Categorys in CacheCategoryList
                    where Categorys.ID == ParentID
                    select Categorys;
                if (ParentCategory.Any())
                {
                    result = ParentCategory.First();
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询子级分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectChildCategory(int ID)
        {
            //处理错误参数
            if ((0 > ID) || (null == CacheCategoryList))
            {
                return null;
            }
            else { }

            List<Category> result = null;

            //查询子级分类的全部记录
            var ChildCategory =
                from Categorys in CacheCategoryList
                where Categorys.ParentID == ID
                select Categorys;

            //处理返回值
            if (ChildCategory.Any())
            {
                result = ChildCategory.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询后代分类的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectDescendantCategory(int ID)
        {
            //处理错误参数
            if ((0 > ID) || (null == CacheCategoryList))
            {
                return null;
            }
            else { }

            List<Category> result = null;

            //查询后代分类的全部记录
            var DescendantCategory =
                from Categorys in CacheCategoryList
                where Categorys.IDPath.Contains("/" + ID + "/")
                select Categorys;

            //处理返回值
            if (DescendantCategory.Any())
            {
                result = DescendantCategory.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询分类深度的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Depth">分类深度</param>
        /// <returns>查询到的记录集合</returns>
        public List<Category> SelectDepthCategory(int Depth)
        {
            //处理错误参数
            if ((0 >= Depth) || (null == CacheCategoryList))
            {
                return null;
            }
            else { }

            List<Category> result = null;

            //查询分类深度的全部记录
            var DepthCategory =
                from Categorys in CacheCategoryList
                where Categorys.Depth == Depth
                select Categorys;

            //处理返回值
            if (DepthCategory.Any())
            {
                result = DepthCategory.ToList();
            }
            else { }

            return result;
        }
    }
}
