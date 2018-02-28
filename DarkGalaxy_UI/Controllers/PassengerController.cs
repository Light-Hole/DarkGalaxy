using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    [Login]
    public class PassengerController : Controller
    {
        public ActionResult Index()
        {
            List<Passenger> result = null;

            //查询旅客
            int intUserID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            BLL_Passenger bllPassenger = new BLL_Passenger();
            result = bllPassenger.SelectPassenger_UserAccount(intUserID);

            //处理返回值
            if (null != result)
            {
                ViewData.Model = result;
            }
            else { }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Passenger passengerModel)
        {
            DGResultMessage result = new DGResultMessage();

            //新建商品记录
            int intID = 0;
            BLL_Passenger bllPassenger = new BLL_Passenger();
            passengerModel.UserAccount_ID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            if (bllPassenger.InsertPassenger(passengerModel, out intID))
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
        public ActionResult Delete(int id)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (0 >= id)
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //删除旅客记录
            BLL_Passenger bllContacts = new BLL_Passenger();
            if (bllContacts.DeleteSinglePassenger(id))
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

        public ActionResult Edit(int id)
        {
            Passenger result = null;

            //查询旅客记录
            BLL_Passenger bllPassenger = new BLL_Passenger();
            result = bllPassenger.SelectSinglePassenger(id);

            //处理返回值
            ViewData.Model = result;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Passenger passengerModel)
        {
            DGResultMessage result = new DGResultMessage();

            //修改旅客记录
            BLL_Passenger bllPassenger = new BLL_Passenger();
            if (bllPassenger.UpdateSinglePassenger(passengerModel.ID, passengerModel))
            {
                result.Code = ResultCodeType.Succeed;
                result.Message = "编辑成功";
            }
            else
            {
                result.Code = ResultCodeType.NoFound;
                result.Message = "编辑失败";
            }

            return Json(result);
        }

        public ActionResult Choose()
        {
            List<Passenger> result = new List<Passenger>();

            //查询旅客记录
            int intUserID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            BLL_Passenger bllPassenger = new BLL_Passenger();
            result = bllPassenger.SelectPassenger_UserAccount(intUserID);

            //处理返回值
            if ((null != result) && (0 != result.Count))
            {
                ViewData.Model = result;
            }
            else { }

            return View();
        }
    }
}