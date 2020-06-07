<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ImportStudent.aspx.cs" Inherits="CMSProject.ImportStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div class="imporDateForm">
         <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
           <legend>导入学生名单</legend>
        </fieldset>
        <div>
             <div class="importDateIn">
                <asp:FileUpload ID="fulImportStudent" runat="server" Height="30px" Width="300px" style="color:#FF5722"/>
             </div>
             <br />
           <div>
              <asp:Button class="layui-bg-green" ID="btnImportStudent" runat="server" Text="一键上传" Width="80px" Height="30px" OnClick="btnImport_Click" BorderStyle="None" Font-Size="13pt" />
               &nbsp <asp:Button ID="Button1Studnet" runat="server" Text="检索内容" Width="80px" Height="30px" OnClick="Button1_Click" />
           </div>
       
        </div>
    </div>
    <br />
    <div class="importDateQuery">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="stuNo" Font-Size="13pt">
            <Columns>
                <asp:BoundField DataField="stuNo" HeaderText="学号" ReadOnly="True" SortExpression="stuNo" />
                <asp:BoundField DataField="passWord" HeaderText="密码" SortExpression="passWord" />
                <asp:BoundField DataField="stuName" HeaderText="姓名" SortExpression="stuName" />
                <asp:BoundField DataField="stuGrade" HeaderText="年级" SortExpression="stuGrade" />
                <asp:BoundField DataField="stuSex" HeaderText="性别" SortExpression="stuSex" />
                <asp:BoundField DataField="stuPhone" HeaderText="电话" SortExpression="stuPhone" />
                <asp:BoundField DataField="stuEmail" HeaderText="邮箱" SortExpression="stuEmail" />
                <asp:BoundField DataField="pwdEmail" HeaderText="邮箱密码" SortExpression="pwdEmail" />
                <asp:BoundField DataField="pwdPhone" HeaderText="电话密码" SortExpression="pwdPhone" />
                <asp:BoundField DataField="classNo" HeaderText="班级编号" SortExpression="classNo" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CSMPConnectionString2 %>" SelectCommand="SELECT [stuNo] 学号, [passWord] 密码, [stuName] 姓名, [stuGrade] 年级, [stuSex] 性别, [stuPhone] 电话, [stuEmail] 邮箱, [pwdEmail] 邮箱密码 , [pwdPhone] 电话密码, [classNo] 班级编号 FROM [Student]"></asp:SqlDataSource>
    </div>
 </div>
</asp:Content>
