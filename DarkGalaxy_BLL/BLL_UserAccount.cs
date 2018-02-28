using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_DAL;
using DarkGalaxy_Helper;
using DarkGalaxy_IHelper;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 用户帐户的BLL层
    /// 提供一系列对于用户帐户的操作
    /// </summary>
    public class BLL_UserAccount
    {
        /// <summary>
        /// 添加用户帐户的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">用户帐户记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertUserAccount(UserAccount InsertModel, out int PrimaryKeyValue)
        {
            //处理错误参数
            PrimaryKeyValue = 0;
            if ((null == InsertModel) || (String.IsNullOrEmpty(InsertModel.UserName) && String.IsNullOrEmpty(InsertModel.Email) && String.IsNullOrEmpty(InsertModel.Phone) && String.IsNullOrEmpty(InsertModel.OpenID)))
            {
                //未传入任何帐号（个性帐号、邮箱、手机、WeChat）
                return false;
            }
            else if ((false == String.IsNullOrEmpty(InsertModel.Email)) && ((String.IsNullOrEmpty(InsertModel.Password)) || (false == Regex.IsMatch(InsertModel.Email, @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})", RegexOptions.IgnoreCase))))
            {
                //传入邮箱帐号，但未传入密码或者格式不正确
                return false;
            }
            else if ((false == String.IsNullOrEmpty(InsertModel.Phone)) && ((String.IsNullOrEmpty(InsertModel.Password)) || (false == Regex.IsMatch(InsertModel.Phone, @"^1[0-9]{10}$", RegexOptions.IgnoreCase))))
            {
                //传入手机帐号，但未传入密码或者格式不正确
                return false;
            }
            else { }

            bool result = false;

            //添加用户帐户的记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            InsertModel.Password = iEncryptionAsymmetric.Encryption(InsertModel.Password, MatchCaseType.Lowercase);
            result = UserAccountDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);

            return result;
        }

        /// <summary>
        /// 删除用户帐户的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteUserAccount()
        {
            bool result = false;

            //删除用户信息的全部记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            UserInformationDAL.DeleteIntoTable();

            //删除用户帐户的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除用户帐户的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">用户帐户主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleUserAccount(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除用户帐户的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            UserInformationDAL.DeleteSingleIntoUserInformation_UserAccount(ID);

            //删除用户帐户的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改用户帐户的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">用户帐户记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateUserAccount(UserAccount UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID) || (String.IsNullOrEmpty(UpdateModel.UserName) && String.IsNullOrEmpty(UpdateModel.Email) && String.IsNullOrEmpty(UpdateModel.Phone)))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户帐户的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            UpdateModel.Password = iEncryptionAsymmetric.Encryption(UpdateModel.Password, MatchCaseType.Lowercase);
            result = UserAccountDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改用户帐户的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">用户帐户主键</param>
        /// <param name="UpdateModel">用户帐户记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleUserAccount(int ID, UserAccount UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID) || (String.IsNullOrEmpty(UpdateModel.UserName) && String.IsNullOrEmpty(UpdateModel.Email) && String.IsNullOrEmpty(UpdateModel.Phone)))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户帐户的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            UpdateModel.Password = iEncryptionAsymmetric.Encryption(UpdateModel.Password, MatchCaseType.Lowercase);
            result = UserAccountDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询用户帐户的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectUserAccount()
        {
            List<UserAccount> result = null;

            //查询用户帐户的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 分页查询用户帐号的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectUserAccount(int PageIndex, int PageSize, out int Total)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize))
            {
                Total = 0;
                return null;
            }
            else { }

            List<UserAccount> result = null;

            //分页查询用户帐号的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectIntoTable(PageIndex, PageSize, out Total);

            return result;
        }

        /// <summary>
        /// 查询用户帐户的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">用户帐户主键</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleUserAccount(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定帐号名（手机、邮箱、个性帐号）的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">帐号名</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleUserAccount(string AccountName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定帐号名（手机、邮箱、个性帐号）的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectSingleIntoUserAccount(AccountName);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定帐号名（手机、邮箱、个性帐号）、密码的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">帐号名</param>
        /// <param name="Password">密码</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleUserAccount(string AccountName, string Password)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName) || String.IsNullOrEmpty(Password))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定帐号名（手机、邮箱、个性帐号）、密码的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            IEncryptionAsymmetric iEncryptionAsymmetric = new Helper_Encryption_MD5();
            Password = iEncryptionAsymmetric.Encryption(Password, MatchCaseType.Lowercase);
            result = UserAccountDAL.SelectSingleIntoUserAccount(AccountName, Password);

            return result;
        }

        /// <summary>
        /// 查询用户帐户指定OpenID的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="OpenID">WeChat用户唯一标识</param>
        /// <returns>查询到的记录</returns>
        public UserAccount SelectSingleIntoUserAccount_WeChat(string OpenID)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(OpenID))
            {
                return null;
            }
            else { }

            UserAccount result = null;

            //查询用户帐户指定OpenID的单条记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectSingleIntoUserAccount_WeChat(OpenID);

            return result;
        }

        /// <summary>
        /// 模糊查询用户帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="AccountName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectUserAccountLike(string AccountName)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(AccountName))
            {
                return null;
            }
            else { }

            List<UserAccount> result = null;

            //模糊查询用户帐户指定用户名的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectIntoUserAccountLike(AccountName);

            return result;
        }

        /// <summary>
        /// 分页模糊查询用户帐户指定用户名的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Total">分页数据总数</param>
        /// <param name="AccountName">用户名</param>
        /// <returns>查询到的记录集合</returns>
        public List<UserAccount> SelectUserAccountLike(int PageIndex, int PageSize, out int Total, string AccountName)
        {
            //处理错误参数
            if ((0 >= PageIndex) || (0 >= PageSize) || (String.IsNullOrEmpty(AccountName)))
            {
                Total = 0;
                return null;
            }
            else { }

            List<UserAccount> result = null;

            //分页模糊查询用户帐户指定用户名的全部记录
            DAL_UserAccount UserAccountDAL = new DAL_UserAccount();
            result = UserAccountDAL.SelectIntoUserAccountLike(PageIndex, PageSize, out Total, AccountName);

            return result;
        }
    }
}
