using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class AdminInfoController : Controller
    {
        public ActionResult Details(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            AdminInformation result = null;

            //查询用户信息记录
            BLL_AdminInformation AdminInformationBLL = new BLL_AdminInformation();
            result = AdminInformationBLL.SelectSingleAdminInformation_AdminAccount(ID);

            //处理返回值
            if (null != result)
            {
                ViewData.Model = result;
                return View();
            }
            else
            {
                return View("~/Views/Common/DataNoFound.cshtml");
            }
        }

        public ActionResult Edit(int id)
        {
            AdminInformation result = null;

            //查询用户信息记录
            BLL_AdminInformation bllAdminInfo = new BLL_AdminInformation();
            result = bllAdminInfo.SelectSingleAdminInformation_AdminAccount(id);

            //处理返回值
            if (null != result)
            {
                ViewData.Model = result;
                return View();
            }
            else
            {
                return View("~/Views/Common/DataNoFound.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Edit(AdminInformation adminInfoModel)
        {
            DGResultMessage result = new DGResultMessage();

            //修改用户信息记录
            BLL_AdminInformation bllAdminInfo = new BLL_AdminInformation();
            if (bllAdminInfo.UpdateSingleAdminInformation(adminInfoModel.ID, adminInfoModel))
            {
                result.Code = ResultCodeType.Succeed;
                result.Message = "修改成功";
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "修改失败";
            }

            return Json(result);
        }
    }
}