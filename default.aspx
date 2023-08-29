<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CMPG223_Group_13._default" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Login</h1>
            <div class="right-aligned-sub-box">
                <div>Username: <asp:TextBox ID="tbUsername" runat="server" Width="150px"></asp:TextBox></div>
                <div>Password: <asp:TextBox ID="tbPassword" runat="server" Width="150px"></asp:TextBox></div>           
            </div>
            <div class="right-aligned-sub-box">
                <asp:Button ID="btnLogin" runat="server" Height="46px" Text="Login" Width="97px" />
            </div>
            <div class="right-aligned-sub-box">
            <h1>Account type</h1>
                <div style="display: flex; justify-content: space-between>
                    <asp:RadioButton ID="rbtnClient" runat="server" GroupName="Login Type" Text="Client" />
                    <asp:RadioButton ID="rbtnFarmer" runat="server" GroupName="Login Type" Text="Farmer" />
                </div>
        </div>
        </div>
    </form>
</body>
</html>
