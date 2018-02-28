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
    public class SpecificationController : Controller
    {
        public ActionResult Create(int CategoryID, int CommodityID)
        {
            //处理错误参数
            if ((0 >= CategoryID) || (0 >= CommodityID))
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            ViewData["CategoryID"] = CategoryID;
            ViewData["CommodityID"] = CommodityID;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Specification SpecificationModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(SpecificationModel.Title)) || (String.IsNullOrEmpty(SpecificationModel.ImagePath)) || (0 >= FloatPrice) || (0 >= SpecificationModel.Guest) || (String.IsNullOrEmpty(SpecificationModel.Floors)) || (0 >= SpecificationModel.Area) || (0 >= SpecificationModel.Commodity_ID) || (0 >= SpecificationModel.SpecificationCategory_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建商品规格记录
            int ID = 0;
            BLL_Specification SpecificationBLL = new BLL_Specification();
            SpecificationModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (SpecificationBLL.InsertSpecification(SpecificationModel, out ID))
            {
                result.Code = ResultCodeType.Succeed;
                result.Message = "新建成功";
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "新建失败";
            }

            return Json(result);
        }

        public ActionResult Delete(int ID)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (0 >= ID)
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //删除商品规格记录
            BLL_Specification SpecificationBLL = new BLL_Specification();
            if (SpecificationBLL.DeleteSingleSpecification(ID))
            {
                result.Code = ResultCodeType.Succeed;
                result.Message = "删除成功";
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "删除失败";
            }

            return Json(result);
        }

        public ActionResult Edit(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            Specification result = null;

            //查询商品规格记录
            BLL_Specification SpecificationBLL = new BLL_Specification();
            result = SpecificationBLL.SelectSingleSpecification(ID);

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
        public ActionResult Edit(Specification SpecificationModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(SpecificationModel.Title)) || (String.IsNullOrEmpty(SpecificationModel.ImagePath)) || (0 >= FloatPrice) || (0 >= SpecificationModel.Guest) || (String.IsNullOrEmpty(SpecificationModel.Floors)) || (0 >= SpecificationModel.Area) || (0 >= SpecificationModel.Commodity_ID) || (0 >= SpecificationModel.SpecificationCategory_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改商品规格记录
            BLL_Specification SpecificationBLL = new BLL_Specification();
            SpecificationModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (SpecificationBLL.UpdateSingleSpecification(SpecificationModel.ID, SpecificationModel))
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