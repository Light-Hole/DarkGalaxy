using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class StatisticsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}