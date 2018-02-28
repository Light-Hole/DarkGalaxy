using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
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
    public class CommodityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string Search = null)
        {
            DGResultData<Commodity> result = new DGResultData<Commodity>();

            //处理错误参数
            if ((0 >= Page) || (0 >= PageSize))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "错误的请求";
                result.PageIndex = Page;
                result.PageSize = PageSize;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else { }

            //分页查询数据
            int Total = 0;
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            if (String.IsNullOrEmpty(Search))
            {
                result.Datas = CommodityBLL.SelectCommodity(Page, PageSize, out Total);
                result.Total = Total;
            }
            else
            {
                result.Datas = CommodityBLL.SelectCommodityLike(Page, PageSize, out Total, Search);
                result.Total = Total;
            }

            //处理返回值
            if ((null == result.Datas) || (0 >= result.Datas.Count))
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "未找到数据";
            }
            else
            {
                //设置返回消息
                result.Code = ResultCodeType.Succeed;
                result.Message = "结果正确";
            }
            result.PageIndex = Page;
            result.PageSize = PageSize;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Commodity CommodityModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(CommodityModel.Title)) || (0 >= FloatPrice) || (String.IsNullOrEmpty(CommodityModel.DepartureSite)) || (String.IsNullOrEmpty(CommodityModel.RegressionSite)))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建商品记录
            int ID = 0;
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            CommodityModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (CommodityBLL.InsertCommodity(CommodityModel, out ID))
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

        [HttpPost]
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

            //删除商品记录
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            if (CommodityBLL.DeleteSingleCommodity(ID))
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

        [HttpPost]
        public ActionResult BatchDelete(int[] BatchIDArray)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((null == BatchIDArray) || (0 == BatchIDArray.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //批量删除商品记录
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            if (CommodityBLL.DeleteCommodity(BatchIDArray))
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

            CommodityViewModel result = new CommodityViewModel();

            //查询商品记录
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            Commodity modCommodity = CommodityBLL.SelectSingleCommodity(ID);
            if (null != modCommodity)
            {
                result.CommodityModel = modCommodity;
                result.CommodityDetailsList = Helper_Serializer_Json.JsonDeserializer<List<Model_Commodity_Details>>(modCommodity.Details);
            }
            else { }

            //处理返回值
            if (null != result.CommodityModel)
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
        public ActionResult Edit(Commodity CommodityModel, float FloatPrice)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(CommodityModel.Title)) || (0 >= FloatPrice) || (String.IsNullOrEmpty(CommodityModel.DepartureSite)) || (String.IsNullOrEmpty(CommodityModel.RegressionSite)))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改商品记录
            BLL_Commodity CommodityBLL = new BLL_Commodity();
            CommodityModel.Price = Convert.ToInt32(FloatPrice * 100);
            if (CommodityBLL.UpdateSingleCommodity(CommodityModel.ID, CommodityModel))
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

        public ActionResult DetailsSpecification(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<SpecCategoryViewModel> result = new List<SpecCategoryViewModel>();

            //查询全部商品规格分类
            ViewData["CommodityID"] = ID;
            BLL_Specification SpecificationBLL = new BLL_Specification();
            BLL_SpecificationCategory SpecificationCategoryBLL = new BLL_SpecificationCategory();
            List<SpecificationCategory> SpecificationCategoryList = SpecificationCategoryBLL.SelectSpecCategory_Commodity(ID);
            if (null != SpecificationCategoryList)
            {
                foreach (var temp in SpecificationCategoryList)
                {
                    SpecCategoryViewModel Model = new SpecCategoryViewModel();
                    Model.SpecCategoryModel = temp;
                    Model.SpecificationList = SpecificationBLL.SelectSpecification_SpecificationCategory(temp.ID);
                    result.Add(Model);
                }
            }
            else { }

            //处理返回值
            if ((null != result) && (0 != result.Count))
            {
                ViewData.Model = result;
            }
            else { }

            return View();
        }
    }
}