using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_IBLL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 订单的BLL层
    /// 提供一系列对于订单的操作
    /// </summary>
    public class BLL_Order : IStatistics<double>
    {
        /// <summary>
        /// 统计订单价格数据，返回统计获取的数据值
        /// </summary>
        /// <param name="days">统计天数</param>
        /// <returns>统计获取的数据值</returns>
        public double StatisticsData(int days)
        {
            double result = 0;

            //统计订单价格数据
            DAL_Order dalOrder = new DAL_Order();
            DateTime dtmStartDateTime = DateTime.Now.AddDays(-days);
            DateTime dtmEndDateTime = DateTime.Now;
            result = dalOrder.SelectOrderTotalPrice(dtmStartDateTime, dtmEndDateTime);

            return result;
        }

        /// <summary>
        /// 统计订单价格数据，返回统计获取的数据值
        /// </summary>
        /// <param name="startDateTime">起始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <returns>统计获取的数据值</returns>
        public double StatisticsData(DateTime startDateTime, DateTime endDateTime)
        {
            double result = 0;

            //统计订单价格数据
            DAL_Order dalOrder = new DAL_Order();
            result = dalOrder.SelectOrderTotalPrice(startDateTime, endDateTime);

            return result;
        }

        /// <summary>
        /// 添加订单的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">订单记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertOrder(Order InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加订单的记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除订单的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteOrder()
        {
            bool result = false;

            //删除订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除订单的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">订单主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteOrder(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除订单的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">订单主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleOrder(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除订单的单条记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改订单的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">订单记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateOrder(Order UpdateModel)
        {
            bool result = false;

            //修改订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改订单的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">订单主键</param>
        /// <param name="UpdateModel">订单记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleOrder(int ID, Order UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改订单的单条记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询订单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrder()
        {
            List<Order> result = null;

            //查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询订单的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrder(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询订单的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">订单主键</param>
        /// <returns>查询到的记录</returns>
        public Order SelectSingleOrder(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Order result = null;

            //查询订单的单条记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 分页查询订单的全部记录（后台部分订单状态），返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrderManage(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectIntoTable(PageIndex, PageSize, out Total, "Status in (10,20,50,52,60,62,64)");

            return result;
        }

        /// <summary>
        /// 修改订单指定主键的订单状态，返回修改是否成功
        /// </summary>
        /// <param name="ID">订单主键</param>
        /// <param name="Status">订单状态</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateOrderStatus(int ID, OrderStatusType Status)
        {
            bool result = false;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.UpdateIntoOrderSetStatus(ID, Convert.ToInt32(Status));

            return result;
        }

        /// <summary>
        /// 查询订单指定订单号的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderNumber">订单号/微信订单号</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrder(int PageIndex, int PageSize, out int Total, string OrderNumber)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(OrderNumber)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectIntoOrder(PageIndex, PageSize, out Total, OrderNumber);

            return result;
        }

        /// <summary>
        /// 查询订单指定条件的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <param name="StartDate">创建订单起始时间</param>
        /// <param name="EndDate">创建订单结束时间</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrder(int PageIndex, int PageSize, out int Total, OrderStatusType? OrderStatus = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectIntoOrder(PageIndex, PageSize, out Total, OrderStatus, StartDate, EndDate);

            return result;
        }

        /// <summary>
        /// 查询订单指定状态的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="OrderStatues">订单状态集合</param>
        /// <param name="UserAccountID">用户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Order> SelectOrder_UserAccount(int PageIndex, int PageSize, out int Total, OrderStatusType[] OrderStatues, int UserAccountID)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (null == OrderStatues) || (0 >= OrderStatues.Length) || (0 >= UserAccountID))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Order> result = null;

            //分页查询订单的全部记录
            DAL_Order OrderDAL = new DAL_Order();
            if ((-1 != Array.IndexOf(OrderStatues, OrderStatusType.Pay)) || (-1 != Array.IndexOf(OrderStatues, OrderStatusType.Evaluate)))
            {
                //查询已支付与待评价的订单记录
                OrderStatusType[] arrOrderStatus =
                {
                    OrderStatusType.Pay,
                    OrderStatusType.Evaluate
                };
                List<Order> lisOrder = OrderDAL.SelectIntoOrder_UserAccount(PageIndex, PageSize, out Total, arrOrderStatus, UserAccountID);
                if (null != lisOrder)
                {
                    DAL_Commodity dalCommodity = new DAL_Commodity();
                    DAL_OrderDetail dalOrderDetail = new DAL_OrderDetail();
                    foreach (var temp in lisOrder)
                    {
                        //查询订单详情记录
                        var lisOrderDetail = dalOrderDetail.SelectIntoOrderDetail_Order(temp.ID);
                        if (null != lisOrderDetail)
                        {
                            foreach (var tmepDetail in lisOrderDetail)
                            {
                                //查询商品记录
                                var modCommodity = dalCommodity.SelectSingleIntoTable(tmepDetail.Commodity_ID);
                                if (null != modCommodity)
                                {
                                    if (DateTime.Now >= modCommodity.DepartureDate)
                                    {
                                        //修改订单状态为待评价
                                        OrderDAL.UpdateIntoOrderSetStatus(temp.ID, Convert.ToInt32(OrderStatusType.Evaluate));
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }
            result = OrderDAL.SelectIntoOrder_UserAccount(PageIndex, PageSize, out Total, OrderStatues, UserAccountID);

            return result;
        }

        /// <summary>
        /// 查询退款订单号的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="RefundNumber">退款订单号</param>
        /// <returns>查询到的记录</returns>
        public Order SelectSingleOrderByRefund(string RefundNumber)
        {
            //处理返回值
            if (String.IsNullOrEmpty(RefundNumber))
            {
                return null;
            }
            else { }

            Order result = null;

            //查询退款订单号的单条记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectSingleIntoOrderByRefund(RefundNumber);

            return result;
        }

        /// <summary>
        /// 查询订单号的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OrderNumber">订单号</param>
        /// <returns>查询到的记录</returns>
        public Order SelectSingleOrderByNumber(string OrderNumber)
        {
            //处理返回值
            if (String.IsNullOrEmpty(OrderNumber))
            {
                return null;
            }
            else { }

            Order result = null;

            //查询订单号的单条记录
            DAL_Order OrderDAL = new DAL_Order();
            result = OrderDAL.SelectSingleIntoOrderByNumber(OrderNumber);

            return result;
        }
    }
}