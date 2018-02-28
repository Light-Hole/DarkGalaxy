using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using DarkGalaxy_UI_Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class UserInfoController : Controller
    {
        public ActionResult Details(int UID)
        {
            //处理错误参数
            if (0 >= UID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            UserInfoViewModel result = new UserInfoViewModel();

            //查询用户帐户记录
            BLL_UserAccount UserAccountBLL = new BLL_UserAccount();
            UserAccount UserAccountModel = UserAccountBLL.SelectSingleUserAccount(UID);

            //查询用户信息记录
            BLL_UserInformation UserInformationBLL = new BLL_UserInformation();
            UserInformation UserInformationModel = UserInformationBLL.SelectSingleUserInformation_UserAccount(UID);

            //处理返回值
            if ((null != UserAccountModel) && (null != UserInformationModel))
            {
                result.UserAccountModel = UserAccountModel;
                result.UserInfoModel = UserInformationModel;
                ViewData.Model = result;
                return View();
            }
            else
            {
                return View("~/Views/Common/DataNoFound.cshtml");
            }
        }
    }
}