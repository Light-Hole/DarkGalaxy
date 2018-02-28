using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 联系人的BLL层
    /// 提供一系列对于联系人的操作
    /// </summary>
    public class BLL_Contacts
    {
        /// <summary>
        /// 添加联系人的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">联系人记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertContacts(Contacts InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加联系人的记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除联系人的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteContacts()
        {
            bool result = false;

            //删除联系人的全部记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除联系人的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">联系人主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleContacts(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除联系人的单条记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改联系人的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">联系人记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateContacts(Contacts UpdateModel)
        {
            bool result = false;

            //修改联系人的全部记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改联系人的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">联系人主键</param>
        /// <param name="UpdateModel">联系人记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleContacts(int ID, Contacts UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改联系人的单条记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询联系人的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<Contacts> SelectContacts()
        {
            List<Contacts> result = null;

            //查询联系人的全部记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询联系人的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<Contacts> SelectContacts(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<Contacts> result = null;

            //分页查询联系人的全部记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询联系人的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">联系人主键</param>
        /// <returns>查询到的记录</returns>
        public Contacts SelectSingleContacts(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            Contacts result = null;

            //查询联系人的单条记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserAccountID">用户帐户主键</param>
        /// <returns>查询到的记录集合</returns>
        public List<Contacts> SelectContacts_UserAccount(int UserAccountID)
        {
            //处理错误参数
            if (0 >= UserAccountID)
            {
                return null;
            }
            else { }

            List<Contacts> result = null;

            //查询传入用户帐户主键的全部记录
            DAL_Contacts ContactsDAL = new DAL_Contacts();
            result = ContactsDAL.SelectIntoContacts_UserAccount(UserAccountID);

            return result;
        }
    }
}