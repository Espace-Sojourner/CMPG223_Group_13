<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="CMPG223_Group_13.createAccount" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Create account</h1>
            <h2>Account details</h2>
            <div>
                Username: <asp:TextBox ID="tbUsername" runat="server" Width="150px"></asp:TextBox>
                <br />
                Password: <asp:TextBox ID="tbPassword" runat="server" Width="150px"></asp:TextBox>
                <br />
                Repeat password: <asp:TextBox ID="tbConfirmPassword" runat="server" Width="150px"></asp:TextBox>
            </div>
            <h2>Personal details</h2>
            First name: <asp:TextBox ID="tbFirstname" runat="server" Width="150px"></asp:TextBox>
            <br />
            Last name: <asp:TextBox ID="tbLastname" runat="server" Width="150px"></asp:TextBox>
            <br />
            Email address: <asp:TextBox ID="tbEmail" runat="server" Width="150px"></asp:TextBox>
            <br />
            Phone number: <asp:TextBox ID="tbPhone" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <h2>Account type</h2>
            <asp:CheckBox ID="cbFarmerAccount" runat="server" Text="Farmer account" />
            <br />
            Farm name:<asp:TextBox ID="tbFarmName" runat="server" Visible="False" Width="150px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
