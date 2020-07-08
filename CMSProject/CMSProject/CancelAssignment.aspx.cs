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
    public partial class CancelAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropListData(sender, e);
                DropDownList1_SelectedIndexChanged1(sender, e);
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
            //string ss = sNo + "|" + info;
            //Response.Write("<script>alert('" + ss + "')</script>");
            //return;
            //EXEC viewDownloadFile 'max001','F444'
            string sqlstr = "EXEC viewDownloadFile '" + sNo + "','" + info + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
            DataTable dtt = new DataTable();
            sda.Fill(dtt);
            Repeater1.DataSource = dtt;
            Repeater1.DataBind();
            conn.Close();
        }

        protected void Button1_Click(object sender, CommandEventArgs e)
        {
           
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string stuNo = Session["userName"] as string;
            string Ano = e.CommandArgument.ToString();
            SqlConnection conn;
            //string strr = stuNo + "|" + Ano;
            //Response.Write("<script>alert('" + strr + "')</script>");
            //return;
            if (Ano!=null)
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                //EXEC DeleteAssignment '"+Ano+"'
                string str = "EXEC DeleteAssignment '" + Ano + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {//Response.Write("<script>alert('" + stuNo + "')</script>");
                    Response.Write("<script>alert('撤回成功')</script>");
                    DropDownList1_SelectedIndexChanged1(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('撤回失败')</script>");
                }
                conn.Close();
            }
        }
    }
}