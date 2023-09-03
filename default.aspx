<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CMPG223_Group_13._default" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Login</h1>
            <div class="right-aligned-sub-box">
                <div>
                    Email: <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>   
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email required" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                <div>
                    Password: <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>  
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password required" ForeColor="#FF0066"></asp:RequiredFieldValidator>        
            </div>
        </div>
        <div class="box">
            <asp:Button ID="btnLogin" runat="server" Height="46px" Text="Login" Width="97px" OnClick="btnLogin_Click" />
            <asp:Label ID="lblError" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
        </div>
        <div class="box">
            <asp:Label ID="lblLoginType" runat="server" Text="Select login type:"></asp:Label>

            <div style="display: flex; justify-content: space-between">
                <asp:RadioButton ID="rbtnClient" runat="server" GroupName="Login Type" Text="Client" Checked="true"/>
                <asp:RadioButton ID="rbtnFarmer" runat="server" GroupName="Login Type" Text="Farmer" />
            </div>
        </div>
        <div class="box">
            <h3>New? Create an account now</h3>
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create account" Width="150px" OnClick="btnCreateAccount_Click" CausesValidation="False" />
        </div>
    </form>
</body>
</html>
