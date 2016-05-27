<%@ Page Title="Client Login" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ClientLogin.aspx.cs" Inherits="ClientLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
        margin-right: auto; background-color: #ffffff; height: 250px; margin-top: 80px;
        color: Black">
        <center>
            <h2>
                Client Login</h2>
        </center>
        <table style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;
            margin-top: 40px">
            <tr>
                <td rowspan="9" style="width: 180px" valign="top">
                    <img src="image/LoginIcon.png" alt="" width="131px" height="125px" />
                </td>
            </tr>
            <tr>
                <td>
                    UserName:
                </td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"
                        ErrorMessage="Enter Username" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="textbox" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"
                        ErrorMessage="Enter Password" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" CssClass="button" Text="Login" 
                        onclick="btnLogin_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
            <td colspan="3">
            Forgotten your password? <a href="PasswordReminder.aspx" >Request a Password Reminder by clicking here.</a>
            </td>
            </tr>
        </table>
    </div>
</asp:Content>
