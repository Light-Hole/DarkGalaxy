using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI.Controllers
{
    [Login]
    public class RegionController : Controller
    {
        public ActionResult Index(int id = 1, string title = null, string titles = null, string values = null)
        {
            List<Region> result = null;

            //查询子级地区记录
            BLL_Region bllRegion = new BLL_Region();
            result = bllRegion.SelectChildRegion(id);

            //设置地区值与文本
            if ((1 != id) && String.IsNullOrEmpty(titles) && String.IsNullOrEmpty(values) && (!String.IsNullOrEmpty(title)))
            {
                ViewData["titles"] = title;
                ViewData["values"] = id.ToString();
            }
            else
            {
                ViewData["titles"] = titles;
                ViewData["values"] = values;
            }

            //处理返回值
            ViewData.Model = result;

            return View();
        }
    }
}