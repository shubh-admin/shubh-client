<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="enquiry.aspx.cs" Inherits="admin_enquiry" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlEnquiry" runat="server">
    <span style="font-weight:bold;text-align:center;color:Blue;">Latest Enquiry on Site</span>
    <br />
        <asp:GridView ID="gvEnquiry" runat="server" OnRowCommand="gvEnquiry_RowCommand" DataKeyNames="id"
            BackColor="#DEBA84" BorderColor="#DEBA84" AllowPaging="True" OnPageIndexChanging="gvEnquiry_PageIndexChanging"
            PageIndex="10"  AutoGenerateColumns="False" OnSelectedIndexChanged="gvEnquiry_SelectedIndexChanged"
            Width="100%">
            <HeaderStyle BackColor="#A55129" Font-Bold="false" Font-Size="14px" ForeColor="White" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Font-Size="12px" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="false" ForeColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Compay Name
                    </HeaderTemplate>
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenID" runat="server" Value='<%#Eval("id") %>' />
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%#Eval("CompanyName")%>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Cont. Person
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("ContactName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Phone No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("phone") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        FaX
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("Fax") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Mobile
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("Mobile") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("email") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Address
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("address") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Enquiry
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("comment") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Action
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnDel" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteEnquiry"
                            Text="Delete" CausesValidation="false" CssClass="but" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
<br />
<i>Note: Click Delete to mark Enquiry as Read.</i>
    </asp:Panel>
</asp:Content>
