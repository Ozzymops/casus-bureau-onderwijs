<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn2FaCode.aspx.cs" Inherits="BureauOnderwijs.LogIn2FaCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2FaCode" runat="server" Text="2FA code:"></asp:Label>
            <asp:TextBox ID="TextBox2FaCode" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonSubmit2FaCode" runat="server" Text="Inloggen" />
        </div>
    </form>
</body>
</html>
