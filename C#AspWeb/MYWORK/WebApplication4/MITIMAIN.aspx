<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MITIMAIN.aspx.cs" Inherits="WebApplication4.MITIMAIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 279px;
        }
        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="您好，"></asp:Label>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="695px" AllowPaging="True" AllowSorting="True" DataKeyNames="Q_ID,M_ID1" Height="381px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="Q_ID" DataNavigateUrlFormatString="MITIAN.aspx?Q_ID={0}" Text="回答" />
                                <asp:BoundField DataField="Q_TITLE" HeaderText="標題" SortExpression="Q_TITLE" />
                                <asp:BoundField DataField="M_NAME" HeaderText="出題者" SortExpression="M_NAME" />
                                <asp:CheckBoxField AccessibleHeaderText="1" DataField="Q_answered" SortExpression="Q_answered" Text="已回答正確答案" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miConnectionString %>" SelectCommand="SELECT *
 FROM [question] as q inner join member as b on q.M_ID=b.M_ID"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FormView ID="FormView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Q_ID" DataSourceID="SqlDataSource2" DefaultMode="Insert" GridLines="Horizontal" Height="51px" Width="259px" OnItemInserted="FormView1_ItemInserted" OnItemInserting="FormView1_ItemInserting">
                            <EditItemTemplate>
                                Q_ID:
                                <asp:Label ID="Q_IDLabel1" runat="server" Text='<%# Eval("Q_ID") %>' />
                                <br />
                                M_ID:
                                <asp:TextBox ID="M_IDTextBox" runat="server" Text='<%# Bind("M_ID") %>' />
                                <br />
                                Q_TITLE:
                                <asp:TextBox ID="Q_TITLETextBox" runat="server" Text='<%# Bind("Q_TITLE") %>' />
                                <br />
                                Q_contents:
                                <asp:TextBox ID="Q_contentsTextBox" runat="server" Text='<%# Bind("Q_contents") %>' />
                                <br />
                                Q_ANSWER:
                                <asp:TextBox ID="Q_ANSWERTextBox" runat="server" Text='<%# Bind("Q_ANSWER") %>' />
                                <br />
                                Q_answered:
                                <asp:CheckBox ID="Q_answeredCheckBox" runat="server" Checked='<%# Bind("Q_answered") %>' />
                                <br />
                                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                            </EditItemTemplate>
                            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <InsertItemTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td>標題</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Q_TITLETextBox" runat="server" Height="16px" Text='<%# Bind("Q_TITLE") %>' Width="416px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>題目</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Q_contentsTextBox" runat="server" Height="185px" Text='<%# Bind("Q_contents") %>' TextMode="MultiLine" Width="416px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>答案</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Q_ANSWERTextBox" runat="server" Height="84px" Text='<%# Bind("Q_ANSWER") %>' TextMode="MultiLine" Width="412px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="出題" />
                                            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
&nbsp;
                            </InsertItemTemplate>
                            <ItemTemplate>
                                Q_ID:
                                <asp:Label ID="Q_IDLabel" runat="server" Text='<%# Eval("Q_ID") %>' />
                                <br />
                                M_ID:
                                <asp:Label ID="M_IDLabel" runat="server" Text='<%# Bind("M_ID") %>' />
                                <br />
                                Q_TITLE:
                                <asp:Label ID="Q_TITLELabel" runat="server" Text='<%# Bind("Q_TITLE") %>' />
                                <br />
                                Q_contents:
                                <asp:Label ID="Q_contentsLabel" runat="server" Text='<%# Bind("Q_contents") %>' />
                                <br />
                                Q_ANSWER:
                                <asp:Label ID="Q_ANSWERLabel" runat="server" Text='<%# Bind("Q_ANSWER") %>' />
                                <br />

                                Q_answered:
                                <asp:CheckBox ID="Q_answeredCheckBox" runat="server" Checked='<%# Bind("Q_answered") %>' Enabled="false" />
                                <br />
                                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" />
                                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
                                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="新增" />
                            </ItemTemplate>
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        </asp:FormView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miConnectionString %>" DeleteCommand="DELETE FROM [question] WHERE [Q_ID] = @Q_ID" InsertCommand="INSERT INTO [question] ([M_ID], [Q_TITLE], [Q_contents], [Q_ANSWER], [Q_answered]) VALUES (@M_ID, @Q_TITLE, @Q_contents, @Q_ANSWER, @Q_answered)" SelectCommand="SELECT * FROM [question]" UpdateCommand="UPDATE [question] SET [M_ID] = @M_ID, [Q_TITLE] = @Q_TITLE, [Q_contents] = @Q_contents, [Q_ANSWER] = @Q_ANSWER, [Q_answered] = @Q_answered WHERE [Q_ID] = @Q_ID">
                            <DeleteParameters>
                                <asp:Parameter Name="Q_ID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="M_ID" Type="Int32" />
                                <asp:Parameter Name="Q_TITLE" Type="String" />
                                <asp:Parameter Name="Q_contents" Type="String" />
                                <asp:Parameter Name="Q_ANSWER" Type="String" />
                                <asp:Parameter Name="Q_answered" Type="Boolean" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="M_ID" Type="Int32" />
                                <asp:Parameter Name="Q_TITLE" Type="String" />
                                <asp:Parameter Name="Q_contents" Type="String" />
                                <asp:Parameter Name="Q_ANSWER" Type="String" />
                                <asp:Parameter Name="Q_answered" Type="Boolean" />
                                <asp:Parameter Name="Q_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
