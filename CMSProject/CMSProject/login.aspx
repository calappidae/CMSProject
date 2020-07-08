<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ruanjiangongchen.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            height: 252px;
        }
        .auto-style5
        {
            height: 49px;
        }
        .auto-style6
        {
            height: 39px;
        }
        .auto-style7
        {
            height: 48px;
        }
        .auto-style9
        {
            height: 33px;
        }
        .auto-style10
        {
            height: 42px;
        }
        .auto-style11
        {
            height: 29px;
        }
    </style>
</head>
<body style="height: 321px;background:url(image/loginbk.jpg)" >
    <br /><br /><br /><br /><br /><br /><br />
    <div>
    <form id="form1" runat="server" >
       <table align="center" border="0" class="auto-style1" style="width:28%;background:url(image/1.jpg);background-repeat:no-repeat;background-size:100% 100%;">
            <tr>
                <td class="auto-style7" style="text-align: center; font-size: 30px; font-family: 楷体; ">作业管理系统</td>
            </tr>
            <tr>
                <td class="auto-style9" style="text-align:center;">用户名：<asp:TextBox ID="TextBox1" runat="server" Width="190px" placeholder="用户名/邮箱/手机号"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="text-align:center;">&nbsp;&nbsp; 密 码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="190px" placeholder="请输入密码"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="text-align:center">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="391px">
                        <asp:ListItem Value="0">教学秘书</asp:ListItem>
                        <asp:ListItem Value="1">教师</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">学生</asp:ListItem>
                        <asp:ListItem Value="3">管理员</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label3" style="margin-left:40px;" runat="server" ForeColor="#FD022E"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" style="margin-left: 25px" Width="100px" BackColor="#D0E4CC" BorderStyle="None" />
                    <asp:Button ID="Button2" runat="server" style="margin-left: 65px" Text="重置" OnClick="Button2_Click" Width="100px" BackColor="#D0E4CC" BorderStyle="None" />
                </td>
            </tr>
        </table>
    </form>
   </div>
</body>
</html>
