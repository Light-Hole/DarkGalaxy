using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class PassengerController : Controller
    {
        public ActionResult Index(int UID)
        {
            //处理错误参数
            if (0 >= UID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<Passenger> result = null;

            //查询旅客
            BLL_Passenger PassengerBLL = new BLL_Passenger();
            result = PassengerBLL.SelectPassenger_UserAccount(UID);

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
    }
}