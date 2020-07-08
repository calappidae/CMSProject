<%@ Page Title="" Language="C#" MasterPageFile="~/stuMaster.Master" AutoEventWireup="true" CodeBehind="CancelAssignment.aspx.cs" Inherits="CMSProject.CancelAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br /><br />
    <div>
         <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
             <legend>已发布的作业</legend>
         </fieldset>
      
           <div>
              <label class="layui-form-label" style="font-size: 20px">课 群:</label>
              <div class="layui-input-block">
                 <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="classGroupName" DataValueField="classGroupNo" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Height="29px" Width="134px" ></asp:DropDownList>
                 <!-- <asp:TextBox ID="TextBox1" runat="server" Height="34px"></asp:TextBox> -->
                 
          </div>
               <br />
               <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
               <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
           <br />
          
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                 <br />
                 作业名：<%#((System.Data.DataRowView)Container.DataItem)["assignmentName"]%><br />
                 作业内容：<%#((System.Data.DataRowView)Container.DataItem)["assignmentContent"]%><br />
                 截至时间：<%#((System.Data.DataRowView)Container.DataItem)["aaDealTime"]%><br /><br />
                 附件：<asp:Label ID="Label3" runat="server" style="color:#5FB878" Text="">  
                           <%#((System.Data.DataRowView)Container.DataItem)["assignmentSubFileName"]%>
                         </asp:Label>
                <br /><br />
                
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                 <asp:Button runat="server" ID="btnDeleteFile" OnCommand="Button1_Click" class="layui-bg-green" Width="100px" Height="35px" BorderStyle="None" Font-Size="13pt" Text="撤回" CommandArgument='<%#((System.Data.DataRowView)Container.DataItem)["ANo"]%>' style="margin-left:-70px;background:green;color:white"  CssClass="cssHide" CommandName="Delete"/>
                  <br />
                
                  <hr />
            </ItemTemplate>
           </asp:Repeater>
        </div>
     
    </div>
</asp:Content>
