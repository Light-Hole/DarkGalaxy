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
    public class OrderEvaluateController : Controller
    {
        public ActionResult Details(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<EvaluateViewModel> result = new List<EvaluateViewModel>();

            //查询评价记录
            BLL_Evaluate OrderEvaluateBLL = new BLL_Evaluate();
            List<Evaluate> OrderEvaluateModelList = OrderEvaluateBLL.SelectEvaluate_Order(ID);
            if (null != OrderEvaluateModelList)
            {
                BLL_Commodity CommodityBLL = new BLL_Commodity();

                //设置ViewModel列表
                foreach (var temp in OrderEvaluateModelList)
                {
                    //设置ViewModel
                    EvaluateViewModel ViewModel = new EvaluateViewModel();
                    ViewModel.EvaluateModel = temp;
                    ViewModel.CommodityModel = CommodityBLL.SelectSingleCommodity(temp.Commodity_ID);
                    if (null != ViewModel.CommodityModel)
                    {
                        result.Add(ViewModel);
                    }
                    else
                    {
                        return View("~/Views/Common/DataError.cshtml");
                    }
                }
            }
            else { }

            //处理返回值
            if (0 != result.Count)
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
        public ActionResult Audit(int ID, bool Audit)
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

            //修改订单评论审核状态
            BLL_Evaluate OrderEvaluateBLL = new BLL_Evaluate();
            AdminAccount AdminAccountModel = (AdminAccount)Session["AdminAccount"];
            if (OrderEvaluateBLL.UpdateEvaluateSetAuditStatus(ID, Audit, AdminAccountModel.ID))
            {
                //判断未审核评价数量，修改订单状态
                Evaluate OrderEvaluateModel = OrderEvaluateBLL.SelectSingleEvaluate(ID);
                if(0 == OrderEvaluateBLL.SelectEvaluateNotAudit(OrderEvaluateModel.Order_ID))
                {
                    //修改订单状态：完成
                    BLL_Order OrderBLL = new BLL_Order();
                    if(OrderBLL.UpdateOrderStatus(OrderEvaluateModel.Order_ID, OrderStatusType.Finish))
                    {
                        result.Code = ResultCodeType.Finish;
                        result.Message = "审核完成";
                        return Json(result);
                    }
                    else
                    {
                        result.Code = ResultCodeType.BadRequest;
                        result.Message = "订单状态错误";
                        return Json(result);
                    }
                }
                else { }

                result.Code = ResultCodeType.Succeed;
                result.Message = "操作成功";
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "操作失败";
            }

            return Json(result);
        }
    }
}