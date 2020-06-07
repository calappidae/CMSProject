using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ruanjiangongchen
{
    public partial class login : System.Web.UI.Page
    {
        string s = "server=.;database=CSMP;uid=sa;pwd=123456";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            string userName = TextBox1.Text.Trim();
            string userPwd = TextBox2.Text.Trim();
            string userRole = RadioButtonList1.SelectedValue;
            string selectstr = "";
            switch(userRole){
                case "0":
                    selectstr = string.Format("select *from SecretaryAccount where seNO='{0}'and sePassword ='{1}'",userName,userPwd);
                    break;
                case "1":
                    selectstr = string.Format("select *from Teacher where tchNO='{0}'and tchPassword='{1}'",userName,userPwd);
                    break;
                case "2":
                    selectstr = string.Format("select *from Student where stuNo='{0}'and passWord='{1}'", userName, userPwd);
                    break;
                case "3":
                    selectstr = string.Format("select *from ManAccount where mNO='{0}'and mPassword='{1}'",userName,userPwd);
                    break;
            }
            conn.Open();//打开连接
            SqlCommand cmd = new SqlCommand(selectstr,conn);//获取执行对象
            SqlDataReader dr = cmd.ExecuteReader();//执行查询

            if (dr.Read())
            {//如果找到了记录
                Session["userName"] = userName;
                Session["userN"] = (string)dr[2];//数据库中取用户姓名
                Session["userRole"] = userRole;
                TextBox1.Text = "";
                TextBox2.Text = "";
                switch (userRole)
                {
                    case "0":
                        Response.Redirect("teaching.aspx");
                        break;
                    case "1":
                        Response.Redirect("teacher.aspx");
                        break;
                    case "2":
                        Response.Redirect("student.aspx");
                        break;
                    case "3":
                        Response.Redirect("administrator.aspx");
                        break;
                }
            }
            else
                Label3.Text = "用户名或密码错误";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label3.Text = "";
            RadioButtonList1.SelectedValue = "2";
        }
    }
}