using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 商品的BLL层
    /// 提供一系列对于商品的操作
    /// </summary>
    public class BLL_Commodity
    {
        /// <summary>
        /// 添加商品的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">商品记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertCommodity(Commodity InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加商品的记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除商品的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteCommodity()
        {
            bool result = false;

            //删除商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除商品的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">商品主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteCommodity(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除商品的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">商品主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleCommodity(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除商品的单条记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改商品的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">商品记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateCommodity(Commodity UpdateModel)
        {
            bool result = false;

            //修改商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改商品的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">商品主键</param>
        /// <param name="UpdateModel">商品记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleCommodity(int ID, Commodity UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改商品的单条记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询商品的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodity()
        {
            List<Commodity> result = null;

            //查询商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询商品的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodity(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //分页查询商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询商品的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">商品主键</param>
        /// <returns>查询到的记录</returns>
        public Commodity SelectSingleCommodity(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Commodity result = null;

            //查询商品的单条记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询商品的单条记录（包括失效记录），返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">商品主键</param>
        /// <returns>查询到的记录</returns>
        public Commodity SelectSingleCommodityAll(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Commodity result = null;

            //查询商品的单条记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectSingleIntoTable(ID, "1 = 1");

            return result;
        }

        /// <summary>
        /// 模糊查询商品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodityLike(string Title)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Title))
            {
                return null;
            }
            else { }

            List<Commodity> result = null;

            //模糊查询商品指定标题的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoCommodityLike(Title);

            return result;
        }

        /// <summary>
        /// 分页模糊查询商品指定标题的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Title">标题</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodityLike(int PageIndex, int PageSize, out int Total, string Title)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(Title)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //分页模糊查询商品指定标题的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoCommodityLike(PageIndex, PageSize, out Total, Title);

            return result;
        }

        /// <summary>
        /// 分页查询商品的全部有效记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodityValid(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //分页查询商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoCommodityValid(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 分页模糊查询商品的全部有效记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Site">地点</param>
        /// <param name="DepartureDate">出发日期</param>
        /// <param name="RegressionDate">返回日期</param>
        /// <param name="sortType">排序类型</param>
        /// <returns>查询到的记录集合</returns>
        public List<Commodity> SelectCommodityValidLike(int PageIndex, int PageSize, out int Total, string Site = null, DateTime? DepartureDate = null, DateTime? RegressionDate = null, CommoditySortType sortType = CommoditySortType.Default)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Commodity> result = null;

            //分页查询商品的全部记录
            DAL_Commodity CommodityDAL = new DAL_Commodity();
            result = CommodityDAL.SelectIntoCommodityValidLike(PageIndex, PageSize, out Total, Site, DepartureDate, RegressionDate, sortType);

            return result;
        }
    }
}