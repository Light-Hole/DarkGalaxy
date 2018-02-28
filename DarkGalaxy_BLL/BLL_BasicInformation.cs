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
    /// 基本信息的BLL层
    /// 提供一系列对于基本信息的操作
    /// </summary>
    public class BLL_BasicInformation
    {
        /// <summary>
        /// 基本信息表中的全部记录缓存
        /// </summary>
        private static List<BasicInformation> CacheBasicInformationList
        {
            get
            {
                if (null == Helper_Cache.GetCache("ALLBasicInformation"))
                {
                    //查询基本信息的全部记录，写入缓存
                    DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
                    List<BasicInformation> Datas = BasicInformationDAL.SelectIntoTable();
                    SqlCacheDependency Dependency = new SqlCacheDependency("CacheData", "BasicInformation");
                    Helper_Cache.AddCache("ALLBasicInformation", Datas, Dependency);
                    return Datas;
                }
                else
                {
                    return (List<BasicInformation>)Helper_Cache.GetCache("ALLBasicInformation");
                }
            }
        }

        /// <summary>
        /// 添加基本信息的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">基本信息记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertBasicInformation(BasicInformation InsertModel, out int PrimaryKeyValue)
        {
            //处理错误参数
            if (null == InsertModel)
            {
                PrimaryKeyValue = 0;
                return false;
            }
            else { }

            bool result = false;

            //添加基本信息的记录
            DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
            result = BasicInformationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除基本信息的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteBasicInformation()
        {
            bool result = false;

            //删除基本信息的全部记录
            DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
            result = BasicInformationDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除基本信息的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">基本信息主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleBasicInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除基本信息的单条记录
            DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
            result = BasicInformationDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改基本信息的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">基本信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateBasicInformation(BasicInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改基本信息的全部记录
            DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
            result = BasicInformationDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改基本信息的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">基本信息主键</param>
        /// <param name="UpdateModel">基本信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleBasicInformation(int ID, BasicInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改基本信息的单条记录
            DAL_BasicInformation BasicInformationDAL = new DAL_BasicInformation();
            result = BasicInformationDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询基本信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<BasicInformation> SelectBasicInformation()
        {
            //查询基本信息的全部记录
            return CacheBasicInformationList;
        }

        /// <summary>
        /// 分页查询基本信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<BasicInformation> SelectBasicInformation(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((null == CacheBasicInformationList) || (0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<BasicInformation> result = null;

            //分页查询基本信息的全部记录
            var BasicInformationLists = CacheBasicInformationList.Skip((PageIndex - 1) * PageSize).Take(PageSize);

            //处理返回值
            if (BasicInformationLists.Any())
            {
                Total = CacheBasicInformationList.Count;
                result = BasicInformationLists.ToList();
            }
            else
            {
                Total = 0;
            }

            return result;
        }

        /// <summary>
        /// 查询基本信息的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">基本信息主键</param>
        /// <returns>查询到的记录</returns>
        public BasicInformation SelectSingleBasicInformation(int ID)
        {
            //处理错误参数
            if ((0 >= ID) || (null == CacheBasicInformationList))
            {
                return null;
            }
            else { }

            BasicInformation result = null;

            //查询基本信息的单条记录
            var SingleBasicInformation =
                from BasicInformations in CacheBasicInformationList
                where BasicInformations.ID == ID
                select BasicInformations;

            //处理返回值
            if (SingleBasicInformation.Any())
            {
                result = SingleBasicInformation.First();
            }
            else { }

            return result;
        }
    }
}