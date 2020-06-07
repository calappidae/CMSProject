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
    public partial class AssignJob : System.Web.UI.Page
    {
        private int rep = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button3_Click1(sender, e);
            }
        }
        private string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + this.rep;
            this.rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this.rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string AssignmentName = tbAssignmentName.Text.Trim(); //
            string AssignmentNo = GenerateCheckCode(5);
            string classGroupNo = DropDownList3.SelectedValue;
            string AssignmentInfo = tbAssignmentContent.Text.Trim();
            string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string DealLine = Request.Form.Get("DealTime").ToString(); ;
            string tchNo = Session["userName"] as string;
            //--------------
            //Label1.Text = DealLine;
            //-------------
            //return;
            SqlConnection conn = new SqlConnection(Constring);
            string createStr = @"EXEC AssignmJobpor '" + AssignmentNo + "','" + AssignmentName + "','" + AssignmentInfo + "','" + StartTime + "','" + DealLine + "','" + classGroupNo + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(createStr, conn);
            int flag = cmd.ExecuteNonQuery();
            if (flag > 0)
            {
                tbAssignmentName.Text = "";
                tbAssignmentContent.Text = "";
                Response.Write("<script>alert('发布成功!')</script>");
            }
            else
            {
                tbAssignmentName.Text = "";
                tbAssignmentContent.Text = "";
                Response.Write("<script>alert('发布失败!')</script>");
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbAssignmentName.Text = "";
            tbAssignmentContent.Text = "";
            //test1.Value = "";
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string cGroupNo = DropDownList3.SelectedValue;
            string tNo = Session["userName"] as string;
            string str = "SELECT classGroupNo, classGroupName FROM ClassGroup WHERE tchNo='" + tNo + "'";
            SqlConnection conn = new SqlConnection(Constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList3.DataTextField = "classGroupName"; //此列名为DropDownList1显示的du值
            DropDownList3.DataValueField = "classGroupNo";
            DropDownList3.DataSource = source;
            DropDownList3.DataBind();
        }
    }
}