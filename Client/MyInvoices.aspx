<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MyInvoices.aspx.cs" Inherits="Client.MyDetails" %>

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
                    My Invoices</h2>
            </center>
            <br />
            <asp:Label ID="lblRows" runat="server" Text="No Invoices found." />
            <br />
            <asp:GridView ID="gvTrans" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvTrans_PageIndexChanging"
                Width="100%" CssClass="mGrid">
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
                        <ItemStyle />
                        <HeaderTemplate>
                            Order ID</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("OrderID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Transaction ID</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("TransactionID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Transaction Date</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("CreatedDate","{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Description</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Description")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Dr. Amt. (INR)</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("DRAMT")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Cr. Amt. (INR)</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("CRAMT")%></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblBalAmt" runat="server" ForeColor="Blue" />
            <br />
        </div>
    </asp:Panel>
</asp:Content>
