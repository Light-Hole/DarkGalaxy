using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DarkGalaxy_UI_Manage.pay
{
    public partial class Pays : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pay/EnterprisePay.aspx?OrderNum=" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 28));
        }
    }
}