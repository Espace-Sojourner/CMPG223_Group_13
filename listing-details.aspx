<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listing-details.aspx.cs" Inherits="CMPG223_Group_13.listing_details" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="produce">
            <asp:Image ID="imgProduce" runat="server" Height="111px" Width="141px" />
            <asp:Button ID="btnBacktoBrowse" runat="server" Height="40px" OnClick="btnBacktoBrowse_Click" Text="Back" Width="92px" />
            <br />
            <asp:Label ID="lblProduceName" runat="server" Text="Produce Name"></asp:Label>
            <br />
            <asp:Label ID="lblFarmer" runat="server" Text="Sold by Farmer"></asp:Label>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            &nbsp;<br />
            <asp:Label ID="lblPrice" runat="server" Text="R0 per UOM"></asp:Label>
            <br />
            Available for purchase: <asp:Label ID="lblAvailable" runat="server" Text="0"></asp:Label>
            <br />
            Expiration date:
            <asp:Label ID="lblExpiration" runat="server" Text="yyyy/mm/dd"></asp:Label>
        </div>
        <div id="input">
            Quantity:
            <asp:TextBox ID="tbQuantity" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAddToCart" runat="server" OnClick="btnAddToCart_Click" Text="Add to cart" Width="140px" />
            <br />
            <asp:Label ID="lblAdded" runat="server" Text="Added to cart" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnBuyNow" runat="server" OnClick="btnBuyNow_Click" Text="Buy it now" Width="140px" />
        </div>
        <div id="navigation">
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to listings" Width="140px" />
            <br />
            <asp:Button ID="btnViewCart" runat="server" OnClick="btnViewCart_Click" Text="View cart" Width="140px" />
        </div>
    </form>
</body>
</html>
