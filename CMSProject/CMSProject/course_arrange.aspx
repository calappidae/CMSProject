<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="course_arrange.aspx.cs" Inherits="CMSProject.course_arrange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <style type="text/css">
        .auto-style2 {
            height: 49px;
        }
        .auto-style3 {
            height: 248px;
            width: 60px;
        }
        .auto-style6 {
            width: 793px;
            height: 25px;
        }
        .auto-style18 {
            height: 109px;
            width: 793px;
        }
        .auto-style25 {
            height: 49px;
            width: 764px;
        }
        .auto-style26 {
            height: 248px;
            width: 764px;
        }
        .auto-style28 {
            height: 49px;
            width: 793px;
        }
        .auto-style35 {
            height: 29px;
            width: 793px;
        }
        .auto-style37 {}
        .auto-style38 {}
        .auto-style39 {}
        .auto-style40 {}
        .auto-style42 {}
        .auto-style45 {
            height: 7px;
            width: 793px;
        }
        .auto-style46 {
            width: 793px;
            height: 22px;
        }
        .auto-style47 {
            height: 42px;
            width: 793px;
        }
        .auto-style48 {
            width: 793px;
        }
        .auto-style49 {
            width: 60px;
            height: 49px;
        }
        </style>
   <link href="Style.css" rel="stylesheet" type="text/css" />

   
    <table style="width:100%; height: 597px;">
        <tr>
            <td class="auto-style25">
                <asp:Label ID="Label2" runat="server" Text="学期："></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server"  DataTextField="semester" DataValueField="semester" Height="39px" Width="132px"  DataSourceID="SqlDataSource1" ></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSMPConnectionString2 %>" SelectCommand="SELECT [semester] FROM [Course]"></asp:SqlDataSource>
                <!-- <asp:TextBox ID="samerster" runat="server" Height="19px" placeholder="请输入学期" CssClass="auto-style42" Width="92px"></asp:TextBox> -->
                <asp:Button ID="query" runat="server" style="margin-left:10px; " BackColor="#42867C" ForeColor="White" BorderStyle="None" Text="查询课程信息" OnClick="Button1_Click"  />
                <asp:Button ID="Button1" style="margin-left:20px;" BackColor="#42867C" ForeColor="White" BorderStyle="None" runat="server" Text="查询班级信息" OnClick="Button1_Click1" />
            </td>
            <td class="auto-style49">
                </td>
            <td class="auto-style28">
                <asp:Button ID="tonQuery"  style="margin-left:10px;" BackColor="#42867C" ForeColor="White" BorderStyle="None" runat="server" Text="查询教师信息" OnClick="tonQuery_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26" rowspan="4" style="border-width: thin; border-style: groove; position: static;"   aria-autocomplete="none">
                <asp:GridView ID="GridView1" style="margin-left:15%; margin-top:2%"  AllowPaging="True" runat="server" Width="435px" Height="124px">
                </asp:GridView>
                <asp:Label ID="tishi3"  ForeColor ="#ff0000" runat="server"></asp:Label>
            </td >
            <td class="auto-style3" rowspan="7" style="border-style: none">
                &nbsp;</td>
            <td class="auto-style18" style="border-style: groove; border-width: thin">
                <asp:GridView ID="GridView2" style="margin-left:15%; margin-top:2%"  AllowPaging="True" runat="server" Width="435px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:Label ID="Label3"   style="margin-left:250px" runat="server" Font-Bold="True" Text="安排课程"></asp:Label>
                <asp:Label ID="tishi2"  style="margin-left:70px;" ForeColor="#FD022E" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style45">
                <asp:Label ID="Label6"  style="margin-left:20%;" runat="server" Text="职工号："></asp:Label>
                <asp:TextBox ID="ton" runat="server" placeholder="请输入职工号" CssClass="auto-style40" Width="215px" ></asp:TextBox>
                <asp:Label ID="tonTs" runat="server" ForeColor="#FD022E"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style48">
                <asp:Label ID="Label4"  style="margin-left:20%;"  runat="server" Text="课程号："></asp:Label>
                <asp:TextBox ID="courseId" runat="server" placeholder="请输入课程号" CssClass="auto-style39" Width="215px"></asp:TextBox>
                <asp:Label ID="courseIdTs" runat="server" ForeColor="#FD022E"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style26" rowspan="3" style="border-width: thin; border-style: groove; position: static;">
                <asp:GridView ID="GridView3" style="margin-left:15%; margin-top:2%" AllowPaging="True" runat="server" Width="435px">
                </asp:GridView>
            </td>
            <td class="auto-style46">
                <asp:Label ID="Label5"  style="margin-left:20%;" runat="server" Text="班级号："></asp:Label>
                <asp:TextBox ID="classNum" runat="server" placeholder="请输入班级号" CssClass="auto-style38" Width="215px"></asp:TextBox>
                <asp:Label ID="classNumTs" runat="server" ForeColor="#FD022E"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style47">
                
                <asp:Label ID="Label8" style="margin-left:20%;" runat="server" Text="教学任务："></asp:Label>
                
                <asp:TextBox ID="teach" runat="server" placeholder="请输入教学任务"  Columns="20" TextMode="MultiLine" style="word-wrap:break-word;word-break:break-all;" CssClass="auto-style37" Height="134px" Width="203px" ></asp:TextBox>
                
                <asp:Label ID="tishi" style="margin-left:10px;" runat="server" ForeColor="#FD022E"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="commit"   style="margin-left:240px;" BackColor="#42867C" ForeColor="White" BorderStyle="None" runat="server" Text="提交" OnClick="commit_Click" />
                <asp:Button ID="clear"   style="margin-left:70px;" BackColor="#42867C" ForeColor="White" BorderStyle="None" runat="server" Text="清空" OnClick="clear_Click" />
                </td>
        </tr>
    </table>
         
</asp:Content>

