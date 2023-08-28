﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="CMPG223_Group_13.createAccount" %>
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
            <div class="right-aligned-sub-box">  
                <div>Username: <asp:TextBox ID="tbUsername" runat="server" Width="150px"></asp:TextBox></div>
                <div>Password: <asp:TextBox ID="tbPassword" runat="server" Width="150px"></asp:TextBox></div>
                <div>Repeat password: <asp:TextBox ID="tbConfirmPassword" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <h2>Personal details</h2>
            <div class="right-aligned-sub-box">
                <div>First name: <asp:TextBox ID="tbFirstname" runat="server" Width="150px"></asp:TextBox></div>
                <div>Last name: <asp:TextBox ID="tbLastname" runat="server" Width="150px"></asp:TextBox></div>
                <div>Email address: <asp:TextBox ID="tbEmail" runat="server" Width="150px"></asp:TextBox></div>
                <div>Phone number: <asp:TextBox ID="tbPhone" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <h2>Account type</h2>
            <div class="right-aligned-sub-box">               
                <div><asp:CheckBox ID="cbFarmerAccount" runat="server" Text="Farmer account" /></div>
                <div>Farm name: <asp:TextBox ID="tbFarmName" runat="server" Visible="False" Width="150px"></asp:TextBox></div>
            </div>
            <div class="right-aligned-sub-box">               
                <div><asp:Button ID="btnCreate" runat="server" Text="Create Account" /></div>
            </div>

        </div>
    </form>
</body>
</html>
