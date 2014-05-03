<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mysubsc.aspx.cs" Inherits="mysubsc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" 
        Text="YOU HAVE SUBSCRIBED TO THE FOLLOWING SERVICES :"></asp:Label>
    <p>
        &nbsp;</p>
    <asp:ListBox ID="ListBox1" runat="server" Height="195px" Width="438px">
    </asp:ListBox>
    </form>
</body>
</html>
