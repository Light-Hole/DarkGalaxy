using DarkGalaxy_DAL;
using DarkGalaxy_Model;
using System.Collections.Generic;

namespace DarkGalaxy_BLL
{
    /// <summary>
    /// 用户信息的BLL层
    /// 提供一系列对于用户信息的操作
    /// </summary>
    public class BLL_UserInformation
    {
        /// <summary>
        /// 添加用户信息的记录，返回添加是否成功
        /// </summary>
        /// <param name="InsertModel">用户信息记录</param>
        /// <param name="PrimaryKeyValue">记录主键的值</param>
        /// <returns>添加是否成功</returns>
        public bool InsertUserInformation(UserInformation InsertModel, out int PrimaryKeyValue)
        {
            //处理错误参数
            if ((null == InsertModel) || (0 >= InsertModel.UserAccount_ID))
            {
                PrimaryKeyValue = 0;
                return false;
            }
            else { }

            bool result = false;
            PrimaryKeyValue = 0;

            //添加用户信息的记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            var SingleModel = UserInformationDAL.SelectSingleIntoUserInformation_UserAccount(InsertModel.UserAccount_ID);
            if (null == SingleModel)
            {
                result = UserInformationDAL.InsertIntoTable(InsertModel, out PrimaryKeyValue);
            }
            else { }

            return result;
        }

        /// <summary>
        /// 删除用户信息的全部记录，返回删除是否成功
        /// </summary>
        /// <returns>删除是否成功</returns>
        public bool DeleteUserInformation()
        {
            bool result = false;

            //删除用户信息的全部记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.DeleteIntoTable();

            return result;
        }

        /// <summary>
        /// 删除用户信息的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">用户信息主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteSingleUserInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除用户信息的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.DeleteSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 修改用户信息的全部记录，返回修改是否成功
        /// </summary>
        /// <param name="UpdateModel">用户信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateUserInformation(UserInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= UpdateModel.ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户信息的全部记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.UpdateIntoTable(UpdateModel);

            return result;
        }

        /// <summary>
        /// 修改用户信息的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="ID">用户信息主键</param>
        /// <param name="UpdateModel">用户信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleUserInformation(int ID, UserInformation UpdateModel)
        {
            //处理错误参数
            if ((null == UpdateModel) || (0 >= ID))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户信息的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.UpdateSingleIntoTable(ID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询用户信息的全部记录，返回查询到的记录集合
        /// 未查询到记录则返回null
        /// </summary>
        /// <returns>查询到的记录集合</returns>
        public List<UserInformation> SelectUserAccount()
        {
            List<UserInformation> result = null;

            //查询用户信息的全部记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.SelectIntoTable();

            return result;
        }

        /// <summary>
        /// 查询用户信息的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="ID">用户信息主键</param>
        /// <returns>查询到的记录</returns>
        public UserInformation SelectSingleUserInformation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return null;
            }
            else { }

            UserInformation result = null;

            //查询用户信息的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.SelectSingleIntoTable(ID);

            return result;
        }

        /// <summary>
        /// 删除用户帐户主键对应的单条记录，返回删除是否成功
        /// </summary>
        /// <param name="UserAccountID">用户帐户主键</param>
        /// <returns></returns>
        public bool DeleteSingleUserInformation_UserAccount(int UserAccountID)
        {
            //处理错误参数
            if (0 >= UserAccountID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除用户帐户主键对应的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.DeleteSingleIntoUserInformation_UserAccount(UserAccountID);

            return result;
        }

        /// <summary>
        /// 修改用户帐户主键对应的单条记录，返回修改是否成功
        /// </summary>
        /// <param name="UserAccountID">用户信息主键</param>
        /// <param name="UpdateModel">用户信息记录</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateSingleUserInformation_UserAccount(int UserAccountID, UserInformation UpdateModel)
        {
            //处理错误参数
            if ((0 >= UserAccountID) || (null == UpdateModel))
            {
                return false;
            }
            else { }

            bool result = false;

            //修改用户帐户主键对应的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.UpdateSingleIntoUserInformation_UserAccount(UserAccountID, UpdateModel);

            return result;
        }

        /// <summary>
        /// 查询用户帐户主键对应的单条记录，返回查询到的记录
        /// 未查询到记录则返回null
        /// </summary>
        /// <param name="UserAccountID">用户帐户主键</param>
        /// <returns>查询到的记录</returns>
        public UserInformation SelectSingleUserInformation_UserAccount(int UserAccountID)
        {
            //处理错误参数
            if (0 >= UserAccountID)
            {
                return null;
            }
            else { }

            UserInformation result = new UserInformation();

            //查询用户帐户主键对应的单条记录
            DAL_UserInformation UserInformationDAL = new DAL_UserInformation();
            result = UserInformationDAL.SelectSingleIntoUserInformation_UserAccount(UserAccountID);

            return result;
        }
    }
}
