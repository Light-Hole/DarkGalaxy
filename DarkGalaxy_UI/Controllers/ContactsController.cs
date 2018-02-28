using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
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
    public class ContactsController : Controller
    {
        public ActionResult Index()
        {
            List<ContactsViewModel> result = new List<ContactsViewModel>();

            //查询联系人、联系人所在地区文本
            int intUserID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            BLL_Region bllRegion = new BLL_Region();
            BLL_Contacts bllContacts = new BLL_Contacts();
            List<Contacts> lisContacts = bllContacts.SelectContacts_UserAccount(intUserID);
            if (null != lisContacts)
            {
                //设置ViewModel集合
                foreach (var temp in lisContacts)
                {
                    //设置ViewModel
                    ContactsViewModel vmodContacts = new ContactsViewModel()
                    {
                        ContactsModel = temp,
                        RegionText = bllRegion.SelectRegionText(temp.RegionsID)//查询联系人所在地区文本
                    };
                    result.Add(vmodContacts);
                }
            }
            else { }

            //处理返回值
            if ((null != result) && (0 != result.Count))
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
        public ActionResult Create(Contacts contactsModel)
        {
            DGResultMessage result = new DGResultMessage();

            //新建联系人记录
            int intID = 0;
            BLL_Contacts bllContacts = new BLL_Contacts();
            contactsModel.UserAccount_ID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            if (bllContacts.InsertContacts(contactsModel, out intID))
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

            //删除联系人记录
            BLL_Contacts bllContacts = new BLL_Contacts();
            if (bllContacts.DeleteSingleContacts(id))
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
            ContactsViewModel result = new ContactsViewModel();

            //查询联系人记录
            Contacts modContacts = null;
            BLL_Region bllRegion = new BLL_Region();
            BLL_Contacts bllContacts = new BLL_Contacts();
            modContacts = bllContacts.SelectSingleContacts(id);
            if (null != modContacts)
            {
                //设置ViewModel
                result.ContactsModel = modContacts;
                result.RegionText = bllRegion.SelectRegionText(modContacts.RegionsID);
                ViewData.Model = result;
            }
            else { }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Contacts contactsModel)
        {
            DGResultMessage result = new DGResultMessage();

            //修改联系人记录
            BLL_Contacts bllContacts = new BLL_Contacts();
            if (bllContacts.UpdateSingleContacts(contactsModel.ID, contactsModel))
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
            List<ContactsViewModel> result = new List<ContactsViewModel>();

            //查询联系人、联系人所在地区文本
            int intUserID = Convert.ToInt32(Request.Cookies["UserAccount"].Values.Get("ID"));//获取登录状态
            BLL_Region bllRegion = new BLL_Region();
            BLL_Contacts bllContacts = new BLL_Contacts();
            List<Contacts> lisContacts = bllContacts.SelectContacts_UserAccount(intUserID);
            if (null != lisContacts)
            {
                //设置ViewModel集合
                foreach (var temp in lisContacts)
                {
                    //设置ViewModel
                    ContactsViewModel vmodContacts = new ContactsViewModel()
                    {
                        ContactsModel = temp,
                        RegionText = bllRegion.SelectRegionText(temp.RegionsID)//查询联系人所在地区文本
                    };
                    result.Add(vmodContacts);
                }
            }
            else { }

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