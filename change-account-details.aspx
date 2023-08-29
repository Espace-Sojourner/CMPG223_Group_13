<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change-account-details.aspx.cs" Inherits="CMPG223_Group_13.change_account_details" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">       
            <h1>Edit Account details</h1>
            <h2>Personal details</h2>
            <div class="right-aligned-sub-box">
                <div>First name: <asp:TextBox ID="tbFirstname" runat="server" Width="150px"></asp:TextBox></div>
                <div>Last name: <asp:TextBox ID="tbLastname" runat="server" Width="150px"></asp:TextBox></div>
                <div>Email address: <asp:TextBox ID="tbEmail" runat="server" Width="150px"></asp:TextBox></div>
                <div>Phone number: <asp:TextBox ID="tbPhone" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <div class="right-aligned-sub-box">               
                <div><asp:Button ID="btnConfirm" runat="server" Text="Confirm"/></div>
            </div>

        </div>
    </form>
</body>
</html>
