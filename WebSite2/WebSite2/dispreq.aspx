<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dispreq.aspx.cs" Inherits="dispreq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Label ID="Label1" runat="server" Text="REQUIREMENTS SUBMITTED BY TENANTS!"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="SHOW REQUIREMENTS!" />
    
    </div>
    <p>
        <asp:ListBox ID="ListBox1" runat="server" Height="184px" Width="697px">
        </asp:ListBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="SUBSCRIBE!" />
    </p>
    <p>
    <asp:Label ID="Label2" runat="server" Text="QUERY STATUS! "></asp:Label>
    </p>
    </form>
</body>
</html>
