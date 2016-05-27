<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MyDomains.aspx.cs" Inherits="MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p class="breadcrumb">
        <asp:Label ID="lblBreadCrumb" runat="server" Text="Mydetails" />
    </p>
    <div class="contentbox">
        <asp:Label ID="lblSubMenu" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="pnlMyServices" runat="server">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: 450px; margin-top: 10px;
            color: Black">
            <br />
            <center>
                <h2>
                    My Domains</h2>
            </center>
            <br />
            <asp:Label ID="lblRows" runat="server" />
            <br />
            <asp:GridView ID="gvDomains" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvDomains_PageIndexChanging"
                PageSize="10" PageIndex="10" Width="100%" CssClass="mGrid">
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
                        <ItemStyle Width="10px" />
                        <HeaderTemplate>
                            Sl. No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Domain</HeaderTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Domain")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Reg. Date</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("RegDate","{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Price</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                        <ItemTemplate>
                            <%# Eval("Price","{0:###,###,###0.#0}") %></ItemTemplate>
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
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Status</HeaderTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Status")%></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
