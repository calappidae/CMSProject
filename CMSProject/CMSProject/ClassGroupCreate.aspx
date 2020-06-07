<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="ClassGroupCreate.aspx.cs" Inherits="CMSProject.ClassGroupCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <br />
        <div>
         <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
             <legend>创建课群</legend>
         </fieldset>
             <div>
               <label class="layui-form-label" >课群名:</label>
                <div class="layui-input-block">
                      <asp:TextBox ID="tbClassGroupName" runat="server" Height="34px"></asp:TextBox>
                </div>
              </div>
        <br />
             <div>
               <label class="layui-form-label" >班 级:</label>
                <div class="layui-input-block">
                    <asp:DropDownList ID="DropDownList3" runat="server"  DataTextField="className" DataValueField="classNo" Height="32px" Width="122px">
                </asp:DropDownList>
               
                </div>
             </div>
             <div>
                 <br />
               <label class="layui-form-label">课群简介:</label>
                <div class="layui-input-block">
                     <asp:TextBox ID="tbClassGroupInfo" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
              </div>
         <div class="layui-form-item">
             <div class="layui-input-block" style="margin-left:1%">
                  <!-- <asp:Button  ID="Button3" class="layui-btn" runat="server" Text="检索班级" OnClick="Button3_Click1" /> -->
                 &nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1"  class="layui-btn"  runat="server" Text="提交" OnClick="btnCommit_Click"  />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp<asp:Button ID="Button2" class="layui-btn layui-btn-primary" runat="server" Text="重置" OnClick="btnReset_Click"  />
                 
             </div>
             <asp:Label ID="Label1" style="color:red" runat="server" Text=""></asp:Label>
     </div>

 </div>

</asp:Content>
