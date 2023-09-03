<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check-out.aspx.cs" Inherits="CMPG223_Group_13.check_out" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 416px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="Orders summary"></asp:Label>
            <br />
            <textarea id="txtSummary" class="auto-style1" name="S1" readonly="readonly" runat="server"></textarea><br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to cart" Width="210px" />
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Orders" Width="210px" OnClick="btnConfirm_Click" />
            <br />
            <asp:Button ID="btnDashboard" runat="server" Text="Return to dashboard" Width="420px" OnClick="btnReturnToDashboard_Click" Visible="False" />
        </div>
    </form>
</body>
</html>
