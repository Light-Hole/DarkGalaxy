using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Web.Caching;
using System.Linq;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// WeChat基本信息的BLL层
    /// 提供一系列对于WeChat基本信息的操作
    /// </summary>
    public class BLL_WeChatBasicInformation
    {
        /// <summary>
        /// WeChat基本信息表中的全部记录缓存
        /// </summary>
        private static List<WeChatBasicInformation> CacheWeChatBasicInformationList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLWeChatBasicInformation"))
                {
                    //查询WeChat基本信息的全部记录，写入缓存
                    DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
                    List<WeChatBasicInformation> Datas = WeChatBasicInformationDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "WeChatBasicInformation");
                    Helper_Cache.AddCache("ALLWeChatBasicInformation", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<WeChatBasicInformation>)Helper_Cache.GetCache("ALLWeChatBasicInformation");
                }
            }
        }

        /// <summary>
        /// 添加WeChat基本信息的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">WeChat基本信息记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertWeChatBasicInformation(WeChatBasicInformation InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加WeChat基本信息的记录
            DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
            result = WeChatBasicInformationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除WeChat基本信息的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteWeChatBasicInformation()
        {
            bool result = false;

            //删除WeChat基本信息的全部记录
            DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
            result = WeChatBasicInformationDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除WeChat基本信息的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">WeChat基本信息主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleWeChatBasicInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除WeChat基本信息的单条记录
            DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
            result = WeChatBasicInformationDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改WeChat基本信息的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">WeChat基本信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateWeChatBasicInformation(WeChatBasicInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat基本信息的全部记录
            DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
            result = WeChatBasicInformationDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改WeChat基本信息的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">WeChat基本信息主键</param>
        /// <param name="UpdateModel">WeChat基本信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleWeChatBasicInformation(int ID, WeChatBasicInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改WeChat基本信息的单条记录
            DAL_WeChatBasicInformation WeChatBasicInformationDAL = new DAL_WeChatBasicInformation();
            result = WeChatBasicInformationDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询WeChat基本信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatBasicInformation> SelectWeChatBasicInformation()
        {
            //查询WeChat基本信息的全部记录
            return CacheWeChatBasicInformationList;
        }

        /// <summary>
        /// 分页查询WeChat基本信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<WeChatBasicInformation> SelectWeChatBasicInformation(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheWeChatBasicInformationList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<WeChatBasicInformation> result = null;

            //分页查询WeChat基本信息的全部记录
            var WeChatBasicInformations = CacheWeChatBasicInformationList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (WeChatBasicInformations.Any())
            {
                Total = CacheWeChatBasicInformationList.Count;
                result = WeChatBasicInformations.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询WeChat基本信息的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">WeChat基本信息主键</param>
        /// <returns>查询到的记录</returns>
        public WeChatBasicInformation SelectSingleWeChatBasicInformation(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheWeChatBasicInformationList))
            {
                return null;
            }
            else { }

            WeChatBasicInformation result = null;

            //查询WeChat基本信息的单条记录
            var SingleWeChatBasicInformation =
                from WeChatBasicInformations in CacheWeChatBasicInformationList
                where WeChatBasicInformations.ID == ID
                select WeChatBasicInformations;

            //处理返回值
            if (SingleWeChatBasicInformation.Any())
            {
                result = SingleWeChatBasicInformation.First();
            }
            else { }

            return result;
        }
    }
}