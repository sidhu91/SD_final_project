<%@ Page Language="C#" AutoEventWireup="true" CodeFile="submitserv.aspx.cs" Inherits="submitserv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 440px">
    
        <asp:Label ID="Label1" runat="server" Text="SUBMIT SERVICES FOR TESTING ::"></asp:Label>
    
    </div>
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Width="347px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Show Subscribed requirements" />
    <br />
    <br />
    <br />
&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Enter Service Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" Width="174px"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" 
        Text="Enter the WSDL URL of your Service : "></asp:Label>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="41px" Width="423px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Submit Service!" />
    </p>
    <p>
        &nbsp;</p>
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click1" 
        Text="Submit Test Cases and Test Files!" />
    </form>
</body>
</html>
