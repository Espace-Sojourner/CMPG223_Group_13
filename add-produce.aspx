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
                <div>Produce:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlProduce" runat="server">
                    </asp:DropDownList>
                </div>
                <div>Price: <asp:TextBox ID="tbPrice" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPrice" ErrorMessage="Input Price" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Quantity: <asp:TextBox ID="tbQuantity" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbQuantity" ErrorMessage="Input Quantity" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <h2>Expiration date</h2>
            <asp:Label ID="lblError" runat="server" Font-Bold="False" Font-Italic="True" ForeColor="Red"></asp:Label>
            <asp:Calendar ID="calExpirationDate" runat="server"></asp:Calendar>
            <asp:Button ID="btnSubmitListing" runat="server" Height="54px" OnClick="btnSubmitListing_Click" Text="Submit Listing" Width="200px" />
            <asp:Button ID="btnBack" runat="server" Height="54px" OnClick="btnBack_Click" Text="Back" Width="200px" />
        </div>
    </form>
</body>
</html>
