using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class AdminAccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string Search = null)
        {
            DGResultData<AdminAccount> result = new DGResultData<AdminAccount>();

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
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            if (String.IsNullOrEmpty(Search))
            {
                result.Datas = AdminAccountBLL.SelectAdminAccount(Page, PageSize, out Total);
                result.Total = Total;
            }
            else
            {
                result.Datas = AdminAccountBLL.SelectAdminAccountLike(Page, PageSize, out Total, Search);
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdminAccount adminAccountModel, AdminInformation adminInfoModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(adminAccountModel.UserName) || String.IsNullOrEmpty(adminAccountModel.Password))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建管理员帐户、与管理员信息记录
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            BLL_AdminInformation AdminInformationBLL = new BLL_AdminInformation();
            if (null == AdminAccountBLL.SelectSingleAdminAccount(adminAccountModel.UserName))//判断用户是否已存在
            {
                int ID = 0;
                if (AdminAccountBLL.InsertAdminAccount(adminAccountModel, out ID))
                {
                    adminInfoModel.AdminAccount_ID = ID;
                    if (AdminInformationBLL.InsertAdminInformation(adminInfoModel, out ID))
                    {
                        result.Code = ResultCodeType.Succeed;
                        result.Message = "新建成功";
                    }
                    else
                    {
                        result.Code = ResultCodeType.NoFound;
                        result.Message = "新建失败";
                    }
                }
                else
                {
                    result.Code = ResultCodeType.NoFound;
                    result.Message = "新建失败";
                }
            }
            else
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "用户名已存在";
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

            //删除管理员帐户记录
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            if (AdminAccountBLL.DeleteSingleAdminAccount(ID))
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

            //批量删除管理员帐户记录
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            if (AdminAccountBLL.DeleteAdminAccount(BatchIDArray))
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

            AdminAccount result = null;

            //查询管理员帐户记录
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            result = AdminAccountBLL.SelectSingleAdminAccount(ID);

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
        public ActionResult Edit(AdminAccount adminAccountModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(adminAccountModel.UserName) || String.IsNullOrEmpty(adminAccountModel.Password))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改管理员帐户记录
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            if (AdminAccountBLL.UpdateSingleAdminAccount(adminAccountModel.ID, adminAccountModel))
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