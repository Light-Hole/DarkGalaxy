using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
using DarkGalaxy_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    [Login]
    public class CommodityController : Controller
    {
        public ActionResult IndexJson(int page, int pageSize, string search = null, DateTime? departureDate = null, DateTime? regressionDate = null)
        {
            DGResultData<Commodity> result = new DGResultData<Commodity>();

            //处理错误参数
            if ((0 >= page) || (0 >= pageSize))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "错误的请求";
                result.PageIndex = page;
                result.PageSize = pageSize;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else { }

            //分页查询商品数据
            int intTotal = 0;
            BLL_Commodity bllCommodity = new BLL_Commodity();
            result.Datas = bllCommodity.SelectCommodityValidLike(page, pageSize, out intTotal, search, departureDate, regressionDate);
            result.Total = intTotal;

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
            result.PageIndex = page;
            result.PageSize = pageSize;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            CommodityViewModel result = new CommodityViewModel();

            //查询商品记录，设置ViewModel
            BLL_Commodity bllCommodity = new BLL_Commodity();
            Commodity modCommodity = bllCommodity.SelectSingleCommodity(id);
            if (null != modCommodity)
            {
                result.CommodityModel = modCommodity;

                //查询规格分类记录
                BLL_SpecificationCategory bllSpecCategory = new BLL_SpecificationCategory();
                result.SpecCategoryList = bllSpecCategory.SelectSpecCategory_Commodity(modCommodity.ID);

                //查询评论记录
                BLL_Evaluate bllEvaluate = new BLL_Evaluate();
                result.EvaluateList = bllEvaluate.SelectEvaluate_Commodity(modCommodity.ID);

                //设置商品详细信息
                result.CommodityDetailsList = Helper_Serializer_Json.JsonDeserializer<List<Model_Commodity_Details>>(modCommodity.Details);
            }
            else { }

            //处理返回值
            ViewData.Model = result;

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Specification(int id)
        {
            SpecCategoryViewModel result = new SpecCategoryViewModel();

            //查询商品规格记录，设置ViewModel
            BLL_SpecificationCategory bllSpecCategor = new BLL_SpecificationCategory();
            BLL_Specification bllSpecification = new BLL_Specification();
            result.SpecCategoryModel = bllSpecCategor.SelectSingleSpecificationCategory(id);
            result.SpecificationList = bllSpecification.SelectSpecification_SpecificationCategory(id);

            //处理返回值
            ViewData.Model = result;

            return View();
        }
    }
}