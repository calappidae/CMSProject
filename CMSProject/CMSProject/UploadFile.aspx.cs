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
    public partial class UploadFile : System.Web.UI.Page
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

        protected void rptUpLoad_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string stuNo = Session["userName"] as string;
            string command = e.CommandName;
            FileUpload fu = e.Item.FindControl("FileUpload2") as FileUpload;
            //Response.Write("<script>alert('" + stuNo + "')</script>");
            //return;
            switch (command)
            {
                case "Upload":
                    string Job = Convert.ToString(e.CommandArgument);
                    //Response.Write("<script>alert('" + Job + "')</script>");
                    //return;
                    string fullFileName = fu.PostedFile.FileName;//获取文件名称
                    //从路径中截取出文件名
                    string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
                    //限定上传文件的格式
                    string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
                    if (type == "doc" || type == "docx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
                    {
                        //将文件保存在服务器中根目录下的files文件夹中
                        string saveFileName = Server.MapPath(".\\File\\") + fileName;
                        fu.PostedFile.SaveAs(saveFileName);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('文件上传成功！');</script>");

                        //向数据库中存储相应通知的附件的目录
                        string upFileName = fileName;               //附件名
                        string upFileNamePath = saveFileName;//.Replace("\\","//");        //附件的存储路径
                        SqlConnection conn = new SqlConnection(ConnectionString);
                        //string upFileName="sldfj";               //附件名
                        //string upFileNamePath = "sdfjlk";        //附件的存储路径
                        //select tchNo from ClassGroup where ClassGroup.classGroupNo in( select classGroupNo from AssignmentsAnswer where AssignmentsAnswer.JobNo ='lksdj')
                        string insertStr = "EXEC AssignmentInsert '" + upFileName + "','" + upFileNamePath + "','" + Job + "','" + stuNo + "'";
                        
                        SqlCommand cmd = new SqlCommand(insertStr, conn);
                        conn.Open();
                        int flag = cmd.ExecuteNonQuery();//执行添加
                        if (flag > 0)//如果添加成功
                            Label1.Text = "上传成功";
                        else
                        {
                            Label1.Text = saveFileName;
                        }
                        conn.Close();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择正确的格式');</script>");
                    }
                    break;
                case "Del":
                    //删除代码不实现，这个需要根据需求写。
                    break;
            }
        }



        //protected void btnUpLoad_Click(object sender, EventArgs e)
        //{
        //    string ConnectionString = "server=.; database=teaching; uid=sa; pwd= 123456";

        //    string tchNo = Session["userName"] as string;
        //    //取出所选文件的本地路径
        //    string fullFileName = this.UpLoad.PostedFile.FileName;
        //    //从路径中截取出文件名
        //    string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
        //    //限定上传文件的格式
        //    string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        //    if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
        //    {
        //        //将文件保存在服务器中根目录下的files文件夹中
        //        string saveFileName = Server.MapPath(".\\File\\") + fileName;
        //        UpLoad.PostedFile.SaveAs(saveFileName);
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('文件上传成功！');</script>");

        //        //向数据库中存储相应通知的附件的目录
        //        string upFileName = fileName;               //附件名
        //        string upFileNamePath = saveFileName;//.Replace("\\","//");        //附件的存储路径
        //        SqlConnection conn = new SqlConnection(ConnectionString);
        //        //string upFileName="sldfj";               //附件名
        //        //string upFileNamePath = "sdfjlk";        //附件的存储路径

        //        string insertStr = "insert into Assignment(assignmentSubFileName,assignmentSubFilePath,tchNo,JobNo) values('" + upFileName + "','" + upFileNamePath + "','" + tchNo + "','" + tchNo + "')";
        //        SqlCommand cmd = new SqlCommand(insertStr, conn);
        //        conn.Open();
        //        int flag = cmd.ExecuteNonQuery();//执行添加
        //        if (flag > 0)//如果添加成功
        //            Label1.Text = "上传成功";
        //        else
        //        {
        //            Label1.Text = saveFileName;
        //        }
        //        conn.Close();
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择正确的格式');</script>");
        //    }
        //}

        //protected void btnUpLoad_Click(object sender, EventArgs e)
        //{
        //    string ConnectionString = "server=.; database=teaching; uid=sa; pwd= 123456";

        //    string tchNo = Session["userName"] as string;
        //    //取出所选文件的本地路径
        //    string fullFileName = this.UpLoad.PostedFile.FileName;
        //    //从路径中截取出文件名
        //    string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
        //    //限定上传文件的格式
        //    string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        //    if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
        //    {
        //        //将文件保存在服务器中根目录下的files文件夹中
        //        string saveFileName = Server.MapPath(".\\File\\") + fileName;
        //        UpLoad.PostedFile.SaveAs(saveFileName);
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('文件上传成功！');</script>");

        //        //向数据库中存储相应通知的附件的目录
        //        string upFileName = fileName;               //附件名
        //        string upFileNamePath = saveFileName;//.Replace("\\","//");        //附件的存储路径
        //        SqlConnection conn = new SqlConnection(ConnectionString);
        //        //string upFileName="sldfj";               //附件名
        //        //string upFileNamePath = "sdfjlk";        //附件的存储路径

        //        string insertStr = "insert into Assignment(assignmentSubFileName,assignmentSubFilePath,tchNo,JobNo) values('" + upFileName + "','" + upFileNamePath + "','" + tchNo + "','" + tchNo + "')";
        //        SqlCommand cmd = new SqlCommand(insertStr, conn);
        //        conn.Open();
        //        int flag = cmd.ExecuteNonQuery();//执行添加
        //        if (flag > 0)//如果添加成功
        //            Label1.Text = "上传成功";
        //        else
        //        {
        //            Label1.Text = saveFileName;
        //        }
        //        conn.Close();
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择正确的格式');</script>");
        //    }
        //}

    }
}