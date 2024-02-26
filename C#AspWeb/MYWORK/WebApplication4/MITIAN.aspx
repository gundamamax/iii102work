<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MITIAN.aspx.cs" Inherits="WebApplication4.MITIAN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 20px;
            text-align: center;
        }
        .auto-style3 {
            height: 36px;
            text-align: center;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            height: 20px;
        }
        .auto-style6 {
            text-align: center;
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miConnectionString %>" SelectCommand="SELECT * FROM [ANSWER] WHERE ([Q_ID] = @Q_ID)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="Q_ID" QueryStringField="Q_ID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" BackColor="#FFFFCC" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="A_ID" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="1228px">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:TemplateField HeaderText="回答" InsertVisible="False" SortExpression="A_ID">
                                    <ItemTemplate>
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("A_ANSWER") %>'></asp:Label>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("A_CORRECT") %>' Text="正確" Enabled="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style5">
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("A_ANSWERdetail") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:FormView ID="FormView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="A_ID" DataSourceID="SqlDataSource2" DefaultMode="Insert" GridLines="Horizontal" OnItemInserting="FormView1_ItemInserting" Width="1224px">
                            <EditItemTemplate>
                                A_ID:
                                <asp:Label ID="A_IDLabel1" runat="server" Text='<%# Eval("A_ID") %>' />
                                <br />
                                Q_ID:
                                <asp:TextBox ID="Q_IDTextBox" runat="server" Text='<%# Bind("Q_ID") %>' />
                                <br />
                                M_ID:
                                <asp:TextBox ID="M_IDTextBox" runat="server" Text='<%# Bind("M_ID") %>' />
                                <br />
                                A_ANSWER:
                                <asp:TextBox ID="A_ANSWERTextBox" runat="server" Text='<%# Bind("A_ANSWER") %>' />
                                <br />
                                A_ANSWERdetail:
                                <asp:TextBox ID="A_ANSWERdetailTextBox" runat="server" Text='<%# Bind("A_ANSWERdetail") %>' />
                                <br />
                                A_CORRECT:
                                <asp:CheckBox ID="A_CORRECTCheckBox" runat="server" Checked='<%# Bind("A_CORRECT") %>' />
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
                                        <td class="auto-style5">答案</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="A_ANSWERdetailTextBox" runat="server" Height="267px" Text='<%# Bind("A_ANSWERdetail") %>' Width="350px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" CssClass="auto-style4" Font-Bold="True" Font-Size="XX-Large" Text="答題!" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
&nbsp;
                            </InsertItemTemplate>
                            <ItemTemplate>
                                A_ID:
                                <asp:Label ID="A_IDLabel" runat="server" Text='<%# Eval("A_ID") %>' />
                                <br />
                                Q_ID:
                                <asp:Label ID="Q_IDLabel" runat="server" Text='<%# Bind("Q_ID") %>' />
                                <br />
                                M_ID:
                                <asp:Label ID="M_IDLabel" runat="server" Text='<%# Bind("M_ID") %>' />
                                <br />
                                A_ANSWER:
                                <asp:Label ID="A_ANSWERLabel" runat="server" Text='<%# Bind("A_ANSWER") %>' />
                                <br />
                                A_ANSWERdetail:
                                <asp:Label ID="A_ANSWERdetailLabel" runat="server" Text='<%# Bind("A_ANSWERdetail") %>' />
                                <br />
                                A_CORRECT:
                                <asp:CheckBox ID="A_CORRECTCheckBox" runat="server" Checked='<%# Bind("A_CORRECT") %>' Enabled="false" />
                                <br />

                            </ItemTemplate>
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        </asp:FormView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miConnectionString %>" DeleteCommand="DELETE FROM [ANSWER] WHERE [A_ID] = @A_ID" InsertCommand="INSERT INTO [ANSWER] ([Q_ID], [M_ID], [A_ANSWER], [A_ANSWERdetail], [A_CORRECT]) VALUES (@Q_ID, @M_ID, @A_ANSWER, @A_ANSWERdetail, @A_CORRECT)" SelectCommand="SELECT * FROM [ANSWER]" UpdateCommand="UPDATE [ANSWER] SET [Q_ID] = @Q_ID, [M_ID] = @M_ID, [A_ANSWER] = @A_ANSWER, [A_ANSWERdetail] = @A_ANSWERdetail, [A_CORRECT] = @A_CORRECT WHERE [A_ID] = @A_ID">
                            <DeleteParameters>
                                <asp:Parameter Name="A_ID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Q_ID" Type="Int32" />
                                <asp:Parameter Name="M_ID" Type="Int32" />
                                <asp:Parameter Name="A_ANSWER" Type="String" />
                                <asp:Parameter Name="A_ANSWERdetail" Type="String" />
                                <asp:Parameter Name="A_CORRECT" Type="Boolean" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Q_ID" Type="Int32" />
                                <asp:Parameter Name="M_ID" Type="Int32" />
                                <asp:Parameter Name="A_ANSWER" Type="String" />
                                <asp:Parameter Name="A_ANSWERdetail" Type="String" />
                                <asp:Parameter Name="A_CORRECT" Type="Boolean" />
                                <asp:Parameter Name="A_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="回上頁" />
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
