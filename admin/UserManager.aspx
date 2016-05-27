<%@ page language="C#" masterpagefile="~/admin/MasterPage.master" autoeventwireup="true" inherits="admin_UserManager, App_Web_n0pp6tlb" title="Shubh Client Panel :: Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="paneladd" runat="server" Height="100%">
        <div style="font-family: Tahoma; width: 780px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; min-height: 200px; height: auto;
            margin-top: 8px; color: Black">
            <div style="width: 690px; min-height: 25px; height: auto; margin-top: 2px; margin-left: auto;
                border: solid 1px; margin-right: auto; background-color: #fd6600; color: #dbdbdb;
                font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                Add User</div>
            <table style="width: 600px; min-height: 25px; height: auto; margin-top: 2px; margin-left: auto;
                margin-right: auto; color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left;
                padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddType" runat="server" Width="250px" AutoPostBack="false">
                            <asp:ListItem Selected="True" Value="0">Select Type</asp:ListItem>
                            <asp:ListItem Value="Staff">Staff</asp:ListItem>
                            <asp:ListItem Value="Client">Client</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Acc. ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtACCID" runat="server" CssClass="textbox" Width="250px" Text="0000000000"
                            MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtACCID"
                            ErrorMessage="Please Enter Acc. ID" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        UserName:
                    </td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"
                            ErrorMessage="Please Enter UserName" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Password:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtpwd" runat="server" CssClass="textbox" TextMode="Password" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpwd"
                            ErrorMessage="Please Enter Password" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtemail"
                            ErrorMessage="Please Enter EmailID" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                            ErrorMessage="Please Enter Valid Email-Address" ForeColor="#6D6D6D" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Label ID="msg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Button ID="btnadd" runat="server" CssClass="but" Text="Add" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelshow" runat="server">
        <div style="font-family: Tahoma; min-width: 780px; width: auto; border: solid 1px #d7d4d4;
            margin-left: auto; margin-right: auto; background-color: #f3f3f3; min-height: 200px;
            height: auto; margin-top: 8px">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageIndex="10">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10px" />
                        <HeaderTemplate>
                            Sl. No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Member Id</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("MemberID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            User Name</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("UserName")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Password</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Password")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            E-Mail</HeaderTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Email")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Acc. ID</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("ACCID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Type</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Type")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemStyle Width="250px" />
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" CssClass="textbox" Text="Edit" CommandName="EditText"
                                CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btndelete" runat="server" CssClass="textbox" Text="Delete" CommandName="DeleteText"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('Record will be completely removed. Are you sure,you want to delete this record?');" />
                            <asp:Button ID="btnactive" runat="server" CssClass="textbox" Text="Active" CommandName="active"
                                CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnstatus" runat="server" CssClass="textbox" Text="Deactive" CommandName="Deactive"
                                CommandArgument='<%#Eval("ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="paneledit" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 780px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; min-height: 200px; height: auto;
            margin-top: 8px; color: Black">
            <div style="width: 690px; height: 25px; margin-top: 2px; margin-left: auto; border: solid 1px;
                margin-right: auto; background-color: #fd6600; color: #dbdbdb; font-size: 18px;
                font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                Edit User</div>
            <table style="width: 600px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
                color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddUpType" runat="server" Width="250px">
                            <asp:ListItem Value="0">Select Type</asp:ListItem>
                            <asp:ListItem>Staff</asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Acc. ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtuACCID" runat="server" CssClass="textbox" Width="250px" Text="0000000000"
                            MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtuACCID"
                            ErrorMessage="Please Enter Acc. ID" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        UserName:
                    </td>
                    <td>
                        <asp:TextBox ID="txtupuname" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtupuname"
                            ErrorMessage="Please Enter UserName" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Password:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtuppassword" runat="server" CssClass="textbox" TextMode="Password"
                            Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtuppassword"
                            ErrorMessage="Please Enter Password" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtupemail" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtupemail"
                            ErrorMessage="Please Enter Valid Email-Address" ForeColor="#6D6D6D" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Label ID="lblUMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Button ID="btnupdate" runat="server" CssClass="but" Text="Update" OnClick="btnupdate_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
