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
    public partial class PublishAnswers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button3_Click1(sender, e);
                DropDownList1_SelectedIndexChanged1(sender, e);
            }
        }
       
        protected void btnCommit_Click(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string answerContent = tbAnswerContent.Text.Trim(); //
            string cGroupNo = DropDownList1.SelectedValue;
            string AssignmentNo = DropDownList2.SelectedValue;
            string tNo = Session["userName"] as string;
            //--------------
            //Label1.Text = DealLine;
            //-------------
            //return;
            SqlConnection conn = new SqlConnection(Constring);
            string createStr = @"update AssignmentsAnswer set answerContent='" + answerContent + "'where JobNo='" + AssignmentNo + "'and classGroupNo='" + cGroupNo + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(createStr, conn);
            int flag = cmd.ExecuteNonQuery();
            if (flag > 0)
            {
                tbAnswerContent.Text = "";
                Response.Write("<script>alert('发布成功!')</script>");
            }
            else
            {
                tbAnswerContent.Text = "";
                Response.Write("<script>alert('发布失败!')</script>");
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbAnswerContent.Text = "";
        }
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string cGroupNo = DropDownList1.SelectedValue;

            //string tNo = Session["userName"] as string;
            string str = "SELECT JobNo, assignmentName FROM AssignmentsAnswer WHERE classGroupNo = '" + cGroupNo + "'";
            SqlConnection conn = new SqlConnection(Constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList2.DataTextField = "assignmentName"; //此列名为DropDownList1显示的du值
            DropDownList2.DataValueField = "JobNo";
            DropDownList2.DataSource = source;
            DropDownList2.DataBind();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            //string cGroupNo = DropDownList1.SelectedValue;
            string tNo = Session["userName"] as string;
            string str = "SELECT classGroupNo, classGroupName FROM ClassGroup WHERE tchNo='" + tNo + "'";
            SqlConnection conn = new SqlConnection(Constring);
            conn.Open();
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
  
    }
}