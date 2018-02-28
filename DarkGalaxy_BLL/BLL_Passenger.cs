
using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 旅客的BLL层
    /// 提供一系列对于旅客的操作
    /// </summary>
    public class BLL_Passenger
    {
        /// <summary>
        /// 添加旅客的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">旅客记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertPassenger(Passenger InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加旅客的记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除旅客的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeletePassenger()
        {
            bool result = false;

            //删除旅客的全部记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除旅客的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">旅客主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSinglePassenger(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除旅客的单条记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改旅客的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">旅客记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdatePassenger(Passenger UpdateModel)
        {
            bool result = false;

            //修改旅客的全部记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改旅客的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">旅客主键</param>
        /// <param name="UpdateModel">旅客记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSinglePassenger(int ID, Passenger UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改旅客的单条记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询旅客的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Passenger> SelectPassenger()
        {
            List<Passenger> result = null;

            //查询旅客的全部记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询旅客的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Passenger> SelectPassenger(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Passenger> result = null;

            //分页查询旅客的全部记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询旅客的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">旅客主键</param>
        /// <returns>查询到的记录</returns>
        public Passenger SelectSinglePassenger(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Passenger result = null;

            //查询旅客的单条记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserAccountID">用户帐户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Passenger> SelectPassenger_UserAccount(int UserAccountID)
        {
            //处理错误参数
            if (0 >= UserAccountID)
            {
                return null;
            }
            else { }

            List<Passenger> result = null;

            //查询用户帐户主键对应的全部记录
            DAL_Passenger PassengerDAL = new DAL_Passenger();
            result = PassengerDAL.SelectIntoPassenger_UserAccount(UserAccountID);

            return result;
        }
    }
}