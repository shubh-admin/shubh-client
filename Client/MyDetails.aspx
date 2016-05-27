<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MyDetails.aspx.cs" Inherits="Client.MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p class="breadcrumb">
        <asp:Label ID="lblBreadCrumb" runat="server" Text="Mydetails" />
    </p>
    <div class="contentbox">
        <asp:Label ID="lblSubMenu" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="pnlMyDetails" runat="server">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 450px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    My Details</h2>
            </center>
            <table style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;
                margin-top: 40px">
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Acc. ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtACCID" runat="server" ForeColor="Red" CssClass="textbox" Width="200px"
                            Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="80" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Enter Name" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        User Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" ForeColor="Red" runat="server" CssClass="textbox" Width="200px"
                            Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Enter Email" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Please Enter Valid Email-Address" CssClass="ErrorMsg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Address 1:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox" Width="200px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Address 2:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox" Width="200px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        City/State/Region:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" Width="200px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Country :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox" Text="India" Width="200px"
                            MaxLength="100"></asp:TextBox>
                    </td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCountry"
                        ErrorMessage="Enter Country" CssClass="ErrorMsg""></asp:RequiredFieldValidator><td>
                        </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Phone :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox" Width="200px" MaxLength="20"></asp:TextBox>
                    </td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="Enter Phone" CssClass="ErrorMsg"></asp:RequiredFieldValidator><td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone"
                                ErrorMessage="Please Enter Valid Phone No." ValidationExpression="[0-9]*" CssClass="ErrorMsg"></asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblDetMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSaveDetails" runat="server" CssClass="button" 
                            Text="Save Changes" onclick="btnSaveDetails_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlChangePassword" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 250px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    Change Password</h2>
            </center>
            <table style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;
                margin-top: 40px">
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Existing Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" ForeColor="Red" CssClass="textbox" Width="200px"
                            TextMode="Password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPass"
                            ErrorMessage="Enter Password" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        New Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNPass" runat="server" ForeColor="Red" CssClass="textbox" Width="200px"
                            TextMode="Password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNPass"
                            ErrorMessage="Enter New Password" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CValNewPass" runat="server" CssClass="ErrorMsg" ErrorMessage="Existing Password and New Password should be different."
                            ControlToCompare="txtPass" ControlToValidate="txtNPass" Display="Dynamic" Operator="NotEqual"
                            SetFocusOnError="True"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Confirm New Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPass" runat="server" ForeColor="Red" CssClass="textbox"
                            Width="200px" TextMode="Password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNPass"
                            ErrorMessage="Confirm New Password" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="ErrorMsg" ErrorMessage="The passwords you entered did not match."
                            ControlToCompare="txtNPass" ControlToValidate="txtConfirmPass" Display="Dynamic"
                            Operator="Equal" SetFocusOnError="True"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblPassMsg" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSavePass" runat="server" CssClass="button" 
                            Text="Save Changes" onclick="btnSavePass_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
