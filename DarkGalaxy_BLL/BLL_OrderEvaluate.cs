using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 评价的BLL层
    /// 提供一系列对于评价的操作
    /// </summary>
    public class BLL_Evaluate
    {
        /// <summary>
        /// 添加评价的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">评价记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertEvaluate(Evaluate InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加评价的记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除评价的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteEvaluate()
        {
            bool result = false;

            //删除评价的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除评价的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">评价主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteEvaluate(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除评价的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除评价的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">评价主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleEvaluate(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除评价的单条记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改评价的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">评价记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateEvaluate(Evaluate UpdateModel)
        {
            bool result = false;

            //修改评价的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改评价的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">评价主键</param>
        /// <param name="UpdateModel">评价记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleEvaluate(int ID, Evaluate UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改评价的单条记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询评价的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Evaluate> SelectEvaluate()
        {
            List<Evaluate> result = null;

            //查询评价的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询评价的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Evaluate> SelectEvaluate(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Evaluate> result = null;

            //分页查询评价的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询评价的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">评价主键</param>
        /// <returns>查询到的记录</returns>
        public Evaluate SelectSingleEvaluate(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Evaluate result = null;

            //查询评价的单条记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改评价指定主键的记录的AuditStatus与AdminAccount_ID字段值，返回修改是否成功
        /// </summary>
        /// <param name="ID">评价主键</param>
        /// <param name="AuditStatus">审核状态</param>
        /// <param name="AdminAccountID">管理员主键</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateEvaluateSetAuditStatus(int ID, bool AuditStatus, int AdminAccountID)
        {
            bool result = false;

            //修改评价指定主键的记录的AuditStatus与AdminAccount_ID字段值
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.UpdateIntoEvaluateSetAuditStatus(ID, AuditStatus, AdminAccountID);

            return result;
        }

        /// <summary>
        /// 查询未审核的记录数量，返回查询到的未审核记录数量
        /// </summary>
        /// <param name="OrderID">订单主键</param>
        /// <returns></returns>
        public int SelectEvaluateNotAudit(int OrderID)
        {
            int result = 0;

            //查询未审核的记录数量
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoEvaluateNotAudit(OrderID);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserAccountID">用户帐户主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Evaluate> SelectEvaluate_UserAccount(int UserAccountID)
        {
            //处理错误参数
            if (0 >= UserAccountID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

            //查询用户帐户主键对应的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoEvaluate_UserAccount(UserAccountID);

            return result;
        }

        /// <summary>
        /// 查询商品主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="CommodityID">商品主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Evaluate> SelectEvaluate_Commodity(int CommodityID)
        {
            //处理错误参数
            if (0 >= CommodityID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

            //查询商品主键对应的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoEvaluate_Commodity(CommodityID);

            return result;
        }

        /// <summary>
        /// 查询订单主键对应的全部记录，返回查询到的产品记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OrderID">订单主键</param>
        /// <returns>查询到的产品记录集合</returns>
        public List<Evaluate> SelectEvaluate_Order(int OrderID)
        {
            //处理错误参数
            if (0 >= OrderID)
            {
                return null;
            }
            else { }

            List<Evaluate> result = null;

            //查询订单主键对应的全部记录
            DAL_Evaluate OrderEvaluateDAL = new DAL_Evaluate();
            result = OrderEvaluateDAL.SelectIntoEvaluate_Order(OrderID);

            return result;
        }
    }
}