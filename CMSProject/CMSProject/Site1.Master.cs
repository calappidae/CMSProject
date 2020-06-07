using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ruanjiangongchen
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["userRole"] != "0")
                Response.Redirect("login.aspx");
            else
                Label1.Text = "欢迎您：" + Session["userN"];
        }

        protected void Menu6_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect("course_arrange.aspx");
        }
    }
}