<%@ page language="C#" masterpagefile="~/admin/MasterPage.master" autoeventwireup="true" inherits="admin_ErrorLogReport, App_Web_n0pp6tlb" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlEnquiry" runat="server">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
        
        <br />
        <asp:GridView ID="gvEnquiry" runat="server" OnRowCommand="gvEnquiry_RowCommand" DataKeyNames="id"
            BackColor="#DEBA84" BorderColor="#DEBA84" AllowPaging="True" OnPageIndexChanging="gvEnquiry_PageIndexChanging"
            PageIndex="10" AutoGenerateColumns="False" OnSelectedIndexChanged="gvEnquiry_SelectedIndexChanged"
            Width="100%">
            <HeaderStyle BackColor="#A55129" Font-Bold="false" Font-Size="14px" ForeColor="White" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Font-Size="12px" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="false" ForeColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Date
                    </HeaderTemplate>
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenID" runat="server" Value='<%#Eval("id") %>' />
                        <asp:Label ID="lblDateTime" runat="server" Text='<%#Eval("DateTime")%>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        URL
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("URL") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Error
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("Error") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Description
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("Descr") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <hr />
        <asp:Button ID="btnClear" CssClass="button" Text="Clear Log" runat="server" OnClick="btnClear_Click" />
    </asp:Panel>
</asp:Content>
