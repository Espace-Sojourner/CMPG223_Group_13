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
            <h2>Password</h2>
            <div class ="right-aligned-sub-box">
                <div>Change password: <asp:CheckBox ID="cbChangePassword" runat="server" Width="150px" OnCheckedChanged="cbChangePassword_CheckedChanged" AutoPostBack="True" /></div>
                <div><asp:Label ID="lblOldPassword" runat="server" Text="Old Password: " Visible="False"></asp:Label><asp:TextBox ID="tbOldPassword" runat="server" Width="150px" TextMode="Password" Wrap="True" Visible="False"></asp:TextBox></div>
                <div><asp:Label ID="lblNewPassword" runat="server" Text="New Password: " Visible="False"></asp:Label><asp:TextBox ID="tbNewPassword" runat="server" Width="150px" TextMode="Password" Visible="False"></asp:TextBox></div>
                <div><asp:Label ID="lblRepeatPassword" runat="server" Text="Repeat Password: " Visible="False"></asp:Label><asp:TextBox ID="tbConfirmNewPassword" runat="server" Width="150px" Visible="False" TextMode="Password"></asp:TextBox></div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="The passwords don't match" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" Visible="False"></asp:CompareValidator>
            </div>
            <h2>Shipping</h2>
            <div class="right-aligned-sub-box">
                <div>Shipping Address: <asp:TextBox ID="tbShippingAddress" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <h2>Billing</h2>
            <div class="right-aligned-sub-box">
                <div>Bank: <asp:TextBox ID="tbBankName" runat="server" Width="150px"></asp:TextBox></div>
                <div>Account number: <asp:TextBox ID="tbAccountNumber" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <h2>Farm details</h2>
            <div class="right-aligned-sub-box">
                <div>Farm name: <asp:TextBox ID="tbFarmName" runat="server" Width="150px"></asp:TextBox></div>
                <div>Farm address: <asp:TextBox ID="tbFarmAddress" runat="server" Width="150px"></asp:TextBox></div>
            </div>
            <div class="right-aligned-sub-box">               
                <div><asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click"/></div>
            </div>

        </div>
    </form>
</body>
</html>
