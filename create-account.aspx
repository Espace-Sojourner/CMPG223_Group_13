<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-account.aspx.cs" Inherits="CMPG223_Group_13.createAccount" %>
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
                <div></div>
                <div>Password: <asp:TextBox ID="tbPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPassword" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Repeat password: <asp:TextBox ID="tbConfirmPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbConfirmPassword" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="The passwords don't match" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword"></asp:CompareValidator>
            </div>
            <h2>Personal details</h2>
            <div class="right-aligned-sub-box">
                <div>First name: <asp:TextBox ID="tbFirstname" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbFirstname" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Last name: <asp:TextBox ID="tbLastname" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbLastname" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Email address: <asp:TextBox ID="tbEmail" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbEmail" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Phone number: <asp:TextBox ID="tbPhone" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbPhone" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <h2>Account type</h2>
            If you wish to list produce, create a Farmer accout.
            <div class="right-aligned-sub-box">               
                <div>
                    <asp:CheckBox ID="cbFarmerAccount" runat="server" Text="Farmer account"/></div>
            </div>
             <h2>Shipping</h2>
            <div class="right-aligned-sub-box">
                <div>Shipping Address: <asp:TextBox ID="tbShippingAddress" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbShippingAddress" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <h2>Billing</h2>
            <div class="right-aligned-sub-box">
                <div>Bank: <asp:TextBox ID="tbBankName" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbBankName" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Account number: <asp:TextBox ID="tbAccountNumber" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbAccountNumber" ErrorMessage="Required Field" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <h2>Farm details</h2>
            <div class="right-aligned-sub-box">
                <div>Farm name: <asp:TextBox ID="tbFarmName" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbFarmName" ErrorMessage="Required Field. Set as N/A if not a farmer." Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>Farm address: <asp:TextBox ID="tbFarmAddress" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbFarmAddress" ErrorMessage="Required Field. Set as N/A if not a farmer." Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="right-aligned-sub-box">               
                <div>
                    <asp:Button ID="btnCreate" runat="server" Text="Create Account" OnClick="btnCreate_Click" /></div>
            </div>

        </div>
    </form>
</body>
</html>
