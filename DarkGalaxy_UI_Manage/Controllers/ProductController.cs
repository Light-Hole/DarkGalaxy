using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using DarkGalaxy_UI_Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            //查询全部分类
            BLL_Category CategoryBLL = new BLL_Category();
            ViewData.Model = CategoryBLL.SelectCategory();

            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string Search = null, int ACID = 0)
        {
            DGResultData<ProductViewModel> result = new DGResultData<ProductViewModel>();

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
            List<Product> ProductList = null;
            BLL_Product ProductBLL = new BLL_Product();
            BLL_Category CategoryBLL = new BLL_Category();
            if ((String.IsNullOrEmpty(Search)) && (0 == ACID))
            {
                ProductList = ProductBLL.SelectProduct(Page, PageSize, out Total);
                result.Total = Total;
            }
            else if ((!String.IsNullOrEmpty(Search)) && (0 == ACID))
            {
                ProductList = ProductBLL.SelectProductLike(Page, PageSize, out Total, Search);
                result.Total = Total;
            }
            else if ((String.IsNullOrEmpty(Search)) && (0 < ACID))
            {
                List<Category> CategoryList = CategoryBLL.SelectDescendantCategory(ACID);
                if(null != CategoryList)
                {
                    var CategoryID =
                    from Categorys
                    in CategoryList
                    select Categorys.ID;
                    ProductList = ProductBLL.SelectProduct_Category(Page, PageSize, out Total, CategoryID.ToArray());
                }
                else { }
                result.Total = Total;
            }
            else { }

            //处理返回值
            if ((null == ProductList) || (0 == ProductList.Count))
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "未找到数据";
            }
            else
            {
                //设置ViewModel
                List<ProductViewModel> ProductViewModels = new List<ProductViewModel>();
                foreach (var temp in ProductList)
                {
                    ProductViewModel ViewModel = new ProductViewModel()
                    {
                        ProductModel = temp,
                        CategoryModel = CategoryBLL.SelectSingleCategory(temp.Category_ID)
                    };
                    ProductViewModels.Add(ViewModel);
                }
                result.Datas = ProductViewModels;

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
            //查询全部分类
            BLL_Category CategoryBLL = new BLL_Category();
            ViewData.Model = CategoryBLL.SelectCategory();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product ProductModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(ProductModel.Title)) || (0 >= ProductModel.Category_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建产品记录
            int ID = 0;
            BLL_Product ProductBLL = new BLL_Product();
            if (ProductBLL.InsertProduct(ProductModel,out ID))
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

            //删除产品记录
            BLL_Product ProductBLL = new BLL_Product();
            if (ProductBLL.DeleteSingleProduct(ID))
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

            //批量删除产品记录
            BLL_Product ProductBLL = new BLL_Product();
            if (ProductBLL.DeleteProduct(BatchIDArray))
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

            ProductViewModel result = new ProductViewModel();

            //查询产品记录
            BLL_Product ProductBLL = new BLL_Product();
            result.ProductModel = ProductBLL.SelectSingleProduct(ID);

            //查询产品分类、全部分类
            if (null != result.ProductModel)
            {
                //查询产品所属分类、全部分类
                BLL_Category CategoryBLL = new BLL_Category();
                result.CategoryModel = CategoryBLL.SelectSingleCategory(result.ProductModel.Category_ID);
                result.CategoryList = CategoryBLL.SelectCategory();

                //设置ViewModel
                ViewData.Model = result;
                return View();
            }
            else
            {
                return View("~/Views/Common/DataNoFound.cshtml");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product ProductModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(ProductModel.Title)) || (0 >= ProductModel.Category_ID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改产品记录
            BLL_Product ProductBLL = new BLL_Product();
            if (ProductBLL.UpdateSingleProduct(ProductModel.ID, ProductModel))
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