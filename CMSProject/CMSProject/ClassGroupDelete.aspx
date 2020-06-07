<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="ClassGroupDelete.aspx.cs" Inherits="CMSProject.ClassGroupDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
             <legend>删除课群</legend>
         </fieldset>
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Italic="False" Font-Size="13pt" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="课群编号" HeaderText="课群编号" SortExpression="课群编号" />
            <asp:BoundField DataField="课群名" HeaderText="课群名" SortExpression="课群名" />
            <asp:BoundField DataField="课群介绍" HeaderText="课群介绍" SortExpression="课群介绍" />
            <asp:BoundField DataField="班级" HeaderText="班级" SortExpression="班级" />
            <asp:ButtonField CommandName="Selt" HeaderText="删除" ShowHeader="True" Text="删除" />
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
</asp:Content>
