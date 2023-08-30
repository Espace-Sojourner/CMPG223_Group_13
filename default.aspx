﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CMPG223_Group_13._default" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 411px;
        }
        .auto-style2 {
            width: 411px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 182px;
        }
        .auto-style5 {
            height: 26px;
            width: 182px;
        }
        .auto-style6 {
            width: 411px;
            height: 20px;
        }
        .auto-style7 {
            height: 20px;
            width: 182px;
        }
        .auto-style8 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>Login</h1>
            <div class="box">
                Email:<br />
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                <br />
                Password:<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>           
            </div>
        </div>
        <p>
            &nbsp;</p>
        <div>
            <asp:Button ID="btnLogin" runat="server" Height="46px" Text="Login" Width="97px" OnClick="btnLogin_Click" />
            <br />
                    <asp:Label ID="lblError" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <br />
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="lblLoginType" runat="server" Text="Select login type:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7">
                    <asp:RadioButton ID="rbtnClient" runat="server" GroupName="Login Type" Text="Client" Height="8px" Width="128px" />
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">
                    <asp:RadioButton ID="rbtnFarmer" runat="server" GroupName="Login Type" Text="Farmer" />
                </td>
                <td class="auto-style3"></td>
            </tr>
        </table>
    </form>
</body>
</html>
