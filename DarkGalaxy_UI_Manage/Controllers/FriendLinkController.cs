using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class FriendLinkController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string Search = null)
        {
            DGResultData<FriendLink> result = new DGResultData<FriendLink>();

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
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            if (String.IsNullOrEmpty(Search))
            {
                result.Datas = FriendLinkBLL.SelectFriendLink(Page, PageSize, out Total);
                result.Total = Total;
            }
            else
            {
                result.Datas = FriendLinkBLL.SelectFriendLinkLike(Page, PageSize, out Total, Search);
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
        public ActionResult Create(FriendLink FriendLinkModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(FriendLinkModel.Title) || String.IsNullOrEmpty(FriendLinkModel.URL))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建友情链接记录
            int ID = 0;
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            if (FriendLinkBLL.InsertFriendLink(FriendLinkModel, out ID))
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

            //删除友情链接记录
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            if (FriendLinkBLL.DeleteSingleFriendLink(ID))
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

            //批量删除友情链接记录
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            if (FriendLinkBLL.DeleteFriendLink(BatchIDArray))
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

            FriendLink result = null;

            //查询友情链接记录
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            result = FriendLinkBLL.SelectSingleFriendLink(ID);

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
        public ActionResult Edit(FriendLink FriendLinkModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(FriendLinkModel.Title) || String.IsNullOrEmpty(FriendLinkModel.URL))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改友情链接记录
            BLL_FriendLink FriendLinkBLL = new BLL_FriendLink();
            if (FriendLinkBLL.UpdateSingleFriendLink(FriendLinkModel.ID, FriendLinkModel))
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