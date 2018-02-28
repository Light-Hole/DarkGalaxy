using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using System.Web.Mvc;
using System.Web.Security;

namespace DarkGalaxy_UI_Manage.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            //判断登录状态
            if (null != Session["AdminAccount"])
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(string UserName, string Password)
        {
            AdminAccount result = null;

            //验证管理员帐户
            BLL_AdminAccount AdminAccountBLL = new BLL_AdminAccount();
            result = AdminAccountBLL.SelectSingleAdminAccount(UserName, Password);

            //处理返回值
            if (null != result)
            {
                //保存登录状态
                Session.Timeout = 60;
                Session.Add("AdminAccount", result);

                return Content(Url.Action("Index", "Home"));
            }
            else
            {
                return Content("error");
            }
        }

        [LoginAttribute]
        public ActionResult Logout()
        {
            //清除登录状态
            Session.Remove("AdminAccount");

            return RedirectToAction("Index");
        }
    }
}