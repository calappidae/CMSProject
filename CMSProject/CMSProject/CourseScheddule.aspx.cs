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
    public partial class CourseScheddule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropListData(sender, e);
                DropDownList1_SelectedIndexChanged2(sender, e);
            }
        }

        SqlConnection conne;
        SqlDataAdapter da;
        static DataSet ds;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "server=.;database=CSMP;uid=sa;pwd=123456";

            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            //string ss = DropDownList1.Text + "|" + DropDownList2.SelectedValue;
            //Response.Write("<script>alert('" + ss + "')</script>");
            //return;
            string str1 = "select * from CS('" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "')";
            SqlDataAdapter da = new SqlDataAdapter(str1, conn);
            DataSet ds = new DataSet();
            ds.Clear();
            da = new SqlDataAdapter(str1, conn);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //清除客户端当前显示
            Response.Clear();
            Response.Buffer = true;

            //输出类型为Word
            //Response.ContentType = "application/ms-word";
            //输出类型为Excel
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.ContentEncoding = System.Text.Encoding.UTF8;

            //设置显示的字和内容要存的形式
            Response.Charset = "xls文档";

            string dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = System.Web.HttpUtility.UrlEncode("" + dateStr, System.Text.Encoding.UTF8);

            //设置保存的文件名
            Response.AppendHeader("content-disposition", "attachment;filename=\"" + fileName + ".xls\"");
            this.EnableViewState = false;

            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

            GridView1.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        protected void bindDropListData(object sender, EventArgs e)
        {
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            SqlConnection conn = new SqlConnection(ConnectionString);
            string eNo = Session["userName"] as string;
            conn.Open();
            //SELECT [semester] FROM [Course]
            string str = "SELECT distinct semester FROM Course";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList2.DataTextField = "semester"; //此列名为DropDownList1显示的du值
            DropDownList2.DataValueField = "semester";
            DropDownList2.DataSource = source;
            DropDownList2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string ConnectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            //SELECT semester FROM Course
            string info = DropDownList2.SelectedValue;
            string str = "SELECT * FROM Course where semester='" + info + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList1.DataTextField = "courseName"; //此列名为DropDownList2显示的du值
            DropDownList1.DataValueField = "courseName";
            DropDownList1.DataSource = source;
            DropDownList1.DataBind();
            conn.Close();
        }
        public override void VerifyRenderingInServerForm(Control control) { 
        
        }

    }
}