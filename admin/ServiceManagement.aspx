<%@ page language="C#" masterpagefile="~/admin/MasterPage.master" autoeventwireup="true" inherits="admin_ServiceManager, App_Web_n0pp6tlb" title="Shubh Client Panel :: Admin" %>

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
        <div style="font-family: Tahoma; width: 760px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; min-height: 250px; margin-top: 8px;
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
            <asp:GridView ID="gvServices" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvServices_RowCommand"
                AllowPaging="True" OnPageIndexChanging="gvServices_PageIndexChanging" PageIndex="10">
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
                            User Name</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("USERNAME")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            User ID</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("USERID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Service</HeaderTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Service")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Status</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Status")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Price(INR)</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Price") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Billing Cycle</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("BillingCycle") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Next Due Date</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("NextDue","{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Update By</HeaderTemplate>
                        <ItemStyle Width="250px" />
                        <ItemTemplate>
                            <%#Eval("Updateby")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Created Date</HeaderTemplate>
                        <ItemStyle Width="250px" />
                        <ItemTemplate>
                            <%#Eval("CreatedDate")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemStyle Width="150px" />
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" CssClass="textbox" Text="Edit" CommandName="EditText"
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
