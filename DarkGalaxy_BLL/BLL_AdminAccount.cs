using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 管理员帐户的BLL层
    /// 提供一系列对于管理员帐户的操作
    /// </summary>
    public class BLL_AdminAccount
    {
        /// <summary>
        /// 添加管理员帐户的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">管理员帐户记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertAdminAccount(AdminAccount InsertModel, out int PrimaryKeyValue)
        {
            bool result = false;

            //添加管理员帐户的记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            InsertModel.Password = iEncryptionAsymmetric.Encryption(InsertModel.Password, MatchCaseType.Lowercase);
            result = AdminAccountDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除管理员帐户的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteAdminAccount()
        {
            bool result = false;

            //删除管理员信息的全部记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            AdminInformationDAL.DeleteIntoTable();

            //删除管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除管理员帐户的全部记录，返回删除是否成功
        /// </summary>
        /// <param name="IDArray">管理员帐户主键集合</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteAdminAccount(int[] IDArray)
        {
            //处理错误参数
            if ((null == IDArray) || (0 == IDArray.Length))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除管理员信息的全部记录
            DAL_AdminInformation AdminInformationDAL = new DAL_AdminInformation();
            AdminInformationDAL.DeleteSingleIntoAdminInformation_AdminAccount(IDArray);

            //删除管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.DeleteIntoTable(IDArray);

            return result;
        }

        /// <summary>
        /// 删除管理员帐户的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">管理员帐户主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleAdminAccount(int ID)
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
            AdminInformationDAL.DeleteSingleIntoAdminInformation_AdminAccount(ID);

            //删除管理员帐户的单条记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改管理员帐户的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">管理员帐户记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateAdminAccount(AdminAccount UpdateModel)
        {
            bool result = false;

            //修改管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            UpdateModel.Password = iEncryptionAsymmetric.Encryption(UpdateModel.Password, MatchCaseType.Lowercase);
            result = AdminAccountDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改管理员帐户的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">管理员帐户主键</param>
        /// <param name="UpdateModel">管理员帐户记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleAdminAccount(int ID, AdminAccount UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改管理员帐户的单条记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            UpdateModel.Password = iEncryptionAsymmetric.Encryption(UpdateModel.Password, MatchCaseType.Lowercase);
            result = AdminAccountDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectAdminAccount()
        {
            List<AdminAccount> result = null;

            //查询管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询管理员帐户的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectAdminAccount(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<AdminAccount> result = null;

            //分页查询管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">管理员帐户主键</param>
        /// <returns>查询到的记录</returns>
        public AdminAccount SelectSingleAdminAccount(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            AdminAccount result = null;

            //查询管理员帐户的单条记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 模糊查询管理员帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectAdminAccountLike(string UserName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(UserName))
            {
                return null;
            }
            else { }

            List<AdminAccount> result = null;

            //模糊查询管理员帐户指定用户名的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectIntoAdminAccountLike(UserName);

            return result;
        }

        /// <summary>
        /// 分页模糊查询管理员帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<AdminAccount> SelectAdminAccountLike(int PageIndex, int PageSize, out int Total, string UserName)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(UserName)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<AdminAccount> result = null;

            //分页查询管理员帐户的全部记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectIntoAdminAccountLike(PageIndex, PageSize, out Total, UserName);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户指定用户名的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>查询到的记录</returns>
        public AdminAccount SelectSingleAdminAccount(string UserName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(UserName))
            {
                return null;
            }
            else { }

            AdminAccount result = null;

            //查询管理员帐户指定用户名的单条记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            result = AdminAccountDAL.SelectSingleIntoAdminAccount(UserName);

            return result;
        }

        /// <summary>
        /// 查询管理员帐户指定用户名、密码的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>查询到的记录</returns>
        public AdminAccount SelectSingleAdminAccount(string UserName, string Password)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                return null;
            }
            else { }

            AdminAccount result = null;

            //查询管理员帐户指定用户名、密码的单条记录
            DAL_AdminAccount AdminAccountDAL = new DAL_AdminAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            Password = iEncryptionAsymmetric.Encryption(Password, MatchCaseType.Lowercase);
            result = AdminAccountDAL.SelectSingleIntoAdminAccount(UserName, Password);

            return result;
        }
    }
}
