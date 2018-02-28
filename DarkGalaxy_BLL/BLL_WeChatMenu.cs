using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Web.Caching;
using System.Linq;
using System;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// WeChat菜单的BLL层
    /// 提供一系列对于WeChat菜单的操作
    /// </summary>
    public class BLL_WeChatMenu
    {
        /// <summary>
        /// WeChat菜单表中的全部记录缓存
        /// </summary>
        private static List<WeChatMenu> CacheWeChatMenuList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLWeChatMenu"))
                {
                    //查询WeChat菜单的全部记录，写入缓存
                    DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
                    List<WeChatMenu> Datas = WeChatMenuDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "WeChatMenu");
                    Helper_Cache.AddCache("ALLWeChatMenu", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<WeChatMenu>)Helper_Cache.GetCache("ALLWeChatMenu");
                }
            }
        }

        /// <summary>
        /// 添加WeChat菜单的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">WeChat菜单记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertWeChatMenu(WeChatMenu InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加WeChat菜单的记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除WeChat菜单的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteWeChatMenu()
        {
            bool result = false;

            //删除WeChat菜单的全部记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除WeChat菜单的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">WeChat菜单主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteWeChatMenu(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除WeChat菜单的全部记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除WeChat菜单的单条记录，返回删除是否成功
        /// 注意：会同时删除WeChat菜单下的所有子WeChat菜单
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleWeChatMenu(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除WeChat菜单的单条记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改WeChat菜单的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">WeChat菜单记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateWeChatMenu(WeChatMenu UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的全部记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改WeChat菜单的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <param name="UpdateModel">WeChat菜单记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleWeChatMenu(int ID, WeChatMenu UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的单条记录
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询WeChat菜单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectWeChatMenu()
        {
            //查询WeChat菜单的全部记录
            return CacheWeChatMenuList;
        }

        /// <summary>
        /// 分页查询WeChat菜单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectWeChatMenu(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheWeChatMenuList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //分页查询WeChat菜单的全部记录
            var WeChatMenus = CacheWeChatMenuList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (WeChatMenus.Any())
            {
                Total = CacheWeChatMenuList.Count;
                result = WeChatMenus.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询WeChat菜单的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <returns>查询到的记录</returns>
        public WeChatMenu SelectSingleWeChatMenu(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheWeChatMenuList))
            {
                return null;
            }
            else { }

            WeChatMenu result = null;

            //查询WeChat菜单的单条记录
            var SingleWeChatMenu =
                from WeChatMenus in CacheWeChatMenuList
                where WeChatMenus.ID == ID
                select WeChatMenus;

            //处理返回值
            if (SingleWeChatMenu.Any())
            {
                result = SingleWeChatMenu.First();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 修改WeChat菜单的全部记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="IDArray">WeChat菜单主键集合</param>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateWeChatMenuSetEmploy(int[] IDArray, bool Employ)
        {
            //处理错误参数
            if ((null == IDArray) || (0 >= IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的全部记录的Employ字段值
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.UpdateIntoWeChatMenuSetEmploy(IDArray, Employ);

            return result;
        }

        /// <summary>
        /// 修改WeChat菜单的单条记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="ID">WeChat菜单主键集合</param>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleWeChatMenuSetEmploy(int ID, bool Employ)
        {
            //处理错误参数
            if (0 > ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat菜单的单条记录的Employ字段值
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.UpdateSingleIntoWeChatMenuSetEmploy(ID, Employ);

            return result;
        }

        /// <summary>
        /// 修改顶级WeChat菜单的全部记录的Employ字段值，返回修改是否成功
        /// </summary>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateTopWeChatMenuSetEmploy(bool Employ)
        {
            bool result = false;

            //修改WeChat菜单的全部记录的Employ字段值
            DAL_WeChatMenu WeChatMenuDAL = new DAL_WeChatMenu();
            result = WeChatMenuDAL.UpdateTopIntoWeChatMenuSetEmploy(Employ);

            return result;
        }

        /// <summary>
        /// 模糊查询WeChat菜单指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectWeChatMenuLike(string Title)
        {
            //处理错误参数
            if ((null == CacheWeChatMenuList) || (String.IsNullOrEmpty(Title)))
            {
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //模糊查询WeChat菜单指定标题的全部记录
            var WeChatMenuLike =
                from WeChatMenuLikes in CacheWeChatMenuList
                where WeChatMenuLikes.Title.Contains(Title)
                select WeChatMenuLikes;

            //处理返回值
            if (WeChatMenuLike.Any())
            {
                result = WeChatMenuLike.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 分页模糊查询WeChat菜单指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectWeChatMenuLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((null == CacheWeChatMenuList) || (0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //分页模糊查询WeChat菜单指定标题的全部记录
            var WeChatMenuLike =
                from WeChatMenuLikes in CacheWeChatMenuList
                where WeChatMenuLikes.Title.Contains(Title)
                select WeChatMenuLikes;
            var WeChatMenusLike = WeChatMenuLike.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (WeChatMenuLike.Any() && WeChatMenusLike.Any())
            {
                Total = WeChatMenuLike.Count();
                result = WeChatMenusLike.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询顶级WeChat菜单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectTopWeChatMenu()
        {
            //处理错误参数
            if (null == CacheWeChatMenuList)
            {
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //查询顶级WeChat菜单的全部记录
            var TopWeChatMenu =
                from TopWeChatMenus in CacheWeChatMenuList
                where 0 == TopWeChatMenus.ParentID
                select TopWeChatMenus;

            //处理返回值
            if (TopWeChatMenu.Any())
            {
                result = TopWeChatMenu.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询子级WeChat菜单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectChildWeChatMenu(int ID)
        {
            //处理错误参数
            if ((null == CacheWeChatMenuList) || (0 > ID))
            {
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //查询子级WeChat菜单的全部记录
            var ChildWeChatMenu =
                from ChildWeChatMenus in CacheWeChatMenuList
                where ChildWeChatMenus.ParentID == ID
                select ChildWeChatMenus;

            //处理返回值
            if (ChildWeChatMenu.Any())
            {
                result = ChildWeChatMenu.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 查询子级WeChat菜单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">WeChat菜单主键</param>
        /// <param name="Employ">Employ字段值</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatMenu> SelectChildWeChatMenu(int ID, bool Employ)
        {
            //处理错误参数
            if ((null == CacheWeChatMenuList) || (0 > ID))
            {
                return null;
            }
            else { }

            List<WeChatMenu> result = null;

            //查询子级WeChat菜单的全部记录
            var ChildWeChatMenu =
                from ChildWeChatMenus in CacheWeChatMenuList
                where (ChildWeChatMenus.ParentID == ID) && (ChildWeChatMenus.Employ == Employ)
                select ChildWeChatMenus;

            //处理返回值
            if (ChildWeChatMenu.Any())
            {
                result = ChildWeChatMenu.ToList();
            }
            else { }

            return result;
        }
    }
}