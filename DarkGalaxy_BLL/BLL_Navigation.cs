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
    /// 导航的BLL层
    /// 提供一系列对于导航的操作
    /// </summary>
    public class BLL_Navigation
    {
        /// <summary>
        /// 导航表中的全部记录缓存
        /// </summary>
        private static List<Navigation> CacheNavigationList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLNavigation"))
                {
                    //查询导航的全部记录，写入缓存
                    DAL_Navigation NavigationDAL = new DAL_Navigation();
                    List<Navigation> Datas = NavigationDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "Navigation");
                    Helper_Cache.AddCache("ALLNavigation", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<Navigation>)Helper_Cache.GetCache("ALLNavigation");
                }
            }
        }

        /// <summary>
        /// 添加导航的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">导航记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertNavigation(Navigation InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加导航的记录
            DAL_Navigation NavigationDAL = new DAL_Navigation();
            Navigation ParentNavigation = NavigationDAL.SelectSingleIntoTable(InsertModel.ParentID);
            if (null != ParentNavigation)
            {
                InsertModel.Depth = ParentNavigation.Depth + 1;
                InsertModel.IDPath = ParentNavigation.IDPath + ParentNavigation.ID + "/";
                result = NavigationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);
            }
            else
            {
                result = NavigationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);
            }

            return result;
        }

        /// <summary>
        /// 删除导航的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteNavigation()
        {
            bool result = false;

            //删除导航的全部记录
            DAL_Navigation NavigationDAL = new DAL_Navigation();
            result = NavigationDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除导航的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleNavigation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除导航的单条记录
            DAL_Navigation NavigationDAL = new DAL_Navigation();
            NavigationDAL.DeleteChildIntoNavigation(ID);//删除后代导航
            result = NavigationDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改导航的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">导航记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateNavigation(Navigation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改导航的全部记录
            DAL_Navigation NavigationDAL = new DAL_Navigation();
            result = NavigationDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改导航的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <param name="UpdateModel">导航记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleNavigation(int ID, Navigation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改导航的单条记录
            DAL_Navigation NavigationDAL = new DAL_Navigation();
            result = NavigationDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询导航的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectNavigation()
        {
            //查询导航的全部记录
            return CacheNavigationList;
        }

        /// <summary>
        /// 分页查询导航的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectNavigation(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheNavigationList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Navigation> result = null;

            //分页查询导航的全部记录
            var Navigations = CacheNavigationList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (Navigations.Any())
            {
                Total = CacheNavigationList.Count;
                result = Navigations.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询导航的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>查询到的记录</returns>
        public Navigation SelectSingleNavigation(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheNavigationList))
            {
                return null;
            }
            else { }

            Navigation result = null;

            //查询导航的单条记录
            var SingleNavigation =
                from Navigations in CacheNavigationList
                where Navigations.ID == ID
                select Navigations;

            //处理返回值
            if (SingleNavigation.Any())
            {
                result = SingleNavigation.First();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询顶级导航的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectTopNavigation()
        {
            //处理错误参数
            if (null == CacheNavigationList)
            {
                return null;
            }
            else { }

            List<Navigation> result = null;

            //查询顶级导航的全部记录
            var TopNavigation =
                from Navigations in CacheNavigationList
                where 0 == Navigations.ParentID
                select Navigations;

            //处理返回值
            if (TopNavigation.Any())
            {
                result = TopNavigation.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询父级导航的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <returns>询到的记录</returns>
        public Navigation SelectParentNavigation(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheNavigationList))
            {
                return null;
            }
            else { }

            Navigation result = null;

            //查询父级导航的单条记录
            var ParentIDs =
                from Navigations in CacheNavigationList
                where Navigations.ID == ID
                select Navigations.ParentID;

            //查询父级导航记录
            if (ParentIDs.Any())
            {
                int ParentID = ParentIDs.First();
                var ParentNavigation =
                    from Navigations in CacheNavigationList
                    where Navigations.ID == ParentID
                    select Navigations;
                if (ParentNavigation.Any())
                {
                    result = ParentNavigation.First();
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询子级导航的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectChildNavigation(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheNavigationList))
            {
                return null;
            }
            else { }

            List<Navigation> result = null;

            //查询子级导航的全部记录
            var ChildNavigation =
                from Navigations in CacheNavigationList
                where Navigations.ParentID == ID
                select Navigations;

            //处理返回值
            if (ChildNavigation.Any())
            {
                result = ChildNavigation.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询后代导航的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectDescendantNavigation(int ID)
        {
            //处理错误参数
            if ((0 > ID) || (null == CacheNavigationList))
            {
                return null;
            }
            else { }

            List<Navigation> result = null;

            //查询后代导航的全部记录
            var DescendantNavigation =
                from Navigations in CacheNavigationList
                where Navigations.IDPath.Contains("/" + ID + "/")
                select Navigations;

            //处理返回值
            if (DescendantNavigation.Any())
            {
                result = DescendantNavigation.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询导航深度的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Depth">导航深度</param>
        /// <returns>查询到的记录集合</returns>
        public List<Navigation> SelectDepthNavigation(int Depth)
        {
            //处理错误参数
            if ((0 >= Depth) || (null == CacheNavigationList))
            {
                return null;
            }
            else { }

            List<Navigation> result = null;

            //查询导航深度的全部记录
            var DepthNavigation =
                from Navigations in CacheNavigationList
                where Navigations.Depth == Depth
                select Navigations;

            //处理返回值
            if (DepthNavigation.Any())
            {
                result = DepthNavigation.ToList();
            }
            else { }

            return result;
        }
    }
}
