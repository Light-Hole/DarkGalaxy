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
    /// 地区的BLL层
    /// 提供一系列对于地区的操作
    /// </summary>
    public class BLL_Region
    {
        /// <summary>
        /// 地区表中的全部记录缓存
        /// </summary>
        private static List<Region> CacheRegionList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLRegion"))
                {
                    //查询地区的全部记录，写入缓存
                    DAL_Region RegionDAL = new DAL_Region();
                    List<Region> Datas = RegionDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "Region");
                    Helper_Cache.AddCache("ALLRegion", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<Region>)Helper_Cache.GetCache("ALLRegion");
                }
            }
        }

        /// <summary>
        /// 添加地区的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">地区记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertRegion(Region InsertModel, out int PrimaryKeyValue)
        {
            //处理错误参数
            if (null == InsertModel)
            {
                PrimaryKeyValue = 0;
                return false;
            }
            else { }

            bool result = false;

            //添加地区的记录
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除地区的全部记c，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteRegion()
        {
            bool result = false;

            //删除地区的全部记录
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除地区的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">地区主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteRegion(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除地区的全部记录
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除地区的单条记录，返回删除是否成功
        /// 注意：会同时删除地区下的所有子地区
        /// </summary>
        /// <param name="ID">地区主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleRegion(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除地区的单条记录
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改地区的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">地区记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateRegion(Region UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改地区的全部记
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改地区的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">地区主键</param>
        /// <param name="UpdateModel">地区记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleRegion(int ID, Region UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改地区的单条记录
            DAL_Region RegionDAL = new DAL_Region();
            result = RegionDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询地区的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Region> SelectRegion()
        {
            //查询地区的全部记录
            return CacheRegionList; ;
        }

        /// <summary>
        /// 分页查询地区的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Region> SelectRegion(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheRegionList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Region> result = null;

            //分页查询地区的全部记录
            var Regions = CacheRegionList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (Regions.Any())
            {
                Total = CacheRegionList.Count;
                result = Regions.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询地区的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">地区主键</param>
        /// <returns>查询到的记录</returns>
        public Region SelectSingleRegion(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheRegionList))
            {
                return null;
            }
            else { }

            Region result = null;

            //查询地区的单条记录
            var SingleRegion =
                from Regions in CacheRegionList
                where Regions.ID == ID
                select Regions;

            //处理返回值
            if (SingleRegion.Any())
            {
                result = SingleRegion.First();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询子级地区的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="id">地区主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Region> SelectChildRegion(int id)
        {
            //处理错误参数
            if ((0 >= id) || (null == CacheRegionList))
            {
                return null;
            }
            else { }

            List<Region> result = null;

            //查询子级地区的全部记录
            var ChildRegion =
                from Regions in CacheRegionList
                where Regions.ParentID == id
                select Regions;

            //处理返回值
            if (ChildRegion.Any())
            {
                result = ChildRegion.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询主键字符串的对应标题字符串，返回查询到的标题
        /// 未查询到记录则返回null
        /// 主键字符串格式：ID1/ID2/ID3/...
        /// 标题格式：标题1 标题2 标题3 ...
        /// </summary>
        /// <param name="RegionsID">主键字符串</param>
        /// <returns>查询到的标题字符串</returns>
        public string SelectRegionText(string RegionsID)
        {
            //处理错误传入参数
            if (String.IsNullOrEmpty(RegionsID))
            {
                return null;
            }
            else { }

            string result = null;

            //查询地区记录
            string[] RegionsArray = RegionsID.Split('/');
            List<string> ListRegion = new List<string>();
            foreach (var temp in RegionsArray)
            {
                var model = SelectSingleRegion(Convert.ToInt32(temp));
                if (model != null)
                {
                    ListRegion.Add(model.Title);
                }
                else
                {
                    return result;
                }
            }
            result = String.Join(" ", ListRegion);

            return result;
        }
    }
}