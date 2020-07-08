<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="ScoreEnterResults.aspx.cs" Inherits="CMSProject.ScoreEnterResults" %>
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
          </div><br />
          <div>
              <label class="layui-form-label" style="font-size: 20px">作业:</label>
              <div class="layui-input-block">
                 <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="assignmentName" DataValueField="JobNo" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged2" Height="29px" Width="134px" ></asp:DropDownList>
          </div>
           <br />
          
            <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="rptUpLoad_ItemCommand">
            <ItemTemplate>
                 <br />
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                作业名：<%#((System.Data.DataRowView)Container.DataItem)["assignmentName"]%><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          
                作业者：<%#((System.Data.DataRowView)Container.DataItem)["stuName"]%><br />
                <br />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                附件：<asp:LinkButton style="color:#5FB878" ID="LinkButton2" runat="server" OnCommand="LinkButton1_Click" CommandArgument='<%#((System.Data.DataRowView)Container.DataItem)["assignmentSubFilePath"]%>'><%#((System.Data.DataRowView)Container.DataItem)["assignmentSubFileName"]%></asp:LinkButton>
                <br /> 

                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 已提交人数：<%#((System.Data.DataRowView)Container.DataItem)["sum"]%> &nbsp; &nbsp;|&nbsp; &nbsp;
                 分数：<asp:TextBox ID="tbAssingmentScore" runat="server" style="width:50px"></asp:TextBox>
                   &nbsp; &nbsp;|&nbsp; &nbsp;
                 评价：<asp:TextBox ID="tbAssingmentmark" runat="server" style="width:100px;height:20px;margin-bottom:-5px" TextMode="MultiLine"></asp:TextBox>
                 <br />
               
                 <br />
                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="" style="color:red"></asp:Label>
                 <br /><br />
                 <asp:Button runat="server" ID="btnDeleteFile" class="layui-bg-green" Width="100px" Height="35px" BorderStyle="None" Font-Size="13pt" Text="提交" CommandArgument='<%#((System.Data.DataRowView)Container.DataItem)["ANo"]%>' style="margin-left:40px;background:green;color:white"  CssClass="cssHide" CommandName="Submit"/>
                  
                  <hr />
                
             <br />
            </ItemTemplate>

           </asp:Repeater>
        </div>
    </div>
</asp:Content>
