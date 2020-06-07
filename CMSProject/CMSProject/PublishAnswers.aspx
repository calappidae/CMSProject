<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="PublishAnswers.aspx.cs" Inherits="CMSProject.PublishAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div>
         <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
         <legend>发布答案</legend>
        </fieldset>
        <br />
         <div>
               <label class="layui-form-label" >课 群:</label>
                <div class="layui-input-block">
                    <asp:DropDownList ID="DropDownList1"  name="cgNoo" runat="server" DataTextField="classGroupName" DataValueField="classGroupNo" Height="30px" Width="163px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" >
                </asp:DropDownList>                                                    
                </div>
             </div>
         <div><br />
               <label class="layui-form-label" >作业名:</label>
                <div >
                       <asp:DropDownList ID="DropDownList2" runat="server"  DataTextField="assignmentName" DataValueField="JobNo" Height="30px" Width="161px">
                 </asp:DropDownList>
               </div>
               <script runat="server">
                  
               </script>
              </div>
            <br />
        <div>
               <label class="layui-form-label">答案内容:</label>
                <div class="layui-input-block">
                     <asp:TextBox ID="tbAnswerContent" runat="server" TextMode="MultiLine" Height="56px" Width="156px"></asp:TextBox>
                </div>
              </div>
       </div>
                <br />
          <div class="layui-input-block" style="margin-left:1%;">

                <!-- <asp:Button  ID="Button3" class="layui-btn" runat="server" Text="查询课群" OnClick="Button3_Click1" /> -->&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1"  class="layui-btn"  runat="server" Text="提交" OnClick="btnCommit_Click"  />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button2" class="layui-btn layui-btn-primary" runat="server" Text="重置" OnClick="btnReset_Click"  />
          </div>
     </div>
</asp:Content>
