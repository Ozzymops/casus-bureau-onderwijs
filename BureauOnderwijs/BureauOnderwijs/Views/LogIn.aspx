<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Views/LogIn.aspx.cs" Inherits="BureauOnderwijs.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>
            <asp:Label ID="LabelGebruikersnaam" runat="server" Text="Gebruikersnaam:" Width="170px"></asp:Label>
            <asp:TextBox ID="TextBoxUsernameLogin" runat="server" Width="300"></asp:TextBox>
        </h4>
        <h4>
            <asp:Label ID="LabelWachtwoord" runat="server" Text="Wachtwoord:" Width="170px"></asp:Label>
            <asp:TextBox ID="TextBoxPasswordLogin" runat="server" TextMode="Password" Width="300"></asp:TextBox>
        </h4>           
        <div style="margin-left:240px;">
            <asp:Button ID="ButtonLogin" runat="server" Text="Inloggen" OnClick="ButtonLogin_Click" Width="237"/>    
        </div>
        <div style="color:white;">
            White space
        </div>
        <div style="margin-left:240px;">
            <asp:Button ID="ButtonRecovery" runat="server" Text="Wachtwoord vergeten?" OnClick="ButtonRecovery_Click" Width="237"/> 
        </div>
    </form>
</body>
</html>
