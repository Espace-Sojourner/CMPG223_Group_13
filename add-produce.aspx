<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add-produce.aspx.cs" Inherits="CMPG223_Group_13.add_produce" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Add listing</h1>
            <h2>Listing details</h2>
            <div class="right-aligned-sub-box">
                <div>Produce ID: <asp:TextBox ID="tbProduceID" runat="server" Width="150px"></asp:TextBox></div>
                <div>Price: <asp:TextBox ID="tbPrice" runat="server" Width="150px"></asp:TextBox></div>
                <div>Quantity: <asp:TextBox ID="tbQuantity" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <h2>Expiration date</h2>
            <asp:Calendar ID="calExpirationDate" runat="server"></asp:Calendar>
        </div>
    </form>
</body>
</html>
