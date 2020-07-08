<%@ Page Title="" Language="C#" MasterPageFile="~/stuMaster.Master" AutoEventWireup="true" CodeBehind="ViewDownLoad.aspx.cs" Inherits="CMSProject.ViewDownLoad" %>
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
          
            <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                 <br />
                 作业名：<%#((System.Data.DataRowView)Container.DataItem)["assignmentName"]%><br />
                 作业内容：<%#((System.Data.DataRowView)Container.DataItem)["assignmentContent"]%><br />
                 截至时间：<%#((System.Data.DataRowView)Container.DataItem)["aaDealTime"]%><br /><br />
                 附件：<asp:LinkButton style="color:#5FB878" ID="LinkButton2" runat="server" OnCommand="LinkButton1_Click" CommandArgument='<%#((System.Data.DataRowView)Container.DataItem)["assignmentSubFilePath"]%>'><%#((System.Data.DataRowView)Container.DataItem)["assignmentSubFileName"]%></asp:LinkButton>
                  <br />
                  <hr />
                
             <br />
            </ItemTemplate>

           </asp:Repeater>
        </div>
        <%-- <input id="UpLoad" type="file" runat="server" style="color:#3BD9FF" />
                 <br /><br />
                 <asp:Button  class="layui-bg-green" runat="server" Text="上传文件" ID="btnUpLoad" OnClick="btnUpLoad_Click" Font-Size="13pt" />
                 <br /><br /><br />--%>
    </div>
</asp:Content>
