using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSProject
{
    public partial class ImportCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DataTable GetExcelDatatable(string fileUrl)
        {
            // HDR=Yes代表第一行是标题，不是数据；
            string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileUrl + ";  Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            System.Data.DataTable dt = null;
            //建立连接
            OleDbConnection conn = new OleDbConnection(cmdText);
            try
            {
                //打开连接
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    //if (conn.State == System.Data.ConnectionState.Open) {  //测试用的
                    //  Response.Write("文件链接成功！");
                    // }
                }

                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string strSql = "select * from [Sheet1$]";   //这里指定表明为Sheet1
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0]; ;
                return dt;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <param name="savePath">文件的完整路径（包括扩展名）</param>
        /// <param name="destinationTableName">目标数据库表名</param>
        /// <returns>如果成功插入，返回true</returns>
        public bool SqlBulkCopyToDB(string savePath, string destinationTableName)
        {
            DataTable ds = new DataTable();

            string connectionString = "server=.; database=CSMP; uid=sa; pwd= 123456";
            using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(connectionString))// 使用using 该链接在最后会自动关闭
            {

                ds = GetExcelDatatable(savePath);           //调用自定义方法
                //bcp.BatchSize = 100;//每次传输的行数 
                //bcp.NotifyAfter = 100;//进度提示的行数 
                // bcp.DestinationTableName = "Tb";//需要导入的数据库表名
                bcp.DestinationTableName = destinationTableName; //需要导入的数据库表名

                string[] sqlTableName = { "courseId", "courseName", "semester" };
                try
                {
                    //excel表头与数据库列对应关系 
                    for (int i = 0; i < ds.Columns.Count; ++i)
                    {
                        //string s = ds.Columns[i].ColumnName;
                        bcp.ColumnMappings.Add(ds.Columns[i].ColumnName, sqlTableName[i]);   // 设置excel表中列名与数据库中表列名的映射关系  sqlTableName[i]中存的时数据库表中的各个字段

                    }
                    bcp.WriteToServer(ds);
                    return true;
                    //Response.Write("<script>alert('Excle表导入成功!')</script>");   //不能成功导入时，对用户进行提示
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                    //Response.Write("<script>alert('Excle表导入失败!');</script>");
                }
            }
        }

        public void getDataExecle(string savePath, string destinationTableName)
        {
            DataTable ds = new DataTable();
            ds = GetExcelDatatable(savePath);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnImport_Click(object sender, EventArgs e)
        {

            if (fulImportCourse.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }

            string IsXls = Path.GetExtension(fulImportCourse.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {

                Response.Write(fulImportCourse.FileName);
                Response.Write("<script>alert('只可以选择Excel文件')</script>");
                return;//当选择的不是Excel文件时,返回
            }

            string filename = fulImportCourse.FileName;              //获取Execle文件名  DateTime日期函数

            string savePath = Server.MapPath((".\\File\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
            //Response.Write(savePath);
            //savePath ="E:\\Visual Studio 2013 Workspace\\fileUpLoad\\fileUpLoad\\uploadfiles\\201842314025658.xls"

            fulImportCourse.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上   文件可以成功保存

            bool ok = SqlBulkCopyToDB(savePath, "Course");   //  用SqlBulkCopy 将表中数据插入数据库  “tableOne”为要插入数据库的表名
            if (ok)
            {
                Response.Write("<script>alert('导入成功!')</script>");   //不能成功导入时，对用户进行提示
            }
            else
            {
                Response.Write("<script>alert('导入失败!');</script>");
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            if (fulImportCourse.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {

                Response.Write("<script>alert('请您选择Excel文件')</script> ");

                return;//当无文件时,返回

            }

            string IsXls = Path.GetExtension(fulImportCourse.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名

            if (IsXls != ".xlsx" && IsXls != ".xls")
            {

                Response.Write(fulImportCourse.FileName);

                Response.Write("<script>alert('只可以选择Excel文件')</script>");

                return;//当选择的不是Excel文件时,返回

            }

            string filename = fulImportCourse.FileName;              //获取Execle文件名  DateTime日期函数

            string savePath = Server.MapPath((".\\File\\") + filename);//Server.MapPath 获得虚拟服务器相对路径

            //Response.Write(savePath);

            //savePath ="E:\\Visual Studio 2013 Workspace\\fileUpLoad\\fileUpLoad\\uploadfiles\\201842314025658.xls"

            fulImportCourse.SaveAs(savePath);                    //SaveAs 将上传的文件内容保存在服务器上   文件可以成功保存

            getDataExecle(savePath, "Course");

        }
    }
}