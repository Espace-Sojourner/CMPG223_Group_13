<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CMPG223_Group_13._default" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </form>
</body>
</html>
