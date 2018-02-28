using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 管理员信息的BLL层
    /// 提供一系列对于管理员信息的操作
    /// </summary>
    public class BLL_AdminInformation
    {
        /// <summary>
        /// 添加管理员信息的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">管理员信息记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertAdminInformation(AdminInformation InsertModel, out int PrimaryKeyValue)
        {
            //处理错误参数
            if ((null == InsertModel) || (0 >= InsertModel.AdminAccount_ID))
            {
                PrimaryKeyValue = 0;
                return false;
            }
            else { }

            bool result = false;

            //添加管理员信息的记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除管理员信息的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteAdminInformation()
        {
            bool result = false;

            //删除管理员信息的全部记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除管理员信息的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">管理员信息主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleAdminInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除管理员信息的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改管理员信息的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">管理员信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateAdminInformation(AdminInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改管理员信息的全部记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改管理员信息的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">管理员信息主键</param>
        /// <param name="UpdateModel">管理员信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleAdminInformation(int ID, AdminInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改管理员信息的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询管理员信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<AdminInformation> SelectAdminAccount()
        {
            List<AdminInformation> result = null;

            //查询管理员信息的全部记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 查询管理员信息的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">管理员信息主键</param>
        /// <returns>查询到的记录</returns>
        public AdminInformation SelectSingleAdminInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            AdminInformation result = null;

            //查询管理员信息的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 删除管理员帐户主键对应的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="AdminAccountID">管理员帐户主键</param>
        /// <returns></returns>
        public bool DeleteSingleAdminInformation_AdminAccount(int AdminAccountID)
        {
            //处理错误参数
            if (0 >= AdminAccountID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除管理员帐户主键对应的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.DeleteSingleIntoAdminInformation_AdminAccount(AdminAccountID);

            return result;
        }

        /// <summary>
        /// 修改管理员帐户主键对应的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="AdminAccountID">管理员信息主键</param>
        /// <param name="UpdateModel">管理员信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleAdminInformation_AdminAccount(int AdminAccountID, AdminInformation UpdateModel)
        {
            //处理错误参数
            if ((0 >= AdminAccountID) || (null == UpdateModel))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改管理员帐户主键对应的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.UpdateSingleIntoAdminInformation_AdminAccount(AdminAccountID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户主键对应的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AdminAccountID">管理员帐户主键</param>
        /// <returns>查询到的记录</returns>
        public AdminInformation SelectSingleAdminInformation_AdminAccount(int AdminAccountID)
        {
            //处理错误参数
            if (0 >= AdminAccountID)
            {
                return null;
            }
            else { }

            AdminInformation result = new AdminInformation();

            //查询管理员帐户主键对应的单条记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            result = AdminInformationDAL.SelectSingleIntoAdminInformation_AdminAccount(AdminAccountID);

            return result;
        }
    }
}
