<%@ Page Title="" Language="C#"  EnableEventValidation="false"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CourseScheddule.aspx.cs" Inherits="CMSProject.CourseScheddule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <br />
        <br />


        <asp:Label ID="Label2" runat="server" style="margin-left:45%;" Font-Bold="True" Font-Size="Large" Text="课程进度"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" style="margin-left:35%;" runat="server" Text="课程名："></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="classGroupName" DataValueField="classGroupNo" Height="29px" Width="134px" ></asp:DropDownList>
     
         
        <%--<asp:TextBox ID="courseName" runat="server"></asp:TextBox>--%>
        <asp:Button ID="Button1" style="margin-left:30px;" runat="server" Text="查询" Width="100px" BackColor="#4D837B"
             BorderStyle="None" ForeColor="White" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" style="margin-left:35%;" Text="学期："></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" style="margin-left:14px;" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged2" Height="29px" Width="134px" DataTextField="courseName" DataValueField="courseName">
        </asp:DropDownList>
        <br />
        <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  style="margin-left:30%;"
             AllowPaging="True" AllowSorting="True" PageSize="2">
            <Columns>
                <asp:BoundField DataField="ClassGroupNo" HeaderText="课群号" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="tchNo" HeaderText="职工号" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="tchName" HeaderText="职工名" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="CName" HeaderText="班级" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="CPNum" HeaderText="班级人数" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="ANum" HeaderText="作业次数" />
                <asp:TemplateField HeaderText="提交人数">
                    <ItemTemplate>
                        <asp:GridView ID="GridView2" runat="server"  AllowPaging="True" AllowSorting="True"  PageSize="2"
                            DataSourceID="CSMPConnectionString">
                           <%-- <Columns>
                                <asp:BoundField DataField="JobNo" HeaderText="作业号" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="" HeaderText="提交人数"  />
                            </Columns>--%>
                        </asp:GridView>
                      <asp:SqlDataSource ID="CSMPConnectionString" runat="server"
                              ConnectionString="<%$ ConnectionStrings:CSMPConnectionString %>"
                              SelectCommand="select JobNo 作业号 ,COUNT(*) 提交人数 from Assignment group by JobNo">
                         </asp:SqlDataSource> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       <%-- <asp:SqlDataSource ID="CSMPConnectionString2" runat="server"
                              ConnectionString="<%$ ConnectionStrings:CSMPConnectionString2 %>"
                              SelectCommand="select * from CS('+ courseName.Text + ')"/>--%>
        <br />
        <br />
        <asp:Button ID="Button2" style="margin-left:610px;" runat="server" Text="导出数据"  Width="150px" 
            BackColor="#487B73" BorderStyle="None" ForeColor="White" OnClick="Button2_Click" />

        <br />
        <br />

</asp:Content>
