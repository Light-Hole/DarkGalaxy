using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson()
        {
            DGResultData<Category> result = new DGResultData<Category>();

            //查询全部分类记录
            BLL_Category CategoryBLL = new BLL_Category();
            result.Datas = CategoryBLL.SelectCategory();

            //处理返回值
            if ((null == result.Datas) || (0 >= result.Datas.Count))
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "未找到数据";
            }
            else
            {
                result.Total = result.Datas.Count;
                result.Code = ResultCodeType.Succeed;
                result.Message = "结果正确";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexPartial(int ID = 0)
        {
            //处理错误参数
            if (0 > ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<Category> result = null;

            //查询分类
            if (0 == ID)
            {
                //查询顶级分类
                BLL_Category CategoryBLL = new BLL_Category();
                result = CategoryBLL.SelectTopCategory();
            }
            else
            {
                //查询子级分类
                BLL_Category CategoryBLL = new BLL_Category();
                result = CategoryBLL.SelectChildCategory(ID);
            }

            //处理返回值
            if (null != result)
            {
                ViewData.Model = result;
            }
            else { }

            return View();
        }

        public ActionResult Create(int PID)
        {
            //处理错误参数
            if (0 > PID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            //设置父级分类ID
            ViewData["PID"] = PID;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int PID, Category CategoryModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((String.IsNullOrEmpty(CategoryModel.Title)) || (0 > PID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建分类记录
            int ID = 0;
            BLL_Category CategoryBLL = new BLL_Category();
            CategoryModel.ParentID = PID;
            if (CategoryBLL.InsertCategory(CategoryModel, out ID))
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

            //删除分类记录
            BLL_Category CategoryBLL = new BLL_Category();
            if (CategoryBLL.DeleteSingleCategory(ID))
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

            Category result = null;

            //查询分类记录
            BLL_Category CategoryBLL = new BLL_Category();
            result = CategoryBLL.SelectSingleCategory(ID);

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
        public ActionResult Edit(Category CategoryModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(CategoryModel.Title))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改分类记录
            BLL_Category CategoryBLL = new BLL_Category();
            if (CategoryBLL.UpdateSingleCategory(CategoryModel.ID, CategoryModel))
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