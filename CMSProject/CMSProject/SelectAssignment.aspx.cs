using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSProject
{
    public partial class SelectAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropListData(sender,e);
                DropDownList1_SelectedIndexChanged1(sender,e);
            }
        }

        protected void bindDropListData(object sender, EventArgs e)
        {
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            SqlConnection conn = new SqlConnection(ConnectionString);
            string sNo = Session["userName"] as string;
            conn.Open();
            string str = "select * from ClassGroup where  ClassGroup.classNo in (select classNo from Student where stuNo='" + sNo + "')";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList1.DataTextField = "classGroupName"; //此列名为DropDownList1显示的du值
            DropDownList1.DataValueField = "classGroupNo";
            DropDownList1.DataSource = source;
            DropDownList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            SqlConnection conn = new SqlConnection(ConnectionString);
            string sNo = Session["userName"] as string;
            conn.Open();

            string info = DropDownList1.SelectedValue;
            //select AssignmentsAnswer.* from  AssignmentsAnswer where AssignmentsAnswer.classGroupNo = '" + info + "'
            //string sqlstr = "select AssignmentsAnswer.* from ClassGroup join AssignmentsAnswer on ClassGroup.classGroupNo=AssignmentsAnswer.classGroupNo where AssignmentsAnswer.classGroupNo=(select classGroupNo from ClassGroup where classGroupName='" + info + "')";
            string sqlstr = "select AssignmentsAnswer.* from  AssignmentsAnswer where AssignmentsAnswer.classGroupNo = '" + info + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
            DataTable dtt = new DataTable();
            sda.Fill(dtt);
            Repeater1.DataSource = dtt;
            Repeater1.DataBind();
            conn.Close();
        }
    }
}