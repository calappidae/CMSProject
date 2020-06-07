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
    public partial class ClassGroupCreate : System.Web.UI.Page
    {
        private int rep = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button3_Click1(sender,e);
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
            string classGroupName = tbClassGroupName.Text.Trim(); //课群名
            string classNo = DropDownList3.SelectedValue;
            string classGroupNo = GenerateCheckCode(4);
            string cgInfo = tbClassGroupInfo.Text.Trim();
            string tchNo = Session["userName"] as string;
            //--------------
            //Label1.Text = tchNo;
            //-------------
            //return;
            SqlConnection conn = new SqlConnection(Constring);
            SqlCommand cmd;
            string selsctrcg = "select * from ClassGroup where ClassGroup.tchNo='" + tchNo + "'";
            conn.Open();
            cmd = new SqlCommand(selsctrcg, conn);
            string rowcount = Convert.ToString(cmd.ExecuteScalar());  //返回受影响的行
            if (rowcount.Equals(""))//判断数据是否存在
            {
                string createStr = @"insert into ClassGroup(classGroupNo,classGroupName,cgInfo,tchNo,classNo) 
                               values('" + classGroupNo + "','" + classGroupName + "','" + cgInfo + "','" + tchNo + "','" + classNo + "')";
                cmd = new SqlCommand(createStr, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    Response.Write("<script>alert('创建成功!')</script>");
                }
                else
                {
                    tbClassGroupName.Text = "";
                    tbClassGroupInfo.Text = "";
                    //DropDownList3.SelectedValue = "";
                    //Request.Form["TextArea1"] = "";
                    Response.Write("<script>alert('创建失败!')</script>");
                }
            }else
            {
                Label1.Text = "一个教师在一个班级上只能创建一个课群";
                tbClassGroupName.Text = "";
                tbClassGroupInfo.Text = "";
            }
            conn.Close();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbClassGroupName.Text = "";
            tbClassGroupInfo.Text = "";
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string tNo = Session["userName"] as string;
            //select classNo,className from Class where classNO in ( select Tc.classNo from TeacherCourse Tc,Teacher T where Tc.tchNo=T.tchNo and T.tchNo='B20000')
            string str = "select classNo,className from Class where classNO in ( select Tc.classNo from TeacherCourse Tc,Teacher T where Tc.tchNo=T.tchNo and T.tchNo='" + tNo + "')";
            SqlConnection conn = new SqlConnection(Constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList3.DataTextField = "className"; //此列名为DropDownList1显示的du值
            DropDownList3.DataValueField = "classNo";
            DropDownList3.DataSource = source;
            DropDownList3.DataBind();
        }
    }
}