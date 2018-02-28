using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 订单详情的BLL层
    /// 提供一系列对于订单详情的操作
    /// </summary>
    public class BLL_OrderDetail
    {
        /// <summary>
        /// 添加订单详情的记录，返回添加的记录主键
        /// 添加失败则返回0
        /// </summary>
        /// <param name="InsertModel">订单详情记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加的记录主键</returns>
        public bool InsertOrderDetail(OrderDetail InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加订单详情的记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.InsertIntoTable(InsertModel,out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除订单详情的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteOrderDetail()
        {
            bool result = false;

            //删除订单详情的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除订单详情的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">订单详情主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteOrderDetail(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除订单详情的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除订单详情的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">订单详情主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleOrderDetail(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除订单详情的单条记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改订单详情的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">订单详情记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateOrderDetail(OrderDetail UpdateModel)
        {
            bool result = false;

            //修改订单详情的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改订单详情的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">订单详情主键</param>
        /// <param name="UpdateModel">订单详情记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleOrderDetail(int ID, OrderDetail UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改订单详情的单条记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询订单详情的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectOrderDetail()
        {
            List<OrderDetail> result = null;

            //查询订单详情的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询订单详情的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderDetail> SelectOrderDetail(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //分页查询订单详情的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询订单详情的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">订单详情主键</param>
        /// <returns>查询到的记录</returns>
        public OrderDetail SelectSingleOrderDetail(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            OrderDetail result = null;

            //查询订单详情的单条记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询商品规格主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="SpecificationID">商品规格主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<OrderDetail> SelectOrderDetail_Specification(int SpecificationID)
        {
            //处理错误参数
            if (0 >= SpecificationID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品规格主键对应的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoOrderDetail_Specification(SpecificationID);

            return result;
        }

        /// <summary>
        /// 查询商品规格分类主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="SpecificationCategoryID">商品规格分类主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<OrderDetail> SelectOrderDetail_SpecificationCategory(int SpecificationCategoryID)
        {
            //处理错误参数
            if (0 >= SpecificationCategoryID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品规格分类主键对应的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoOrderDetail_SpecificationCategory(SpecificationCategoryID);

            return result;
        }

        /// <summary>
        /// 查询商品主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="CommodityID">商品主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<OrderDetail> SelectOrderDetail_Commodity(int CommodityID)
        {
            //处理错误参数
            if (0 >= CommodityID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询商品主键对应的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoOrderDetail_Commodity(CommodityID);

            return result;
        }

        /// <summary>
        /// 查询订单主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OrderID">订单主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<OrderDetail> SelectOrderDetail_Order(int OrderID)
        {
            //处理错误参数
            if (0 >= OrderID)
            {
                return null;
            }
            else { }

            List<OrderDetail> result = null;

            //查询订单主键对应的全部记录
            DAL_OrderDetail OrderDetailDAL = new DAL_OrderDetail();
            result = OrderDetailDAL.SelectIntoOrderDetail_Order(OrderID);

            return result;
        }
    }
}