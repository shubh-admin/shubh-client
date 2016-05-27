<%@ page language="C#" masterpagefile="~/admin/MasterPage.master" autoeventwireup="true" inherits="admin_ImageManager, App_Web_isyexrvv" title="singhshashtar" %>

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
                Insert Image</div>
            <table style="width: 600px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
                color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Category Name:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcategory" runat="server" CssClass="textbox" Width="252px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Caption:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtcaption" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcaption"
                            ErrorMessage="Please Enter caption" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Description:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtDescr" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDescr"
                            ErrorMessage="Please Enter Image Descr" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                        Upload Image:
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" Height="18px"
                            Width="250px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
                            ErrorMessage="only jpg,gif image" ForeColor="#6D6D6D" ValidationExpression=".*(.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Cost (Rs.):
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtcost" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcost"
                            ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Cost ($):
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtCostUSD" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcostUSD"
                            ErrorMessage="Please Enter Dollar Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
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
        <div style="font-family: Tahoma; width: 700px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; height: 150px; margin-top: 8px">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging" PageIndex="10">
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
                            S.No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Image Caption</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("ImageCaption")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Category</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("Categoryname")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Image</HeaderTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <img src="../image/CategoryImage/<%#Eval("Image")%>_Thumb.jpg" width="50px" height="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Image Description</HeaderTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("ImageDescr")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Cost(INR)</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("costINR") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Cost($)</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("costUSD") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" />
                        <HeaderTemplate>
                            Image Order</HeaderTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("ImgOrder") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemStyle Width="250px" />
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" CssClass="textbox" Text="Edit" CommandName="EditText"
                                CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btndelete" runat="server" CssClass="textbox" Text="Delete" CommandName="DeleteText"
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
                Edit
            </div>
            <table style="width: 600px; height: 65px; margin-top: 2px; margin-left: auto; margin-right: auto;
                color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                <tr class="tr">
                    <td style="text-align: left">
                        Category Name:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textbox" Width="252px"
                            DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="ID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Deep_S105ConnectionString %>"
                            SelectCommand="SELECT * FROM [tblcategory]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style2">
                        Caption:
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Please Enter caption" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style2">
                        Description:
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="Please Enter Image Description" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style2">
                        Cost(Rs.):
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style2">
                        Cost($):
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox4"
                            ErrorMessage="Please Enter USD Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left" class="style1">
                        Image Order :
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtImgOrder" runat="server" CssClass="textbox" Width="250px" MaxLength="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtImgOrder"
                            ErrorMessage="Please Enter Image Order" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regval" runat="server" ControlToValidate="txtImgOrder"
                            ForeColor="#6D6D6D" ErrorMessage="Enter numeric value only" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td style="text-align: left">
                    </td>
                    <td>
                        <asp:Button ID="btnupdate" runat="server" CssClass="but" Text="Update" OnClick="btnupdate_Click" />
                        <asp:Button ID="btnAddNewCraft" runat="server" CssClass="but" OnClick="btnAddNewCraft_Click"
                            Text="New Craft" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelFlash" runat="server">
        <div style="font-family: Tahoma; width: 700px; border: solid 1px #d7d4d4; margin-left: auto;
            margin-right: auto; background-color: #f3f3f3; height: 450px; margin-top: 8px">
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="40px" />
                        <HeaderTemplate>
                            S.No.</HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Category</HeaderTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%#Eval("Categoryname")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image</HeaderTemplate>
                        <ItemStyle Width="280px" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <img src="../image/flashimage/<%#Eval("Image")%>.jpg" width="60px" height="60px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemStyle Width="250px" />
                        <ItemTemplate>
                            <asp:Button ID="btnchange" runat="server" CssClass="textbox" Text="ChangeImage" CommandName="Change"
                                CommandArgument='<%#Eval("Image")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="panelflashedit" runat="server" Visible="false">
                <div style="width: 690px; height: 25px; margin-top: 2px; margin-left: auto; border: solid 1px;
                    margin-right: auto; background-color: #fd6600; color: #dbdbdb; font-size: 18px;
                    font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                    Change Image</div>
                <table style="width: 600px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
                    color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
                    <tr class="tr">
                        <td style="text-align: left">
                            Upload Image:
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="textbox" Height="20px"
                                Width="350px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1"
                                ErrorMessage="only jpg,gif image" ForeColor="#6D6D6D" ValidationExpression=".*(.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="tr">
                        <td style="text-align: left">
                        </td>
                        <td>
                            <asp:Button ID="change" runat="server" CssClass="but" Text="Change" OnClick="btnchange_Click" />
                            <asp:Button ID="Cancel1" runat="server" CssClass="but" Text="Cancel" OnClick="btncancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:Panel ID="paneldetails" runat="server" Visible="false">
        <div style="width: 690px; height: 25px; margin-top: 2px; margin-left: auto; border: solid 1px;
            margin-right: auto; background-color: #fd6600; color: #dbdbdb; font-size: 18px;
            font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
            Insert Image Deatils</div>
        <table style="width: 600px; height: 25px; margin-top: 2px; margin-left: auto; margin-right: auto;
            color: #6d6d6d; font-size: 18px; font-family: Tahoma; text-align: left; padding: 5px 0 0 5px">
            <tr class="tr">
                <td style="text-align: left" class="style1">
                    Size:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtsize" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtsize"
                        ErrorMessage="Please Enter Size" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
                <td rowspan="7">
                    <!-- <asp:Image ID="img_product" Width="150px" Height="150px" runat="server" /> -->
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left" class="style1">
                    Craft
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtcraft" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtcraft"
                        ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left" class="style1">
                    Cost (Rs.):
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtcost1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtcost1"
                        ErrorMessage="Please Enter INR Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left" class="style1">
                    Cost ($):
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtcostUSD1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtcostUSD1"
                        ErrorMessage="Please Enter Dollar Cost" ForeColor="#6D6D6D"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left" class="style1">
                    Description:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txt_description" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left">
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="tr">
                <td style="text-align: left">
                </td>
                <td>
                    <asp:Button ID="add1" runat="server" CssClass="but" Text="Add" OnClick="btnadd1_Click" />
                    <asp:Button ID="Done" runat="server" CssClass="but" Text="Done" OnClick="btndone_Click"
                        CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <%--<asp:GridView ID="gv_imgdetails" runat="server" BackColor="#DEBA84" 
                        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="1" 
                        CellSpacing="1" >
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Font-Size="12px" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="false" ForeColor="White" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="false" Font-Size="14px" ForeColor="White" />
                    </asp:GridView>--%>
                    <asp:GridView ID="gv_imgdetails" runat="server" OnRowCommand="gv_imgdetails_RowCommand"
                        DataKeyNames="id" BackColor="#DEBA84" BorderColor="#DEBA84" OnRowEditing="gv_imgdetails_RowEditing"
                        AllowPaging="True" OnPageIndexChanging="gv_imgdetails_PageIndexChanging" PageIndex="3"
                        AutoGenerateColumns="False" OnSelectedIndexChanged="gv_imgdetails_SelectedIndexChanged">
                        <HeaderStyle BackColor="#A55129" Font-Bold="false" Font-Size="14px" ForeColor="White" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Font-Size="12px" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="false" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Item ID
                                </HeaderTemplate>
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Hidden" runat="server" Value='<%#Eval("id") %>' />
                                    <asp:CheckBox Visible="false" ID="chkbtn" runat="server" />
                                    <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("id")%>' Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Craft
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Eval("craft") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Size
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Eval("size") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Cost (Rs.)
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Eval("priceinr") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Cost(US$)
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Eval("priceusd") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Other
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Eval("other") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Edit
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button4" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="edit"
                                        Text="Edit" CausesValidation="false" CssClass="but" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Delete
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Delete1"
                                        Text="Delete" CausesValidation="false" CssClass="but" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%#Eval("ImageCaption")%>
</asp:Content>
