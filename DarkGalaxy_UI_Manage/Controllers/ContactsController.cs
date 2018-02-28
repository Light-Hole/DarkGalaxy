using DarkGalaxy_BLL;
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
    public class ContactsController : Controller
    {
        public ActionResult Index(int UID)
        {
            //处理错误参数
            if (0 >= UID)
            {
                return View("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            List<ContactsViewModel> result = new List<ContactsViewModel>();

            //查询联系人、地区、设置ViewModel
            BLL_Region RegionBLL = new BLL_Region();
            BLL_Contacts ContactsBLL = new BLL_Contacts();
            List<Contacts> ContactsList = ContactsBLL.SelectContacts_UserAccount(UID);
            if (null != ContactsList)
            {
                //设置ViewModel集合
                foreach (var temp in ContactsList)
                {
                    //设置ViewModel
                    ContactsViewModel ViewModel = new ContactsViewModel()
                    {
                        ContactsModel = temp,
                        RegionText = RegionBLL.SelectRegionText(temp.RegionsID)
                    };
                    result.Add(ViewModel);
                }
            }
            else { }

            //处理返回值
            if ((null != result) && (0 != result.Count))
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