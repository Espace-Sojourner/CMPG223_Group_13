<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list-produce.aspx.cs" Inherits="CMPG223_Group_13.listProduce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>List of Produce</h1>	
			<div class="right-aligned-sub-box">  
                <div>Select from list: <asp:ListBox ID="listBox1" runat="server" Size="20"></asp:ListBox></div>
            </div>
            <div class="right-aligned-sub-box"> 
                <div>Continue: <asp:Button ID="button1" runat="server" Width="50px"></asp:Button></div>
                <div>Back: <asp:Button ID="button2" runat="server" Width="50px"></asp:Button></div>
            </div>>
        </div>
    </form>
</body>
</html>
