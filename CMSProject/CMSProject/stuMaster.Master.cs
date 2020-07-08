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
            if ((string)Session["userRole"] != "2")
                Response.Redirect("login.aspx");
            else
                Label1.Text = (string)Session["userN"];
        }
    }
}