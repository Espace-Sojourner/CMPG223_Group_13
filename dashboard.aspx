<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="CMPG223_Group_13.dashboard" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Dashboard</h1>
             <asp:Label ID="lblWelcome" runat="server" Text="Welcome [insert username]" Font-Names="Calibri" Font-Size="Large" style="color: white"></asp:Label>              
            <div class="right-aligned-sub-box">
                <asp:Button ID="btnBrowse" runat="server" Text="Browse" class="large-flat-button" OnClick="btnBrowse_Click"/>
                <asp:Button ID="btnManageListings" runat="server" Text="Manage Listings" class="large-flat-button" OnClick="btnManageListings_Click"/>
                <asp:Button ID="btnAccount" runat="server" Text="Account" class="large-flat-button" OnClick="btnAccount_Click"/>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
