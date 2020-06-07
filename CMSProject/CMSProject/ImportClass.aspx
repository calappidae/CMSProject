<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ImportClass.aspx.cs" Inherits="CMSProject.ImportClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div class="imporDateForm">
         <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
         <legend>导入班级</legend>
        </fieldset>
       <div>
           <div class="importDateIn">
            <asp:FileUpload style="color:#FF5722" ID="fulImportClass" runat="server" Height="30px" Width="300px" />
           </div>
           <br />
           <div>
              <asp:Button ID="btnImportClass" class="layui-bg-green"  runat="server" Text="一键上传" Width="80px" Height="30px" OnClick="btnImport_Click" BorderStyle="None" Font-Size="13pt" />
               &nbsp <asp:Button ID="Button1Course" class="layui-btn-primary" runat="server" Text="检索内容" Width="80px" Height="30px" OnClick="Button1_Click" />
           </div>
         </div>
      </div>
    <br />
    <div class="importDateQuery">
        <asp:GridView ID="GridView1" runat="server" Font-Size="13pt" AutoGenerateColumns="False" DataKeyNames="classNo">
            <Columns>
                <asp:BoundField DataField="classNo" HeaderText="班级编号" ReadOnly="True" SortExpression="classNo" />
                <asp:BoundField DataField="className" HeaderText="班级名" SortExpression="className" />
                <asp:BoundField DataField="ClassPNum" HeaderText="人数" SortExpression="ClassPNum" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSMPConnectionString %>" SelectCommand="SELECT [classNo], [className] FROM [Class]"></asp:SqlDataSource>
    </div>
  </div>
</asp:Content>
