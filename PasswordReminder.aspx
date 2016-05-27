<%@ page title="" language="C#" masterpagefile="~/MainMaster.master" autoeventwireup="true" inherits="PasswordReminder, App_Web_abw5qgoe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
        margin-right: auto; background-color: #ffffff; height: 250px; margin-top: 80px;
        color: Black">
        <center>
            <h2>
                Password Reminder</h2>
        </center>
        <table style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;
            margin-top: 40px">
            <tr>
                <td rowspan="9" style="width: 180px" valign="top">
                    <img src="image/PasswordReminder.png" alt="" />
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
                    <asp:Button ID="btnRemind" runat="server" CssClass="button" Text="Remind" 
                        onclick="btnRemind_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
