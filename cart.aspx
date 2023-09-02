<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="CMPG223_Group_13.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="Your cart"></asp:Label>
            <br />
            <asp:ListBox ID="lstCart" runat="server" Height="199px" Width="420px"></asp:ListBox>
            <br />
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove item" Width="210px" />
            <asp:Button ID="btnClearCart" runat="server" OnClick="btnClearCart_Click" Text="Clear cart" Width="210px" />
            <br />
            <br />
            <asp:Button ID="btnContinueShopping" runat="server" OnClick="btnContinueShopping_Click" Text="Continue shopping" Width="210px" />
            <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check out" Width="210px" />
        </div>
    </form>
</body>
</html>
