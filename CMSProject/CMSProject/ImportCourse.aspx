<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ImportCourse.aspx.cs" Inherits="CMSProject.ImportCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div class="imporDateForm">
          <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
            <legend>导入课程</legend>
          </fieldset>
     <div>
         <div class="importDateIn">
             <asp:FileUpload style="color:#FF5722" ID="fulImportCourse" runat="server" Height="30px" Width="300px" />
         </div>
         <br />
           <div>
              <asp:Button class="layui-bg-green" ID="btnImportCourse" runat="server" Text="一键上传" Width="80px" Height="30px" OnClick="btnImport_Click" BorderStyle="None" Font-Size="13pt" />
               &nbsp <asp:Button ID="Button1Course"  class="layui-btn-primary" runat="server" Text="检索内容" Width="80px" Height="30px" OnClick="Button1_Click" />
          </div>
      </div>
    </div>
    <br />
    <div class="importDateQuery">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="courseId" Font-Size="13pt">
            <Columns>
                <asp:BoundField DataField="courseId" HeaderText="课程编号" ReadOnly="True" SortExpression="courseId" />
                <asp:BoundField DataField="courseName" HeaderText="课程名" SortExpression="courseName" />
                <asp:BoundField DataField="semester" HeaderText="学期" SortExpression="semester" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSMPConnectionString %>" SelectCommand="SELECT [courseId], [courseName], [semester] FROM [Course]"></asp:SqlDataSource>
    </div>
  </div>

</asp:Content>
