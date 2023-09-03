<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="CMPG223_Group_13.cart" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Your cart</h1>
                <asp:ListBox ID="lstCart" runat="server" Height="200px" Width="420px"></asp:ListBox>
            <div class="right-aligned-sub-box">
                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove item" Width="210px" />
                <asp:Button ID="btnClearCart" runat="server" OnClick="btnClearCart_Click" Text="Clear cart" Width="210px" />

                <asp:Button ID="btnContinueShopping" runat="server" OnClick="btnContinueShopping_Click" Text="Continue shopping" Width="210px" />
                <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check out" Width="210px" />
            </div>
        </div>
    </form>
</body>
</html>
