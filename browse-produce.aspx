<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="browseProduce.aspx.cs" Inherits="CMPG223_Group_13.browseProduce" %>
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
                    <div>Search: <asp:TextBox ID="tbSubSearch" runat="server" Width="150px"></asp:TextBox></div>
                </div>
            </div>
            <div>
                <asp:GridView ID="gvProduce" runat="server" class="border-style"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
