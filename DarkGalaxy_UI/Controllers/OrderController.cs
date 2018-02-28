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
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int page, int pageSize, OrderStatusType[] statues)
        {
            DGResultData<OrderViewModel> result = new DGResultData<OrderViewModel>();

            //处理错误参数
            if ((0 >= page) || (0 >= pageSize) || (0 >= statues.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "错误的请求";
                result.PageIndex = page;
                result.PageSize = pageSize;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else { }

            //查询订单记录，设置ViewModel
            int intTotal = 0;
            int intUserID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            BLL_Order bllOrder = new BLL_Order();
            List<OrderViewModel> lisOrderViewModel = new List<OrderViewModel>();
            List<Order> lisOrder = bllOrder.SelectOrder_UserAccount(page, pageSize, out intTotal, statues, intUserID);//查询订单记录
            if (null != lisOrder)
            {
                //查询订单详情记录，设置ViewModel
                BLL_OrderDetail bllOrderDetail = new BLL_OrderDetail();
                foreach (var tempOrder in lisOrder)
                {
                    OrderViewModel vmodOrder = new OrderViewModel();
                    List<OrderDetailViewModel> lisOrderDetailViewModel = new List<OrderDetailViewModel>();

                    //查询订单详情记录
                    List<OrderDetail> lisOrderDetail = bllOrderDetail.SelectOrderDetail_Order(tempOrder.ID);

                    //查询订单详情ViewModel数据
                    if (null != lisOrderDetail)
                    {
                        BLL_Commodity bllCommodity = new BLL_Commodity();
                        BLL_SpecificationCategory bllSpecCategory = new BLL_SpecificationCategory();
                        BLL_Specification bllSpecification = new BLL_Specification();
                        foreach (var tempOrderDetail in lisOrderDetail)
                        {
                            OrderDetailViewModel vmodOrderDetailViewModel = new OrderDetailViewModel();
                            vmodOrderDetailViewModel.OrderDetailModel = tempOrderDetail;

                            //查询商品记录
                            vmodOrderDetailViewModel.CommodityModel = bllCommodity.SelectSingleCommodity(tempOrderDetail.Commodity_ID);

                            //查询商品规格分类记录
                            vmodOrderDetailViewModel.SpecCategoryModel = bllSpecCategory.SelectSpecCategory_Commodity(tempOrderDetail.Commodity_ID)[0];

                            //查询商品规格记录
                            vmodOrderDetailViewModel.SpecificationModel = bllSpecification.SelectSpecification_Commodity(tempOrderDetail.Commodity_ID)[0];

                            lisOrderDetailViewModel.Add(vmodOrderDetailViewModel);
                        }
                    }
                    else { }

                    //查询联系人所在地区文本
                    BLL_Region bllRegion = new BLL_Region();
                    vmodOrder.RegionText = bllRegion.SelectRegionText(tempOrder.RegionsID);

                    //设置ViewModel
                    vmodOrder.OrderModel = tempOrder;
                    vmodOrder.OrderDetailList = lisOrderDetailViewModel;
                    lisOrderViewModel.Add(vmodOrder);
                }

                //设置ViewModel集合
                result.Datas = lisOrderViewModel;
                result.Total = intTotal;
            }
            else { }

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
            OrderViewModel result = new OrderViewModel();

            //查询订单详情数据
            BLL_Order bllOrder = new BLL_Order();
            Order modOrder = bllOrder.SelectSingleOrder(id);//查询订单记录
            if (null != modOrder)
            {
                List<OrderDetailViewModel> lisOrderDetailViewModel = new List<OrderDetailViewModel>();

                //查询订单详情记录
                BLL_OrderDetail bllOrderDetail = new BLL_OrderDetail();
                List<OrderDetail> lisOrderDetail = bllOrderDetail.SelectOrderDetail_Order(modOrder.ID);

                //查询订单详情ViewModel数据
                if (null != lisOrderDetail)
                {
                    BLL_Commodity bllCommodity = new BLL_Commodity();
                    BLL_SpecificationCategory bllSpecCategory = new BLL_SpecificationCategory();
                    BLL_Specification bllSpecification = new BLL_Specification();
                    foreach (var tempOrderDetail in lisOrderDetail)
                    {
                        OrderDetailViewModel vmodOrderDetailViewModel = new OrderDetailViewModel();
                        vmodOrderDetailViewModel.OrderDetailModel = tempOrderDetail;

                        //查询商品记录
                        vmodOrderDetailViewModel.CommodityModel = bllCommodity.SelectSingleCommodity(tempOrderDetail.Commodity_ID);

                        //查询商品规格分类记录
                        vmodOrderDetailViewModel.SpecCategoryModel = bllSpecCategory.SelectSpecCategory_Commodity(tempOrderDetail.Commodity_ID)[0];

                        //查询商品规格记录
                        vmodOrderDetailViewModel.SpecificationModel = bllSpecification.SelectSpecification_Commodity(tempOrderDetail.Commodity_ID)[0];

                        //设置订单详情ViewModel集合
                        lisOrderDetailViewModel.Add(vmodOrderDetailViewModel);
                    }
                }
                else { }

                //设置ViewModel
                BLL_Region bllRegion = new BLL_Region();
                result.OrderModel = modOrder;
                result.OrderDetailList = lisOrderDetailViewModel;
                result.RegionText = bllRegion.SelectRegionText(modOrder.RegionsID);//查询联系人所在地区文本
                ViewData.Model = result;
            }
            else { }

            return View();
        }

        public ActionResult Affirm(DenominateViewModel[] denominates)
        {
            List<SpecificationViewModel> result = new List<SpecificationViewModel>();

            //查询规格记录，设置ViewModel
            BLL_Commodity bllCommodity = new BLL_Commodity();
            BLL_Specification bllSpecification = new BLL_Specification();
            foreach (var temp in denominates)
            {
                SpecificationViewModel vmodSpecification = new SpecificationViewModel();

                //查询规格记录
                Specification modSpecification = bllSpecification.SelectSingleSpecification(temp.SpecID);

                //查询商品记录
                vmodSpecification.CommodityModel = bllCommodity.SelectSingleCommodity(modSpecification.Commodity_ID);

                //设置ViewModel
                vmodSpecification.Number = temp.SpecNumber;
                vmodSpecification.SpecificationModel = modSpecification;

                //设置ViewModel集合
                result.Add(vmodSpecification);
            }

            //处理返回值
            ViewData.Model = result;

            return View();
        }

        [HttpPost]
        public ActionResult Affirm(Order orderModel,OrderPassenger[] orderPassengers, DenominateViewModel[] denominates)
        {
            DGResultData<int> result = new DGResultData<int>();

            //处理错误参数
            if ((null == denominates) || (0 == denominates.Length) || (0 == orderPassengers.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //设置订单详情集合
            int intTotalPrice = 0;
            int intTotalQuantity = 0;
            BLL_OrderDetail bllOrderDetail = new BLL_OrderDetail();
            BLL_Specification bllSpecification = new BLL_Specification();
            List<OrderDetail> lisOrderDetail = new List<OrderDetail>();
            foreach (var temp in denominates)
            {
                OrderDetail modOrderDetail = new OrderDetail();

                //查询商品规格数据、设置订单详情数据
                Specification modSpecification = bllSpecification.SelectSingleSpecification(temp.SpecID);
                modOrderDetail.Price = modSpecification.Price;
                modOrderDetail.Quantity = temp.SpecNumber;
                modOrderDetail.SpecificationCategory_ID = modSpecification.SpecificationCategory_ID;
                modOrderDetail.Specification_ID = modSpecification.ID;
                modOrderDetail.Commodity_ID = modSpecification.Commodity_ID;
                modOrderDetail.TotalPrice = modSpecification.Price * temp.SpecNumber;
                lisOrderDetail.Add(modOrderDetail);

                //计算订单价格、订单商品数量
                intTotalPrice += temp.SpecNumber * modSpecification.Price;
                intTotalQuantity += temp.SpecNumber;
            }

            //新建订单记录
            int intOrderID = 0;
            BLL_Order bllOrder = new BLL_Order();
            orderModel.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18);
            orderModel.TotalPrice = intTotalPrice;
            orderModel.ActualPrice = intTotalPrice;
            orderModel.TotalQuantity = intTotalQuantity;
            orderModel.UserAccount_ID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            if (bllOrder.InsertOrder(orderModel, out intOrderID))
            {
                //新建订单详情记录
                foreach (var temp in lisOrderDetail)
                {
                    int intTempID = 0;
                    temp.Order_ID = intOrderID;
                    bllOrderDetail.InsertOrderDetail(temp, out intTempID);
                }

                //新建订单旅客记录
                int intOrderPassengerID = 0;
                BLL_OrderPassenger bllOrderPassenger = new BLL_OrderPassenger();
                foreach (var temp in orderPassengers)
                {
                    temp.Order_ID = intOrderID;
                    bllOrderPassenger.InsertOrderPassenger(temp, out intOrderPassengerID);
                }

                result.Data = intOrderID;
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

        public ActionResult Payment(int id)
        {
            //查询订单记录
            BLL_Order bllOrder = new BLL_Order();
            Order modOrder = null;
            modOrder = bllOrder.SelectSingleOrder(id);
            if (null != modOrder)
            {
                ViewData["ActualPrice"] = modOrder.ActualPrice / 100.00;
            }
            else { }

            return View();
        }

        [HttpPost]
        public ActionResult Close(int id)
        {
            DGResultMessage result = new DGResultMessage();

            //修改订单状态
            BLL_Order bllOrder = new BLL_Order();
            if (bllOrder.UpdateOrderStatus(id, OrderStatusType.Close))
            {
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

        [HttpPost]
        public ActionResult Refund(int id)
        {
            DGResultMessage result = new DGResultMessage();

            //修改订单状态
            BLL_Order bllOrder = new BLL_Order();
            if (bllOrder.UpdateOrderStatus(id, OrderStatusType.Refund))
            {
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