<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="browse-produce.aspx.cs" Inherits="CMPG223_Group_13.browse_produce" %>
<link href="general.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="columns">
            <div class ="sidebar">
                <div class="left-aligned-sub-box" style="padding: 10px">
                    <h2 style ="text-align: center">Filter results</h2>
                    <div>Search: <asp:TextBox ID="tbSubSearch" runat="server" Width="150px" AutoPostBack="True"></asp:TextBox>
                        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filter" />
                    </div>
                </div>
            </div>
            <div>
                <asp:Button ID="btnBacktoDash" runat="server" Height="44px" Text="Back" Width="94px" OnClick="btnBacktoDash_Click" />
                <asp:GridView ID="gvProduce" runat="server" class="border-style" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvProduce_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
