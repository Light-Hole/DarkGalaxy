using DarkGalaxy_BLL;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_Model;
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
    public class WeChatMenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexJson()
        {
            DGResultData<WeChatMenu> result = new DGResultData<WeChatMenu>();

            //根据传入参数进行数据处理
            string Page = Request.Params["Page"];//页索引
            string PageSize = Request.Params["PageSize"];//页大小
            string Search = Request.Params["Search"];//搜索条件
            string PID = Request.Params["PID"];//查询子级WeChat菜单
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            if ((false == String.IsNullOrEmpty(Page)) && (false == String.IsNullOrEmpty(PageSize)) && (false == String.IsNullOrEmpty(Search)))
            {
                //参数page，size, search，条件查询全部分页WeChat菜单记录
                try
                {
                    int page = Convert.ToInt32(Page);
                    int size = Convert.ToInt32(PageSize);
                    int total = 0;
                    result.Datas = WeChatMenuBLL.SelectWeChatMenuLike(page, size, out total, Search);
                    result.Total = total;
                }
                catch
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "传入参数错误";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else if ((false == String.IsNullOrEmpty(Page)) && (false == String.IsNullOrEmpty(PageSize)))
            {
                //参数page，size，查询全部分页WeChat菜单记录
                try
                {
                    int page = Convert.ToInt32(Page);
                    int size = Convert.ToInt32(PageSize);
                    int total = 0;
                    result.Datas = WeChatMenuBLL.SelectWeChatMenu(page, size, out total);
                    result.Total = total;
                }
                catch
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "传入参数错误";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else if (!String.IsNullOrEmpty(PID))
            {
                //参数pid，查询全部查询子级WeChat菜单记录）
                try
                {
                    int pid = Convert.ToInt32(PID);
                    result.Datas = WeChatMenuBLL.SelectChildWeChatMenu(pid);
                    if (null == result.Datas)
                    {
                        result.Total = 0;
                    }
                    else
                    {
                        result.Total = result.Datas.Count;
                    }
                }
                catch
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "传入参数错误";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else if (!String.IsNullOrEmpty(Search))
            {
                //参数search，条件查询全部分页WeChat菜单记录
                try
                {
                    int page = Convert.ToInt32(Page);
                    int size = Convert.ToInt32(PageSize);
                    result.Datas = WeChatMenuBLL.SelectWeChatMenuLike(Search);
                    if (null == result.Datas)
                    {
                        result.Total = 0;
                    }
                    else
                    {
                        result.Total = result.Datas.Count;
                    }
                }
                catch
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "传入参数错误";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                //无参数，查询全部WeChat菜单记录
                result.Datas = WeChatMenuBLL.SelectWeChatMenu();
                if (null == result.Datas)
                {
                    result.Total = 0;
                }
                else
                {
                    result.Total = result.Datas.Count;
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

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WeChatMenu WeChatMenuModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(WeChatMenuModel.Title) || String.IsNullOrEmpty(WeChatMenuModel.Genre))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //新建WeChat菜单记录
            object MenusEventType = Enum.Parse(typeof(CustomizeMenusEventType), WeChatMenuModel.Genre);
            if (null != MenusEventType)
            {
                //设置Json字符串
                CustomizeMenusEventType CustomizeMenusEventTypes = (CustomizeMenusEventType)MenusEventType;
                CustomizeMenu_Button WeChatMenuButton = new CustomizeMenu_Button(WeChatMenuModel.Title, CustomizeMenusEventTypes)
                {
                    appid = Request.Form.Get("appid"),
                    key = Request.Form.Get("key"),
                    media_id = Request.Form.Get("media_id"),
                    pagepath = Request.Form.Get("pagepath"),
                    url = Request.Form.Get("url")
                };
                WeChatMenuModel.DetailedContent = Helper_Serializer_Json.JsonSerializer(WeChatMenuButton);

                //新建WeChat菜单记录
                int ID = 0;
                BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
                if (WeChatMenuBLL.InsertWeChatMenu(WeChatMenuModel,out ID))
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
            else
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "类型错误";
                return Json(result);
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
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

            //删除WeChat菜单记录
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            if (WeChatMenuBLL.DeleteSingleWeChatMenu(ID))
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

        [HttpPost]
        public ActionResult BatchDelete(int[] BatchIDArray)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((null == BatchIDArray) || (0 == BatchIDArray.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //批量删除WeChat菜单记录
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            if (WeChatMenuBLL.DeleteWeChatMenu(BatchIDArray))
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

        public ActionResult Edit(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return Content("~/Views/Common/ParameterError.cshtml");
            }
            else { }

            WeChatMenu result = null;

            //查询WeChat菜单记录
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            result = WeChatMenuBLL.SelectSingleWeChatMenu(ID);

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

        [HttpPost]
        public ActionResult Edit(WeChatMenu WeChatMenuModel)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if (String.IsNullOrEmpty(WeChatMenuModel.Title) || String.IsNullOrEmpty(WeChatMenuModel.Genre))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //修改WeChat菜单记录
            object MenusEventType = Enum.Parse(typeof(CustomizeMenusEventType), WeChatMenuModel.Genre);
            if (null != MenusEventType)
            {
                //设置Json字符串
                CustomizeMenusEventType CustomizeMenusEventTypes = (CustomizeMenusEventType)MenusEventType;
                CustomizeMenu_Button WeChatMenuButton = new CustomizeMenu_Button(WeChatMenuModel.Title, CustomizeMenusEventTypes)
                {
                    appid = Request.Form.Get("appid"),
                    key = Request.Form.Get("key"),
                    media_id = Request.Form.Get("media_id"),
                    pagepath = Request.Form.Get("pagepath"),
                    url = Request.Form.Get("url")
                };
                WeChatMenuModel.DetailedContent = Helper_Serializer_Json.JsonSerializer(WeChatMenuButton);

                //修改WeChat菜单记录
                BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
                if (WeChatMenuBLL.UpdateSingleWeChatMenu(WeChatMenuModel.ID, WeChatMenuModel))
                {
                    result.Code = ResultCodeType.Succeed;
                    result.Message = "修改成功";
                }
                else
                {
                    result.Code = ResultCodeType.NoFound;
                    result.Message = "修改失败";
                }

                return Json(result);
            }
            else
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "类型错误";
                return Json(result);
            }
        }

        public ActionResult WeChatMenus(string Genre)
        {
            switch (Genre)
            {
                case "view":
                    return View("MenuView");
                case "miniprogram":
                    return View("MenuMiniprogram");
                case "click":
                case "scancode_waitmsg":
                case "scancode_push":
                case "pic_sysphoto":
                case "pic_photo_or_album":
                case "pic_weixin":
                case "location_select":
                    return View("MenuKey");
                case "media_id":
                case "view_limited":
                    return View("MenuMedia");
                default:
                    return View("MenuSubmit");
            }
        }

        public ActionResult WeChatMenusTop(int ID = 0)
        {
            //查询顶级WeChat菜单记录
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            List<WeChatMenu> TopWeChatMenus = WeChatMenuBLL.SelectTopWeChatMenu();
            if (0 != ID)
            {
                TopWeChatMenus.RemoveAll(Model => Model.ID == ID);
            }
            else { }
            ViewData.Model = TopWeChatMenus;

            return View();
        }

        public ActionResult WeChatMenusChild(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return Content("传入参数错误");
            }
            else { }

            ViewData.Model = ID;

            return View();
        }

        [HttpPost]
        public ActionResult Publish(int[] PublishIDArray)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((null == PublishIDArray) || (0 >= PublishIDArray.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else if (3 < PublishIDArray.Length)
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "一级菜单不能超过三个";
                return Json(result);
            }
            else { }

            //发布WeChat菜单记录
            ResultCode WeChatResultCode = null;
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            CustomizeMenu CustomizeMenuModel = new CustomizeMenu();
            List<CustomizeMenu_Button> MenuButtons = new List<CustomizeMenu_Button>();
            foreach (var temp in PublishIDArray)
            {
                //查询WeChat菜单记录
                WeChatMenu WeChatMenuModel = WeChatMenuBLL.SelectSingleWeChatMenu(temp);
                CustomizeMenu_Button MenuButton = Helper_Serializer_Json.JsonDeserializer<CustomizeMenu_Button>(WeChatMenuModel.DetailedContent);
                List<WeChatMenu> ChildWeChatMenuList = WeChatMenuBLL.SelectChildWeChatMenu(temp, true);
                if (null != ChildWeChatMenuList)
                {
                    //设置二级WeChat菜单
                    List<CustomizeMenu_Button> MenuButtonList = new List<CustomizeMenu_Button>();
                    for (int i = 0; (i < 5) && (i < ChildWeChatMenuList.Count); i++)
                    {
                        MenuButtonList.Add(Helper_Serializer_Json.JsonDeserializer<CustomizeMenu_Button>(ChildWeChatMenuList[i].DetailedContent));
                    }
                    MenuButton.sub_button = MenuButtonList;
                }
                else { }
                MenuButtons.Add(MenuButton);
            }
            CustomizeMenuModel.button = MenuButtons;

            //创建自定义菜单
            WeChat_CustomizeMenu wecCustomizeMenu = new WeChat_CustomizeMenu();
            WeChatResultCode = wecCustomizeMenu.CreateCustomizeMenu(CustomizeMenuModel);

            //处理返回值
            if (null == WeChatResultCode)
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "发送请求失败";
            }
            else if ((0 == WeChatResultCode.errcode) && (0 == String.Compare("ok", WeChatResultCode.errmsg)))
            {
                //更新启用状态
                WeChatMenuBLL.UpdateTopWeChatMenuSetEmploy(false);
                WeChatMenuBLL.UpdateWeChatMenuSetEmploy(PublishIDArray, true);
                result.Code = ResultCodeType.Succeed;
                result.Message = "发布成功";
            }
            else
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "发布失败，错误代码：" + WeChatResultCode.errcode + "，错误消息：" + WeChatResultCode.errmsg;
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult Employ(int[] EmployIDArray)
        {
            DGResultMessage result = new DGResultMessage();

            //处理错误参数
            if ((null == EmployIDArray) || (0 >= EmployIDArray.Length))
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "参数错误";
                return Json(result);
            }
            else { }

            //启用、禁用二级菜单
            bool UpdateResult = false;
            BLL_WeChatMenu WeChatMenuBLL = new BLL_WeChatMenu();
            foreach (var temp in EmployIDArray)
            {
                var WeChatData = WeChatMenuBLL.SelectSingleWeChatMenu(temp);
                if (null != WeChatData)
                {
                    if (true == WeChatData.Employ)
                    {
                        UpdateResult = WeChatMenuBLL.UpdateSingleWeChatMenuSetEmploy(temp, false);
                    }
                    else
                    {
                        UpdateResult = WeChatMenuBLL.UpdateSingleWeChatMenuSetEmploy(temp, true);
                    }
                }
                else
                {
                    result.Code = ResultCodeType.BadRequest;
                    result.Message = "数据错误";
                    return Json(result);
                }
            }

            //处理返回值
            if (true == UpdateResult)
            {
                result.Code = ResultCodeType.Succeed;
                result.Message = "操作成功";
            }
            else
            {
                result.Code = ResultCodeType.BadRequest;
                result.Message = "操作失败";
            }

            return Json(result);
        }
    }
}