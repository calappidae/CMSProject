using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSProject
{
    public partial class ScoreEnterResults : System.Web.UI.Page
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
            string tNo = Session["userName"] as string;
            conn.Open();

            //select * from ClassGroup where ClassGroup.tchNo='B20001'
            //string str = "select * from ClassGroup where  ClassGroup.classNo in (select classNo from Student where stuNo='" + sNo + "')";
            string str = "select * from ClassGroup where ClassGroup.tchNo='" + tNo + "'";
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
            conn.Open();
            //select * from ClassGroup where ClassGroup.tchNo='B20001'
            string info = DropDownList1.SelectedValue;
            string str = "select * from dbo.SelectJobNoBytchNo('"+info+"')";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList2.DataTextField = "assignmentName"; //此列名为DropDownList2显示的du值
            DropDownList2.DataValueField = "JobNo";
            DropDownList2.DataSource = source;
            DropDownList2.DataBind();
            conn.Close();
            DropDownList1_SelectedIndexChanged2(sender,e);
        }

        protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            SqlConnection conn = new SqlConnection(ConnectionString);
            string sNo = Session["userName"] as string;
            conn.Open();
            string info = DropDownList2.SelectedValue;
            //string ss = sNo + "|" + info;
            //Response.Write("<script>alert('" + ss + "')</script>");
            //return;
            //EXEC SelectAssignement '02F6D'
            string sqlstr = "EXEC SelectAssignement '" + info + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
            DataTable dtt = new DataTable();
            sda.Fill(dtt);
            Repeater1.DataSource = dtt;
            Repeater1.DataBind();
            conn.Close();
        }


        protected void rptUpLoad_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string stuNo = Session["userName"] as string;
            string command = e.CommandName;
            //Response.Write("<script>alert('" + stuNo + "')</script>");
            //return;
            switch (command)
            {
                case "Submit":
                    TextBox tb1 = e.Item.FindControl("tbAssingmentScore") as TextBox;
                    string tb = tb1.Text.Trim();
                    int score = Convert.ToInt32(tb);
                    TextBox tb2 = e.Item.FindControl("tbAssingmentmark") as TextBox;
                    string evaluate = tb2.Text.Trim();
                    string no = e.CommandArgument.ToString();
                    int Ano = Convert.ToInt32(no);
                    //string ss = tb1.Text.Trim() + "|" + tb2.Text.Trim()+"|"+Ano;
                    //Response.Write("<script>alert('" + ss + "')</script>");
                    //return;
                    //EXEC UpdateScoreMark 3,80,'撒旦发射点'
                    string updatestr = "EXEC UpdateScoreMark  " + Ano + "," + score + ",'" + evaluate + "'";
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(updatestr, conn);
                    int flag = cmd.ExecuteNonQuery();
                    if (flag > 0)
                    {
                        Label Lab = e.Item.FindControl("Label1") as Label;
                        Lab.Text = "录入成功";
                    }
                    else
                    {
                        Label Lab = e.Item.FindControl("Label1") as Label;
                        Lab.Text = "录入失败";
                    }
                    break;
            }
        }

        protected void LinkButton1_Click(object sender, CommandEventArgs e)
        {
            // 定义文件名  
            //Button Btn = sender as Button;
            //string url = Btn.CommandArgument.ToString();
            string fileName = "";
            // 获取文件在服务器的地址  
            //string url = "C:\\Users\\wanyuan\\Desktop\\one\\WebApplication1\\WebApplication1\\File\\tableOne.xlsx";
            string url = e.CommandArgument.ToString();
            Response.Write("<script>alert('url');</script>");
            //string url = e.ToString();
            // 判断传输地址是否为空  
            if (url == "")
            {
                // 提示“该文件暂不提供下载”  
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
                return;
            }
            // 判断获取的是否为地址，而非文件名  
            if (url.IndexOf("\\") > -1)
            {
                // 获取文件名  
                fileName = url.Substring(url.LastIndexOf("\\") + 1);
            }
            else
            {
                // url为文件名时，直接获取文件名  
                fileName = url;
            }
            // 以字符流的方式下载文件  
            FileStream fileStream = new FileStream(@url, FileMode.Open);
            byte[] bytes = new byte[(int)fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Response.ContentType = "application/octet-stream";

            // 通知浏览器下载 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}