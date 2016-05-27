<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Changepassword.aspx.cs" Inherits="admin_Changepassword" Title="singhshashtar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family:Tahoma;width:700px;border:solid 1px #d7d4d4;margin-left:auto;margin-right:auto;background-color:#f3f3f3;height:300px;margin-top:8px;color:Black">
 <div style="width:690px;height:25px;margin-top:2px;margin-left:auto;border:solid 1px;margin-right:auto;background-color:#fd6600;color:#dbdbdb;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">Change Password</div>
 <table style="width:600px;height:25px;margin-top:2px;margin-left:auto;margin-right:auto;color:#6d6d6d;font-size:18px;font-family:Tahoma;text-align:left;padding:5px 0 0 5px">
 
  <tr class="tr"><td style="text-align:left" class="style1">Old Password:</td>
 <td class="style1">
     <asp:TextBox ID="txtpwd" runat="server" CssClass="textbox" 
         TextMode="Password" Width="250px"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
         ControlToValidate="txtpwd" ErrorMessage="Please Enter Old  Password" 
         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                                        </td>
  </tr>
  
   <tr class="tr"><td style="text-align:left">New Password:</td>
 <td><asp:TextBox ID="txtnewpwd" runat="server" CssClass="textbox" Width="250px" 
         TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
         ControlToValidate="txtnewpwd" ErrorMessage="Please Enter new   Password" 
         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                                        </td>
 </tr>
 <tr class="tr"><td style="text-align:left">Confirm Password:</td>
 <td><asp:TextBox ID="txtconfirmpwd" runat="server" CssClass="textbox" Width="250px" 
         TextMode="Password"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" 
         runat="server" ControlToCompare="txtnewpwd" ControlToValidate="txtconfirmpwd" 
         ErrorMessage="Password Mismatch" ForeColor="#6D6D6D"></asp:CompareValidator>
                                        </td>
 </tr>
   <tr class="tr"><td style="text-align:left"></td>
 <td>
     <asp:Label ID="msg" runat="server"></asp:Label>
     
      </td>
 </tr>
 
  <tr class="tr"><td style="text-align:left"></td>
 <td>
     <asp:Button ID="btnchange" runat="server" CssClass="but" Text="Change" 
         onclick="btnchange_Click" />
      </td>
 </tr>
 
 </table>
 </div>
</asp:Content>

