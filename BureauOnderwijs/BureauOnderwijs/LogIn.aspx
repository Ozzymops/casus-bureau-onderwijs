<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BureauOnderwijs.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>
            Gebruikersnaam:
            <asp:TextBox ID="TextBoxUsernameLogin" runat="server" Width="300"></asp:TextBox>
        </h4>
        <h4>
            Wachtwoord:
            <asp:TextBox ID="TextBoxPasswordLogin" runat="server" TextMode="Password" Width="300"></asp:TextBox>
        </h4>           
        <div>
            <asp:Button ID="ButtonLogin" runat="server" Text="Inloggen" OnClick="ButtonLogin_Click"/>
        </div>
    </form>
</body>
</html>
