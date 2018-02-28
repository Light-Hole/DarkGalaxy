using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using DarkGalaxy_UI_Manage.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class UserAccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string Search = null)
        {
            DGResultData<UserAccount> result = new DGResultData<UserAccount>();

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
            BLL_UserAccount UserAccountBLL = new BLL_UserAccount();
            if (String.IsNullOrEmpty(Search))
            {
                result.Datas = UserAccountBLL.SelectUserAccount(Page, PageSize, out Total);
                result.Total = Total;
            }
            else
            {
                result.Datas = UserAccountBLL.SelectUserAccountLike(Page, PageSize, out Total, Search);
                result.Total = Total;
            }

            //处理返回值
            if ((null == result.Data) && (null == result.Datas))
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
    }
}