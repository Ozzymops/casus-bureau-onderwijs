<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BureauOnderwijs.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelUsernameLogin" runat="server" Text="Gebruikersnaam:"></asp:Label>
            <asp:TextBox ID="TextBoxUsernameLogin" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelPasswordLogin" runat="server" Text="Wachtwoord:"></asp:Label>
            <asp:TextBox ID="TextBoxPasswordLogin" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonLogin" runat="server" Text="Inloggen" OnClick="ButtonLogin_Click" />
        </div>
    </form>
</body>
</html>
