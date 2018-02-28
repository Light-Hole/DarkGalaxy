using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPartial(int ID = 0)
        {
            //处理错误参数
            if (0 > ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<Navigation> result = null;

            //查询导航
            if (0 == ID)
            {
                //查询顶级导航
                BLL_Navigation NavigationBLL = new BLL_Navigation();
                result = NavigationBLL.SelectTopNavigation();
            }
            else
            {
                //查询子级导航
                BLL_Navigation NavigationBLL = new BLL_Navigation();
                result = NavigationBLL.SelectChildNavigation(ID);
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

            //设置父级导航ID
            ViewData["PID"] = PID;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int PID, Navigation NavigationModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(NavigationModel.Title) || String.IsNullOrEmpty(NavigationModel.URL) || (0 > PID))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建导航记录
            int ID = 0;
            BLL_Navigation NavigationBLL = new BLL_Navigation();
            NavigationModel.ParentID = PID;
            if (NavigationBLL.InsertNavigation(NavigationModel,out ID))
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

            //删除导航记录
            BLL_Navigation NavigationBLL = new BLL_Navigation();
            if (NavigationBLL.DeleteSingleNavigation(ID))
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

            Navigation result = null;

            //查询导航记录
            BLL_Navigation NavigationBLL = new BLL_Navigation();
            result = NavigationBLL.SelectSingleNavigation(ID);

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
        public ActionResult Edit(Navigation NavigationModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(NavigationModel.Title) || String.IsNullOrEmpty(NavigationModel.URL))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改导航记录
            BLL_Navigation NavigationBLL = new BLL_Navigation();
            if (NavigationBLL.UpdateSingleNavigation(NavigationModel.ID, NavigationModel))
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