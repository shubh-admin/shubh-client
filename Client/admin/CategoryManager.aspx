<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryManager.aspx.cs" Inherits="Client.admin.AdminCategoryManager" Title="singhshashtar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="paneladd" runat="server">
    <div style="font-family:Tahoma;width:700px;border:solid 1px #d7d4d4;margin-left:auto;margin-right:auto;background-color:#f3f3f3;height:150px;margin-top:8px;color:Black">
 <div style="width:690px;height:25px;margin-top:2px;margin-left:auto;border:solid 1px ;margin-right:auto;background-color:#fd6600;color:#dbdbdb;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">
     Add Category</div>
 <table style="width:600px;height:25px;margin-top:2px;margin-left:auto;margin-right:auto;color:#6d6d6d;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">
 <tr class="tr"><td style="text-align:left">Category Name:</td>
 <td><asp:TextBox ID="txtcategory" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
         ControlToValidate="txtcategory" ErrorMessage="Please Enter CategoryName" 
         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                                        </td>
 </tr>

   <tr class="tr"><td style="text-align:left"></td>
 <td>
     <asp:Label ID="msg" runat="server"></asp:Label>
     
      </td>
 </tr>
 
  <tr class="tr"><td style="text-align:left"></td>
 <td>
     <asp:Button ID="btnadd" runat="server" CssClass="but" Text="Add" 
         onclick="btnadd_Click" />
      </td>
 </tr>
 
 </table>
 </div>
 
 </asp:Panel>
 
   <asp:Panel ID="panelshow" runat="server">
 <div style="font-family:Tahoma;width:500px;border:solid 1px #d7d4d4;margin-left:auto;margin-right:auto;background-color:#f3f3f3;height:150px;margin-top:8px">

     <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
         GridLines="None" AutoGenerateColumns="false" DataKeyNames="ID" 
         onrowcommand="GridView1_RowCommand" AllowPaging="True" 
         onpageindexchanging="GridView1_PageIndexChanging" PageIndex="10" >
        
         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <RowStyle BackColor="#E3EAEB" />
         <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
         <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <EditRowStyle BackColor="#7C6F57" />
         <AlternatingRowStyle BackColor="White" />
         <Columns>
         <asp:TemplateField>
                 <ItemStyle Width="50px" HorizontalAlign="Left"/>
                 <HeaderStyle HorizontalAlign="Left"/>
           <HeaderTemplate>S.No.</HeaderTemplate>
    <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>
         </asp:TemplateField>
         
          <asp:TemplateField>
                 <HeaderStyle HorizontalAlign="Left"/>
           <HeaderTemplate>Category Name</HeaderTemplate>
           <ItemStyle Width="200px" HorizontalAlign="Left"/>
          <ItemTemplate><%#Eval("CategoryName")%></ItemTemplate>
         </asp:TemplateField>
        
         <asp:TemplateField>
                 
           <HeaderTemplate>Action</HeaderTemplate>
           <ItemStyle Width="250px"/>
          <ItemTemplate>
          <asp:Button ID="btnedit" runat="server" CssClass="textbox" Text="Edit" CommandName="EditText" CausesValidation="false"  CommandArgument='<%#Eval("ID")%>'/>
            <asp:Button ID="btndelete" runat="server" CssClass="textbox" Text="Delete" CausesValidation="false" CommandName="DeleteText" CommandArgument='<%#Eval("ID")%>'/>
           
          
          </ItemTemplate>
         </asp:TemplateField>
         </Columns>
         
     </asp:GridView>
 </div></asp:Panel>
 
 
  <asp:Panel ID="paneledit" runat="server" Visible="false">
    <div style="font-family:Tahoma;width:700px;border:solid 1px #d7d4d4;margin-left:auto;margin-right:auto;background-color:#f3f3f3;height:150px;margin-top:8px;color:Black">
 <div style="width:690px;height:25px;margin-top:2px;margin-left:auto;border:solid 1px ;margin-right:auto;background-color:#fd6600;color:#dbdbdb;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">
     Edit Category</div>
 <table style="width:600px;height:25px;margin-top:2px;margin-left:auto;margin-right:auto;color:#6d6d6d;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">
 <tr class="tr"><td style="text-align:left">Category Name:</td>
 <td><asp:TextBox ID="txtupcategory" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
         ControlToValidate="txtupcategory" ErrorMessage="Please Enter CategoryName" 
         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                                        </td>
 </tr>

   <tr class="tr"><td style="text-align:left"></td>
 <td>
     <asp:Label ID="Label1" runat="server"></asp:Label>
     
      </td>
 </tr>
 
  <tr class="tr"><td style="text-align:left" class="style1"></td>
 <td class="style1">
     <asp:Button ID="btnupdate" runat="server" CssClass="but" Text="Update" 
         onclick="btnupdate_Click" />
      </td>
 </tr>
 
 </table>
 </div>
 
 </asp:Panel>
</asp:Content>

