using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class WeChatBasicInfoController : Controller
    {
        public ActionResult Index()
        {
            //查询WeChat基本信息表记录，未查询到则新建记录
            BLL_WeChatBasicInformation WeChatBasicInformationBLL = new BLL_WeChatBasicInformation();
            List<WeChatBasicInformation> WeChatBasicInformationList = WeChatBasicInformationBLL.SelectWeChatBasicInformation();
            if (null == WeChatBasicInformationList)
            {
                //新建WeChat基本信息表记录
                int ID = 0;
                WeChatBasicInformation model = new WeChatBasicInformation();
                if (WeChatBasicInformationBLL.InsertWeChatBasicInformation(model, out ID))
                {
                    ViewData.Model = WeChatBasicInformationBLL.SelectSingleWeChatBasicInformation(ID);
                }
                else
                {
                    return View("~/Views/Common/DataNoFound.cshtml");
                }
            }
            else
            {
                //查询WeChat基本信息表记录
                ViewData.Model = WeChatBasicInformationList[0];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(WeChatBasicInformation WeChatBasicInfoModel)
        {
            DGResultMessage result = new DGResultMessage();

            //修改WeChat基本信息表记录
            BLL_WeChatBasicInformation WeChatBasicInfoBLL = new BLL_WeChatBasicInformation();
            if (WeChatBasicInfoBLL.UpdateSingleWeChatBasicInformation(WeChatBasicInfoModel.ID, WeChatBasicInfoModel))
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