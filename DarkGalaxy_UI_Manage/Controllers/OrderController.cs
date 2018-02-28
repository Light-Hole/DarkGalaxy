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
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson(int Page, int PageSize, string OrderNumber = null, int OrderStatus = -1, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            DGResultData<Order> result = new DGResultData<Order>();

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
            BLL_Order OrderBLL = new BLL_Order();
            if ((String.IsNullOrEmpty(OrderNumber)) && (-1 == OrderStatus) && (null == StartDate) && (null == EndDate))
            {
                result.Datas = OrderBLL.SelectOrderManage(Page, PageSize, out Total);
                result.Total = Total;
            }
            else if (!String.IsNullOrEmpty(OrderNumber))
            {
                result.Datas = OrderBLL.SelectOrder(Page, PageSize, out Total, OrderNumber);
                result.Total = Total;
            }
            else
            {
                //多条件查询
                if (-1 == OrderStatus)
                {
                    result.Datas = OrderBLL.SelectOrder(Page, PageSize, out Total, null, StartDate, EndDate);
                    result.Total = Total;
                }
                else
                {
                    OrderStatusType OrderStatusTypes = (OrderStatusType)Enum.ToObject(typeof(OrderStatusType), OrderStatus);
                    result.Datas = OrderBLL.SelectOrder(Page, PageSize, out Total, OrderStatusTypes, StartDate, EndDate);
                    result.Total = Total;
                }
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
            List<OrderDetailViewModel> OrderDetailViewModelList = new List<OrderDetailViewModel>();
            if (null != OrderModel)
            {
                //查询订单旅客信息记录
                BLL_OrderPassenger bllOrderPassenger = new BLL_OrderPassenger();
                result.OrderPassengerList = bllOrderPassenger.SelectOrderPassenger_Order(OrderModel.ID);

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
    }
}