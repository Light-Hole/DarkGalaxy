using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class BasicInfoController : Controller
    {
        public ActionResult Index()
        {
            //查询基本信息表记录，未查询到则新建记录
            BLL_BasicInformation BasicInformationBLL = new BLL_BasicInformation();
            var BasicInformationList = BasicInformationBLL.SelectBasicInformation();
            if (null == BasicInformationList)
            {
                //新建基本信息表记录
                BasicInformation BasicInformationModel = new BasicInformation();
                int BasicInformationModelID = 0;
                if (BasicInformationBLL.InsertBasicInformation(BasicInformationModel,out BasicInformationModelID))
                {
                    ViewData.Model = BasicInformationBLL.SelectSingleBasicInformation(BasicInformationModelID);
                }
                else
                {
                    return View("~/Views/Common/DataNoFound.cshtml");
                }
            }
            else
            {
                //查询基本信息表记录
                ViewData.Model = BasicInformationList[0];
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BasicInformation BasicInfoModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(BasicInfoModel.Title))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改基本信息表记录
            BLL_BasicInformation BasicInformationBLL = new BLL_BasicInformation();
            if (BasicInformationBLL.UpdateSingleBasicInformation(BasicInfoModel.ID, BasicInfoModel))
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