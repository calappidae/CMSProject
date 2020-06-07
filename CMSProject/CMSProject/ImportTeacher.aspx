<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ImportTeacher.aspx.cs" Inherits="CMSProject.ImportTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div class="imporDateForm">
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
         <legend>导入老师名单</legend>
        </fieldset>
        <div>
            <div class="importDateIn">
               <asp:FileUpload style="color:#FF5722" ID="fulImportTeacher" runat="server" Height="30px" Width="300px" />
            </div>
        <br />
             <div>
                  <asp:Button ID="Button1" class="layui-bg-green" runat="server" Text="一键上传" Width="80px" Height="30px" OnClick="btnImport_Click" Font-Size="13pt" BorderStyle="None" />
                  &nbsp;&nbsp<asp:Button ID="Button2" class="layui-btn-primary" runat="server" Text="检索内容" Width="80px" Height="30px" OnClick="Button1_Click" />
           </div>
            
      </div>
    </div>
    <div class="importDateQuery">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="tchNo" Font-Size="13pt" >
         <Columns>
             <asp:BoundField DataField="tchNo" HeaderText="职工号" ReadOnly="True" SortExpression="tchNo" />
             <asp:BoundField DataField="tchPassword" HeaderText="密码" SortExpression="tchPassword" />
             <asp:BoundField DataField="tchName" HeaderText="姓名" SortExpression="tchName" />
             <asp:BoundField DataField="tchSex" HeaderText="性别" SortExpression="tchSex" />
             <asp:BoundField DataField="tchPhone" HeaderText="电话" SortExpression="tchPhone" />
             <asp:BoundField DataField="tchEmail" HeaderText="邮箱" SortExpression="tchEmail" />
             <asp:BoundField DataField="pwdEmail" HeaderText="邮箱密码" SortExpression="pwdEmail" />
             <asp:BoundField DataField="pwdPhone" HeaderText="电话密码" SortExpression="pwdPhone" />
         </Columns>
     </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CSMPConnectionString2 %>" SelectCommand="SELECT [tchNo], [tchPassword], [tchName], [tchSex], [tchPhone], [tchEmail], [pwdEmail], [pwdPhone] FROM [Teacher]"></asp:SqlDataSource>
     <br />
    </div>
</div>
</asp:Content>
