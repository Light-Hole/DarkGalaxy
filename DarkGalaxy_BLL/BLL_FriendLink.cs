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
    /// 友情链接的BLL层
    /// 提供一系列对于友情链接的操作
    /// </summary>
    public class BLL_FriendLink
    {
        /// <summary>
        /// 友情链接表中的全部记录缓存
        /// </summary>
        private static List<FriendLink> CacheFriendLinkList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLFriendLink"))
                {
                    //查询友情链接的全部记录，写入缓存
                    DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
                    List<FriendLink> Datas = FriendLinkDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "FriendLink");
                    Helper_Cache.AddCache("ALLFriendLink", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<FriendLink>)Helper_Cache.GetCache("ALLFriendLink");
                }
            }
        }

        /// <summary>
        /// 添加友情链接的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">友情链接记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertFriendLink(FriendLink InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加友情链接的记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除友情链接的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteFriendLink()
        {
            bool result = false;

            //删除友情链接的全部记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除友情链接的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">友情链接主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteFriendLink(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除友情链接的全部记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除友情链接的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">友情链接主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleFriendLink(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除友情链接的单条记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改友情链接的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">友情链接记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateFriendLink(FriendLink UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改友情链接的全部记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改友情链接的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">友情链接主键</param>
        /// <param name="UpdateModel">友情链接记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleFriendLink(int ID, FriendLink UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改友情链接的单条记录
            DAL_FriendLink FriendLinkDAL = new DAL_FriendLink();
            result = FriendLinkDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询友情链接的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<FriendLink> SelectFriendLink()
        {
            //查询友情链接的全部记录
            return CacheFriendLinkList;
        }

        /// <summary>
        /// 分页查询友情链接的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<FriendLink> SelectFriendLink(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheFriendLinkList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<FriendLink> result = null;

            //分页查询友情链接的全部记录
            var FriendLinks = CacheFriendLinkList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (FriendLinks.Any())
            {
                Total = CacheFriendLinkList.Count;
                result = FriendLinks.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询友情链接的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">友情链接主键</param>
        /// <returns>查询到的记录</returns>
        public FriendLink SelectSingleFriendLink(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheFriendLinkList))
            {
                return null;
            }
            else { }

            FriendLink result = null;

            //查询友情链接的单条记录
            var SingleFriendLink =
                from FriendLinks in CacheFriendLinkList
                where FriendLinks.ID == ID
                select FriendLinks;

            //处理返回值
            if (SingleFriendLink.Any())
            {
                result = SingleFriendLink.First();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 模糊查询友情链接指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<FriendLink> SelectFriendLinkLike(string Title)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Title))
            {
                return null;
            }
            else { }

            List<FriendLink> result = null;

            //模糊查询友情链接指定标题的全部记录
            var FriendLinkLike =
                from FriendLinks in CacheFriendLinkList
                where FriendLinks.Title.Contains(Title)
                select FriendLinks;

            //处理返回值
            if (FriendLinkLike.Any())
            {
                result = FriendLinkLike.ToList();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 分页模糊查询友情链接指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<FriendLink> SelectFriendLinkLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((null == CacheFriendLinkList) || (0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<FriendLink> result = null;

            //分页查询友情链接的全部记录
            var FriendLinkLike =
                from FriendLinks in CacheFriendLinkList
                where FriendLinks.Title.Contains(Title)
                select FriendLinks;
            var FriendLinksLike = CacheFriendLinkList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (FriendLinksLike.Any())
            {
                Total = FriendLinkLike.Count();
                result = FriendLinksLike.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }
    }
}
