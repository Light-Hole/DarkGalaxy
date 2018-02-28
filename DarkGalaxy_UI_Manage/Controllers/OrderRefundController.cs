using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using DarkGalaxy_UI_Manage.Models;
using DarkGalaxy_WeChat;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class OrderRefundController : Controller
    {
        public ActionResult Details(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            OrderViewModel result = new OrderViewModel();

            //查询订单记录
            BLL_Order OrderBLL = new BLL_Order();
            Order OrderModel = OrderBLL.SelectSingleOrder(ID);

            //设置ViewModel
            List<Region> RegionList = new List<Region>();
            List<OrderDetailViewModel> OrderDetailViewModelList = new List<OrderDetailViewModel>();
            if (null != OrderModel)
            {
                //查询订单详情列表，设置订单详情ViewModel
                BLL_OrderDetail OrderDetaiBLL = new BLL_OrderDetail();
                List<OrderDetail> OrderDetailList = OrderDetaiBLL.SelectOrderDetail_Order(OrderModel.ID);
                if (null != OrderDetailList)
                {
                    BLL_Commodity CommodityBLL = new BLL_Commodity();
                    BLL_SpecificationCategory SpecificationCategoryBLL = new BLL_SpecificationCategory();
                    BLL_Specification SpecificationBLL = new BLL_Specification();

                    //设置订单详情列表ViewModel
                    foreach (var temp in OrderDetailList)
                    {
                        OrderDetailViewModel DetailViewModel = new OrderDetailViewModel();
                        DetailViewModel.OrderDetailModel = temp;
                        DetailViewModel.CommodityModel = CommodityBLL.SelectSingleCommodityAll(temp.Commodity_ID);//查询商品记录
                        DetailViewModel.SpecCategoryModel = SpecificationCategoryBLL.SelectSingleSpecificationCategoryAll(temp.SpecificationCategory_ID);//查询规格分类
                        DetailViewModel.SpecificationModel = SpecificationBLL.SelectSingleSpecificationAll(temp.Specification_ID);//查询商品规格
                        if ((null != DetailViewModel.CommodityModel) && (null != DetailViewModel.SpecCategoryModel) && (null != DetailViewModel.SpecificationModel))
                        {
                            OrderDetailViewModelList.Add(DetailViewModel);
                        }
                        else
                        {
                            return View("~/Views/Common/DataError.cshtml");
                        }
                    }
                }
                else
                {
                    return View("~/Views/Common/DataError.cshtml");
                }
            }
            else { }

            //处理返回值
            if (null != OrderModel)
            {
                BLL_Region RegionBLL = new BLL_Region();

                //设置ViewModel
                result.OrderModel = OrderModel;
                result.RegionText = RegionBLL.SelectRegionText(OrderModel.RegionsID);
                result.OrderDetailList = OrderDetailViewModelList;
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

            //修改订单状态
            BLL_Order OrderBLL = new BLL_Order();
            Order OrderModel = OrderBLL.SelectSingleOrder(ID);
            if (null != OrderModel)
            {
                //设置订单状态
                if (Audit)
                {
                    //发送微信退款申请
                    string NouceStr = Guid.NewGuid().ToString().Replace("-", "");
                    string RefundOrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + "62" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
                    Refund RefundModel = new Refund(WeChat_Basicinfo.AppID, WeChat_Basicinfo.PayMchID, NouceStr, PayOrderNumberType.WeChat, OrderModel.WeChatOrderNumber, RefundOrderNumber, OrderModel.ActualPrice, OrderModel.ActualPrice);
                    WeChat_Pay wecPay = new WeChat_Pay();
                    var RefundResult = wecPay.ApplyRefund(RefundModel);
                    if ((null != RefundResult) && (0 == String.Compare(RefundResult.result_code, "SUCCESS", true)))
                    {
                        result.Code = ResultCodeType.Succeed;
                        result.Message = "操作成功，等待微信退款";
                        return Json(result);
                    }
                    else
                    {
                        result.Code = ResultCodeType.NoFound;
                        result.Message = "微信退款失败";
                        return Json(result);
                    }
                }
                else
                {
                    //拒绝退款状态
                    OrderModel.Status = OrderStatusType.RefundReject;
                }

                //设置修改人ID
                AdminAccount AdminAccountModel = (AdminAccount)Session["AdminAccount"];
                OrderModel.AdminAccount_ID = AdminAccountModel.ID;

                //修改订单状态
                if (OrderBLL.UpdateSingleOrder(OrderModel.ID, OrderModel))
                {
                    result.Code = ResultCodeType.Succeed;
                    result.Message = "操作成功";
                }
                else
                {
                    result.Code = ResultCodeType.NoFound;
                    result.Message = "操作失败";
                }
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "订单未找到";
            }

            return Json(result);
        }
    }
}