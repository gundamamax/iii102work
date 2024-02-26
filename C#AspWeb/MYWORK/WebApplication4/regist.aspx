<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="WebApplication4.regist" %>

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
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="註冊"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="帳號"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="帳號不可以空白" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="Label5" runat="server" EnableTheming="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="密碼"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="密碼不可以空白" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="確認密碼"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="確認密碼與密碼不相符" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="註冊" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" style="height: 21px" ValidateRequestMode="Disabled" ValidationGroup="cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
