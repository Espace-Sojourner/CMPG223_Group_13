<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CMPG223_Group_13._default" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 411px;
        }
        .auto-style2 {
            width: 411px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>Login</h1>
            <div class="box">
                Username: <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                <br />
                Password: <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>           
            </div>
        </div>
        <p>
            &nbsp;</p>
        <div>
            <asp:Button ID="btnLogin" runat="server" Height="46px" Text="Login" Width="97px" />
        </div>
        <div>
            <br />
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lblLoginType" runat="server" Text="Select login type:"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:RadioButton ID="rbtnClient" runat="server" GroupName="Login Type" Text="Client" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3">
                    <asp:RadioButton ID="rbtnFarmer" runat="server" GroupName="Login Type" Text="Farmer" />
                </td>
                <td class="auto-style3"></td>
            </tr>
        </table>
    </form>
</body>
</html>
