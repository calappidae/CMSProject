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
    public partial class ClassGroupDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData(sender, e);
        }
        protected void BindData(object sender, EventArgs e)
        {
            string str = "server=.;database=CSMP;uid=sa;pwd=123456";

            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            //string ss = DropDownList1.Text + "|" + DropDownList2.SelectedValue;
            //Response.Write("<script>alert('" + ss + "')</script>");
            //return;
            string str1 = @"SELECT classGroupNo as 课群编号, classGroupName as 课群名, cgInfo as 课群介绍,Class.className as 班级
                           FROM ClassGroup,Class where ClassGroup.classNo=Class.classNo";
            SqlDataAdapter da = new SqlDataAdapter(str1, conn);
            DataSet ds = new DataSet();
            ds.Clear();
            da = new SqlDataAdapter(str1, conn);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //如果单击的是“选修”按钮
            if (e.CommandName == "Selt")
            {
                string str = "server=.;database=CSMP;uid=sa;pwd=123456";
                int index1 = Convert.ToInt32(e.CommandArgument);
                //取出选修课程所在的行索引
                string CourseID = GridView1.Rows[index1].Cells[0].Text.ToString();
                //Response.Write("<script>alert('" + CourseID + "')</script>");
                //return;
                SqlConnection conn = new SqlConnection(str);
                string insertStr = "EXEC DeleteClassGroupBycgNO '" + CourseID + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertStr, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    Response.Write("<script>alert('删除成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");
                }
                conn.Close();
                BindData(sender, e);
            }
        }

    }
}