<%@ Page Title="" Language="C#" MasterPageFile="~/tchMaster.Master" AutoEventWireup="true" CodeBehind="AssignJob.aspx.cs" Inherits="CMSProject.AssignJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
     <div>
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 50px;">
         <legend>布置作业</legend>
        </fieldset>
         <div>
            
               <label class="layui-form-label" >课 群:</label>
                <div class="layui-input-block">
                        <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="classGroupName" DataValueField="classGroupNo" Height="34px" Width="148px">
                      </asp:DropDownList>
                </div>
             </div><br />
         <div>
               <label class="layui-form-label" >作业名:</label>
                <div class="layui-input-block">
                      <asp:TextBox ID="tbAssignmentName" runat="server" Height="34px"></asp:TextBox>
                </div>
              </div>
         <br />
           <div>
               <label class="layui-form-label">作业内容:</label>
                <div class="layui-input-block">
                     <asp:TextBox ID="tbAssignmentContent" runat="server" TextMode="MultiLine" Height="56px" Width="156px"></asp:TextBox>
                </div>
              </div>
         <div class="layui-inline">
                <label class="layui-form-label">截至时间:</label>
                <div class="layui-input-inline">
                  <input type="text" name="DealTime"class="layui-input" id="test1" placeholder="yyyy-MM-dd HH:mm:ss"/>
               </div>
          </div>
         <br />
         
        <br />
          <div class="layui-input-block" style="margin-left:1%">
                <!-- <asp:Button  ID="Button3" class="layui-btn" runat="server" Text="查询课群" OnClick="Button3_Click1" /> -->&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1"  class="layui-btn"  runat="server" Text="提交" OnClick="btnCommit_Click"  />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button2" class="layui-btn layui-btn-primary" runat="server" Text="重置" OnClick="btnReset_Click"  />
          </div>
    </div>
    <script>
        layui.use('laydate', function () {
            var laydate = layui.laydate;
            //执行一个laydate实例
            laydate.render({
                elem: '#test1' //指定元素
                 , type: 'datetime'
            });
        });
</script>
</asp:Content>
