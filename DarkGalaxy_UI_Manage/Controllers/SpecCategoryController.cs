using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
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
    public class SpecCategoryController : Controller
    {
        public ActionResult Create(int CommodityID)
        {
            ViewData["CommodityID"] = CommodityID;

            return View();
        }

        [HttpPost]
        public ActionResult Create(SpecificationCategory SpecCategoryModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(SpecCategoryModel.Title)) || (String.IsNullOrEmpty(SpecCategoryModel.ImagePath)) || (0 >= FloatPrice) || (0 >= SpecCategoryModel.GuestMin) || (0 >= SpecCategoryModel.GuestMax) || (0 >= SpecCategoryModel.Commodity_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建商品规格分类记录
            int ID = 0;
            BLL_SpecificationCategory CommodityBLL = new BLL_SpecificationCategory();
            SpecCategoryModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (CommodityBLL.InsertSpecificationCategory(SpecCategoryModel,out ID))
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

            //删除商品规格分类记录
            BLL_SpecificationCategory SpecificationCategoryBLL = new BLL_SpecificationCategory();
            if (SpecificationCategoryBLL.DeleteSingleSpecificationCategory(ID))
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

            SpecificationCategory result = null;

            //查询商品规格分类记录
            BLL_SpecificationCategory SpecificationCategoryBLL = new BLL_SpecificationCategory();
            result = SpecificationCategoryBLL.SelectSingleSpecificationCategory(ID);

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
        public ActionResult Edit(SpecificationCategory SpecCategoryModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(SpecCategoryModel.Title)) || (String.IsNullOrEmpty(SpecCategoryModel.ImagePath)) || (0 >= FloatPrice) || (0 >= SpecCategoryModel.GuestMin) || (0 >= SpecCategoryModel.GuestMax) || (0 >= SpecCategoryModel.Commodity_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改商品规格分类记录
            BLL_SpecificationCategory SpecificationCategoryBLL = new BLL_SpecificationCategory();
            SpecCategoryModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (SpecificationCategoryBLL.UpdateSingleSpecificationCategory(SpecCategoryModel.ID, SpecCategoryModel))
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