<%@ page language="C#" masterpagefile="~/admin/MasterPage.master" autoeventwireup="true" inherits="admin_InvoiceManager, App_Web_n0pp6tlb" title="Shubh Client Panel :: Admin" %>

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
        <div style="font-family: Tahoma; width: 750px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; min-height: 250px; margin-top: 8px">
            <asp:GridView ID="gvTransactions" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvTransactions_RowCommand"
                AllowPaging="True" OnPageIndexChanging="gvTransactions_PageIndexChanging" PageSize="10">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="10px" />
                        <HeaderTemplate>
                            Sl.No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            User ID</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("UserID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Order ID</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("OrderID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Transaction ID</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("TransactionID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Description</HeaderTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Description")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Dr.(INR)</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("DRAMT") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Cr.(INR)</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("CRAMT") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Created Date</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("CreatedDate","{0:dd-MMM-yyyy}")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Created By</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("CreatedBy")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Type</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("TransactionType")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Updated By</HeaderTemplate>
                        <ItemStyle Width="100px" />
                        <ItemTemplate>
                            <%#Eval("Updatedby")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Updated Date</HeaderTemplate>
                        <ItemStyle Width="100px" />
                        <ItemTemplate>
                            <%# Eval("UpdatedDate","{0:dd-MMM-yyyy}")%></ItemTemplate>
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
