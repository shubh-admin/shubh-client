<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shubh Hosting :: Admin Panel</title>
    <link href="../css/index.css" rel="stylesheet" type="text/css">
</link>
</head>
<body bgcolor="#f3f3f3">
    <p>
&nbsp;&nbsp;&nbsp;
    </p>
    <form id="form1" runat="server">
     <div style="font-family:Tahoma;width:700px;border:solid 1px #d7d4d4;margin-left:auto;margin-right:auto;background-color:#ffffff;height:250px;margin-top:80px;color:Black">
    
         <table style="margin-bottom:auto;margin-left:auto;margin-right:auto;margin-top:auto;margin-top:40px">
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td rowspan="6" style="width:180px">
                     <img src="../image/login_icon.jpg" /></td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     UserName:</td>
                 <td>
                     <asp:TextBox ID="txtusername" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                 </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="txtusername" ErrorMessage="Enter Username" 
                         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                 </td>
             </tr>
             <tr>
                 <td>
                     Password:</td>
                 <td>
                     <asp:TextBox ID="txtpassword" runat="server" CssClass="textbox" Width="200px" 
                         TextMode="Password"></asp:TextBox>
                 </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="txtpassword" ErrorMessage="Enter Password" 
                         ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                 </td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     <asp:Button ID="Button1" runat="server" CssClass="textbox" Text="Login" 
                         onclick="Button1_Click" />
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             
         </table>
    
     </div>
    </form>
</body>
</html>
