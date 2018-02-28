using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 订单旅客的BLL层
    /// 提供一系列对于订单旅客的操作
    /// </summary>
    public class BLL_OrderPassenger
    {
        /// <summary>
        /// 添加订单旅客记录，返回添加是否成功
        /// 添加失败则返回null
        /// </summary>
        /// <param name="InsertModel">订单旅客记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertOrderPassenger(OrderPassenger InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.InsertIntoTable(InsertModel,out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除订单旅客全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteOrderPassenger()
        {
            bool result = false;

            //删除订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除订单旅客单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">订单旅客主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleOrderPassenger(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改订单旅客全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">订单旅客记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateOrderPassenger(OrderPassenger UpdateModel)
        {
            bool result = false;

            //修改订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改订单旅客单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">订单旅客主键</param>
        /// <param name="UpdateModel">订单旅客记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleOrderPassenger(int ID, OrderPassenger UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询订单旅客全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderPassenger> SelectOrderPassenger(string Where = null)
        {
            List<OrderPassenger> result = null;

            //查询订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.SelectIntoTable(Where);

            return result;
        }

        /// <summary>
        /// 分页查询订单旅客全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="Where">查询条件</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderPassenger> SelectOrderPassenger(int PageIndex, int PageSize, out int Total, string Where = null)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<OrderPassenger> result = null;

            //查询订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.SelectIntoTable(PageIndex, PageSize, out Total, Where);

            return result;
        }

        /// <summary>
        /// 查询订单旅客单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">订单旅客主键</param>
        /// <returns>查询到的记录</returns>
        public OrderPassenger SelectSingleOrderPassenger(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            OrderPassenger result = null;

            //查询订单旅客记录
            DAL_OrderPassenger OrderPassengerDAL = new DAL_OrderPassenger();
            result = OrderPassengerDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询用户订单主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录或传入参数错误则返回null
        /// </summary>
        /// <param name="Order_ID">订单主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<OrderPassenger> SelectOrderPassenger_Order(int Order_ID)
        {
            List<OrderPassenger> result = null;

            DAL_OrderPassenger dalOrderPassenger = new DAL_OrderPassenger();
            result = dalOrderPassenger.SelectIntoOrderPassenger_Order(Order_ID);

            return result;
        }
    }
}