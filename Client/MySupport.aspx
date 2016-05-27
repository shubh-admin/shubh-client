<%@ Page Title="My Support" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="MySupport.aspx.cs" Inherits="Client.MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="js/main.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p class="breadcrumb">
        <asp:Label ID="lblBreadCrumb" runat="server" Text="Mydetails" />
    </p>
    <div class="contentbox">
        <asp:Label ID="lblSubMenu" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="pnlMyTickets" runat="server">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: auto; min-height: 500px;
            margin-top: 10px; color: Black">
            <br />
            <center>
                <h2>
                    My Support</h2>
            </center>
            <br />
            <asp:Label ID="lblRows" runat="server" />
            <br />
            <asp:GridView ID="gvSupport" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvSupport_PageIndexChanging"
                PageSize="5" Width="100%" CssClass="mGrid" OnRowCommand="gvSupport_RowCommand">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <PagerStyle BackColor="Green" ForeColor="White" HorizontalAlign="Right" CssClass="pgr" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="Green" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30px" />
                        <HeaderTemplate>
                            Sl. No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Issue ID</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("TICKETID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Issue Date</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("CREATEDDATE", "{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Prioriy</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("PRIORITY")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Update Date</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("UPDATEDDATE", "{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Department</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("Department")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Last Replied By</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("STAFF NAME")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Subject</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Subject")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Status</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Status")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btnRead" runat="server" CssClass="textboxlink" Text="View" CommandName="Read"
                                CommandArgument='<%#Eval("ID")%>' />
                            |
                            <asp:LinkButton ID="btnReopen" runat="server" CssClass="textboxlink" Text="Reopen"
                                CommandName="Reopen" CommandArgument='<%#Eval("ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRaise" runat="server" CssClass="button" Text="Raise Ticket" OnClick="btnRaise_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRaiseTicket" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 750px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    Raise Ticket</h2>
            </center>
            <table style="margin-bottom: auto; margin-left: auto; margin-right: auto; margin-top: auto;
                margin-top: 40px">
                <tr>
                    <td align="left">
                        Department:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbDept" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal"
                            RepeatColumns="2" Width="250px">
                            <asp:ListItem Selected="True" Text="Support" Value="Support" />
                            <asp:ListItem Text="Billing" Value="Billing" />
                            <asp:ListItem Text="Sales" Value="Sales" />
                            <asp:ListItem Text="VPS" Value="VPS" />
                            <asp:ListItem Text="Dedicated Server" Value="Dedicated Server" />
                            <asp:ListItem Text="Affiliation" Value="Affiliation" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Priority:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriority" runat="server" Width="250px">
                            <asp:ListItem Selected="True" Text="Low" Value="Low" />
                            <asp:ListItem Text="Medium" Value="Medium" />
                            <asp:ListItem Text="High" Value="High" />
                            <asp:ListItem Text="Urgent" Value="Urgent" />
                            <asp:ListItem Text="Emergency" Value="Emergency" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Please provide Relevant Panel Details:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPanelDetail" runat="server" CssClass="textbox" MaxLength="300"
                            TextMode="MultiLine" Width="250px" Height="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPanelDetail"
                            ErrorMessage="Provide Panel Details" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Acc. ID / Member ID :
                    </td>
                    <td>
                        <asp:TextBox ID="txtACCID" ForeColor="Red" runat="server" CssClass="textbox" Width="250px"
                            MaxLength="10" Enabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Subject:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="250px" MaxLength="200"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Subject is required." CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Query :
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" Width="250px" Height="150px"
                            CssClass="textbox" BorderColor="#fff" />

                        <script type="text/javascript">
                            var config = { toolbar:
            [
            ['Bold', 'Italic', 'Link', 'Unlink', 'Font', 'FontSize']
            ]
                            };
                            var textbox = document.getElementById('<%= txtQuery.ClientID %>');
                            CKEDITOR.replace(textbox, config);
                        </script>

                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuery"
                            ErrorMessage="Provide Query " CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
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
                        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlReadTickets" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 650px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    Read Ticket</h2>
            </center>
            <div class="Message">
                <asp:Label ID="lblMessage" runat="server" /></div>
            <table width="95%">
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="btnBack" runat="server" CssClass="textboxlink" Text="Back to Support"
                            OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlReopen" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 480px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    Reopen Ticket</h2>
            </center>
            <table width="100%">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReopen"
                            ErrorMessage="Provide Query" CssClass="ErrorMsg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    
                        <asp:TextBox ID="txtReopen" runat="server" TextMode="MultiLine" Width="600px" Height="450px"
                            CssClass="editor" Style="display: none;" onfocus="SetCursorToTextEnd(this.id);" />

                        <script type="text/javascript">
                            var config = { toolbar:
            [
            ['Bold', 'Italic', 'Link', 'Unlink', 'Font', 'FontSize']
            ]
                            };
                            var textbox = document.getElementById('<%= txtReopen.ClientID %>');
                            CKEDITOR.replace(textbox, config);
                            
                        </script>

                    </td>
                </tr>
            </table>
            <table width="95%">
                <tr>
                    <td align="right">
                     <asp:Button ID="btnCancel" runat="server" Text="Back"  OnClick="btnBack_Click" Width="150px" />
                        <asp:Button ID="btnReSubmit" runat="server" Text="Submit"  OnClick="btnReSubmit_Click" Width="150px" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
