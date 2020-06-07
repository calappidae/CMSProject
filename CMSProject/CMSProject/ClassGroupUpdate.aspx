<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="ClassGroupUpdate.aspx.cs" Inherits="CMSProject.ClassGroupUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
             <legend>修改课程</legend>
         </fieldset>
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="课群编号" AutoGenerateColumns="False" AutoGenerateEditButton="True" DataSourceID="SqlDataSource1" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="13pt" Font-Underline="False" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="课群编号" HeaderText="课群编号" ReadOnly="True" SortExpression="课群编号" />
            <asp:BoundField DataField="课群名" HeaderText="课群名" SortExpression="课群名" />
            <asp:BoundField DataField="课群介绍" HeaderText="课群介绍" SortExpression="课群介绍" />
            <asp:BoundField DataField="班级" HeaderText="班级" ReadOnly="True" SortExpression="班级" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-IEL2RIR;Initial Catalog=CSMP;User ID=sa;Password=123456" ProviderName="System.Data.SqlClient" SelectCommand="SELECT classGroupNo as 课群编号, classGroupName as 课群名, cgInfo as 课群介绍,Class.className as 班级
FROM ClassGroup,Class where ClassGroup.classNo=Class.classNo" UpdateCommand="update ClassGroup set classGroupName=@课群名,cgInfo=@课群介绍 where classGroupNo=@课群编号">
        <UpdateParameters>
            <asp:Parameter Name="课群名" />
            <asp:Parameter Name="课群介绍" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
