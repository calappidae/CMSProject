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
    public partial class course_arrange : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    bindData(sender, e);
            //}

        }
        public void bindData(object sender, EventArgs e)
        {
            string Constring = "server=.; database=CSMP; uid=sa; pwd= 123456";
            string tNo = Session["userName"] as string;
            //select classNo,className from Class where classNO in ( select Tc.classNo from TeacherCourse Tc,Teacher T where Tc.tchNo=T.tchNo and T.tchNo='B20000')
            string str = "select * from Course where semester ='" + DropDownList1.SelectedValue + "'";
            SqlConnection conn = new SqlConnection(Constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter myCommand = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            DropDownList1.DataTextField = "semester"; //此列名为DropDownList1显示的du值
            DropDownList1.DataValueField = "semester";
            DropDownList1.DataSource = source;
            DropDownList1.DataBind();
        }
       
        protected void Button1_Click(object sender, EventArgs e)    //查询课程信息按钮
        {
            string str = "server=.;database=CSMP;uid=sa;pwd=123456";
            
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            //string comp = "exec tip '" +samerster.Text+ "'";
            //string comp = "select * from Course where semester ='" + samerster.Text + "'";
            string CourseValue = DropDownList1.SelectedValue;
            string comp = "select * from Course where semester ='" + CourseValue + "'";
            SqlCommand cmd1 = new SqlCommand(comp, conn);
            string rowcount = Convert.ToString(cmd1.ExecuteScalar());  //返回受影响的行
            if (rowcount.Equals(""))//判断数据是否存在
            {
                tishi3.Text = "没有" + CourseValue + "这学期的数据，请确认输入正确。";
            }
            else
            {
                tishi3.Text = "";
                string str1 = @"select Course.courseId 课程号,Course.courseName 课程名,semester 学期
                            from Course
                            where semester='" + CourseValue + "'";
                SqlDataAdapter da = new SqlDataAdapter(str1, conn);
                DataSet ds = new DataSet();
                ds.Clear();
                da = new SqlDataAdapter(str1, conn);
                da.Fill(ds);
                GridView1.DataSource = ds; GridView1.DataBind();
              
            }
                conn.Close();
        }

        protected void commit_Click(object sender, EventArgs e)  //添加教学课程表，提交按钮
        {
            if (ton.Text.Length != 6)
            {
                tonTs.Text = "职工号必须6位";
                ton.Focus();
                return;
            }
            else
                tonTs.Text = "";
            if (courseId.Text.Length != 4)
            {
                courseIdTs.Text = "课程号必须4位";
                courseId.Focus();
                return;
            }
            else
                courseIdTs.Text = "";
            if (classNum.Text.Length != 4)
            {
                classNumTs.Text = "班级号必须4位";
                classNum.Focus();
                return;
            }
            else
                classNumTs.Text = "";

            string str = "server=.;database=CSMP;uid=sa;pwd=123456";
            SqlConnection conn = new SqlConnection(str);
            string str1 = "insert into TeacherCourse(courseId,classNo,tchNo,tctesk) values('"
                            + courseId.Text + "','" + classNum.Text + "','" + ton.Text + "','" + teach.Text.Trim() + "')";    
            string comp = "exec TW '" + courseId.Text + "','" + classNum.Text + "','" + ton.Text + "'";
            SqlCommand cmd1 = new SqlCommand(comp, conn);
            SqlCommand cmd = new SqlCommand(str1, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            conn.Open();
            int rowcount = Convert.ToInt32(da.SelectCommand.ExecuteScalar());   //返回受影响的行
            if (rowcount > 0)//判断数据是否重复
                tishi2.Text = "该数据已经存在！";
            else
            {
                int flag2 = cmd.ExecuteNonQuery();//执行添加
                if (flag2 > 0) //如果添加成功
                    tishi2.Text = "提交成功！";
                else          //如果添加失败
                    tishi2.Text = "添加失败！";
            }
           conn.Close();
        }


        protected void clear_Click(object sender, EventArgs e)  //清空按钮
        {
            courseId.Text = "";
            classNum.Text = "";
            ton.Text = "";
            tishi2.Text = "";
            tonTs.Text = "";
            courseIdTs.Text = "";
            classNumTs.Text = "";
        }

        protected void tonQuery_Click(object sender, EventArgs e)  //查询职工号按钮
        {
            string str = "server=.;database=CSMP;uid=sa;pwd=123456";

            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string str1 = "select tchNo 职工号,tchName 姓名 from Teacher ";  
            SqlDataAdapter da = new SqlDataAdapter(str1, conn);
            DataSet ds = new DataSet();
            ds.Clear();
            da = new SqlDataAdapter(str1, conn);
            da.Fill(ds);
            GridView2.DataSource = ds; GridView2.DataBind();
            conn.Close();

        }

        protected void Button1_Click1(object sender, EventArgs e)  //查询班级信息
        {
            string str = "server=.;database=CSMP;uid=sa;pwd=123456";

            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string str1 = "select classNo 班级号,className 班级名 from Class";
            SqlDataAdapter da = new SqlDataAdapter(str1, conn);
            DataSet ds = new DataSet();
            ds.Clear();
            da = new SqlDataAdapter(str1, conn);
            da.Fill(ds);
            GridView3.DataSource = ds; 
            GridView3.DataBind();
            conn.Close();
        }

    }
}