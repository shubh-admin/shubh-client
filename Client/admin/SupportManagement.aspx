<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="SupportManagement.aspx.cs" Inherits="admin_SupportManager" Title="Shubh Client Panel :: Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .style2
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="paneladd" runat="server">
        <div style="font-family: Tahoma; width: 700px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; height: 250px; margin-top: 8px;
            color: Black">
            <div style="width: 690px; height: 25px; margin-top: 2px; margin-left: auto; border: solid 1px;
                margin-right: auto; background-color: #fd6600; color: #dbdbdb; font-size: 18px;
                font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                Domain Reg. Entry</div>
            <table style="width: 618px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
                color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Client :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClientName" runat="server" CssClass="textbox" Width="252px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Domain:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtDomain" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDomain"
                            ErrorMessage="Please Enter Domain" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDomain"
                            ErrorMessage="Please Enter valid Domain" ForeColor="#6D6D6D" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Status:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtStatus" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStatus"
                            ErrorMessage="Please Enter Status" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Reg. Date [mm/dd/yyyy]:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRegDate" runat="server" CssClass="textbox" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRegDate"
                            ErrorMessage="Please Enter Reg. Date" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Price (Rs.):
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtcost" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcost"
                            ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Next Due [mm/dd/yyyy]:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNextDue" runat="server" CssClass="textbox" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNextDue"
                            ErrorMessage="Please Enter Next Due Date" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
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
        <div style="font-family: Tahoma; width: 760px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; min-height: 250px; margin-top: 8px">
            <asp:GridView ID="gvSupport" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvSupport_PageIndexChanging"
                PageSize="10" Width="100%" CssClass="mGrid" OnRowCommand="gvSupport_RowCommand">
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
                            Panel Details</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("PanelDetail")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Acc. ID</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("ACCID")%></ItemTemplate>
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
                            <asp:LinkButton ID="btnRead" runat="server" CssClass="textboxlink" Text="Reply" CommandName="Read"
                                CommandArgument='<%#Eval("ID")%>' />
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="paneledit" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 700px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; height: 250px; margin-top: 8px;
            color: Black">
            <div style="width: 690px; height: 25px; margin-top: 2px; margin-left: auto; border: solid 1px;
                margin-right: auto; background-color: #fd6600; color: #dbdbdb; font-size: 18px;
                font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                Domain Reg. Edit
            </div>
            <table style="width: 618px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
                color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Client :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClientEdit" runat="server" CssClass="textbox" Width="252px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Domain:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtDomainEdit" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDomainEdit"
                            ErrorMessage="Please Enter Domain" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDomainEdit"
                            ErrorMessage="Please Enter valid Domain" ForeColor="#6D6D6D" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Status:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtStatusEdit" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStatusEdit"
                            ErrorMessage="Please Enter Status" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Reg. Date [mm/dd/yyyy]:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRegDateEdit" runat="server" CssClass="textbox" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRegDateEdit"
                            ErrorMessage="Please Enter Reg. Date" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Price (Rs.):
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtCostEdit" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCostEdit"
                            ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Next Due [mm/dd/yyyy]:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNextDueEdit" runat="server" CssClass="textbox" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNextDueEdit"
                            ErrorMessage="Please Enter Next Due Date" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Label ID="lblMsgEdit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="but" Text="Add" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
