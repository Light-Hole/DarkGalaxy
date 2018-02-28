using DarkGalaxy_BLL;
using DarkGalaxy_Model;
using DarkGalaxy_UI_Manage.Models;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    [Login]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminAccountViewModel result = new AdminAccountViewModel();

            //查询用户信息记录
            BLL_AdminInformation AdminInformationBLL = new BLL_AdminInformation();
            AdminAccount AdminAccountInfo = (AdminAccount)Session["AdminAccount"];
            AdminInformation AdminInfo = AdminInformationBLL.SelectSingleAdminInformation_AdminAccount(AdminAccountInfo.ID);
            result.AdminAccountModel = AdminAccountInfo;
            result.AdminInfoModel = AdminInfo;
            ViewData.Model = result;

            return View();
        }

        public ActionResult HomeNavigation()
        {
            return View();
        }

        public ActionResult ColumnNavigation()
        {
            return View();
        }

        public ActionResult UserNavigation()
        {
            return View();
        }

        public ActionResult SystemNavigation()
        {
            return View();
        }
    }
}