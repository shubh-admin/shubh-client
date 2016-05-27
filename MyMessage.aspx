<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MyMessage.aspx.cs" Inherits="MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p class="breadcrumb">
        <asp:Label ID="lblBreadCrumb" runat="server" Text="Mydetails" />
    </p>
    <div class="contentbox">
        <asp:Label ID="lblSubMenu" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="pnlMyMessages" runat="server">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff;height: auto; min-height: 300px; margin-top: 10px;
            color: Black">
            <center>
                <h2>
                    My Messages</h2>
            </center>
            <br />
            <asp:Label ID="lblRows" runat="server" />
            <br />
            <asp:GridView ID="gvMessages" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvMessages_PageIndexChanging"
                PageSize="10" PageIndex="10" Width="100%" CssClass="mGrid" OnRowCommand="gvMessages_RowCommand">
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
                            Date</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("SENDDATE", "{0:dd-MMM-yyyy}")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Sender Name</HeaderTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%# Eval("Sender Name")%></ItemTemplate>
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
                            <asp:LinkButton ID="btnRead" runat="server" CssClass="textboxlink" Text="Read Message"
                                CommandName="Read" CommandArgument='<%#Eval("ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlReadMessage" runat="server" Visible="false">
        <div style="font-family: Tahoma; width: 100%; border: solid 1px Green; margin-left: auto;
            margin-right: auto; background-color: #ffffff; height: auto; min-height: 200px;
            margin-top: 10px; color: Black">
            <br />
            <center>
                <h2>
                    Read Messages</h2>
            </center>
            <div class="Message">
                <asp:Label ID="lblMessage" runat="server" /></div>
            <table width="95%">
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="btnRead" runat="server" CssClass="textboxlink" 
                            Text="Back to Messages" onclick="btnRead_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
