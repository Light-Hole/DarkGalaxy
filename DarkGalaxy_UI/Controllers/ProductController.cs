using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult IndexJson(int page, int pageSize)
        {
            DGResultData<Product> result = new DGResultData<Product>();

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

            //分页查询产品数据
            int intTotal = 0;
            BLL_Product bllProduct = new BLL_Product();
            result.Datas = bllProduct.SelectProduct(page, pageSize, out intTotal);
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
            //查询产品记录
            BLL_Product bllProduct = new BLL_Product();
            ViewData.Model = bllProduct.SelectSingleProduct(id);

            return View();
        }
    }
}