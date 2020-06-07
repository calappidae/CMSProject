using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSProject
{
    public partial class stuMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((string)Session["userRole"] != "0")
            //    Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session["userN"] = "";
            Session["userRole"] = "";
            Response.Redirect("login.aspx");
        }
    }
}