<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="BureauOnderwijs.Views.PasswordRecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="recoveryStepOne" runat="server">
            <h3>Vul uw gebruikersnaam in:
                <asp:TextBox ID="UsernameTextBox" runat="server" Width="300"></asp:TextBox>
            </h3>
            <asp:Button ID="RecoverySendButton" runat="server" Text="Reset wachtwoord" OnClick="RecoverySendButton_Click" />
        </div>

        <div id="recoveryStepTwo" runat="server">
            <h3>U krijgt nu een e-mail toegestuurd met een recoverycode. Vul de recoverycode in:</h3>
            <asp:Label ID="CodeLabel" runat="server" Text="Code: "></asp:Label>
            <div>
                <asp:TextBox ID="RecoveryCodeTextBox" runat="server" Width="300"></asp:TextBox>
                <asp:Button ID="RecoveryCodeButton" runat="server" Text="Reset wachtwoord" OnClick="RecoveryCodeButton_Click" />
            </div>
        </div>

        <div id="recoveryStepThree" runat="server">
            <h3>
                <asp:Label ID="NewPasswordLabel" runat="server" Text="Verander wachtwoord voor "></asp:Label>
                <asp:TextBox ID="NewPasswordTextBox" runat="server" Width="300"></asp:TextBox>
            </h3>
            <asp:Button ID="NewPasswordButton" runat="server" Text="Verander wachtwoord en keer terug naar log in" OnClick="NewPasswordButton_Click" />
        </div>
    </form>
</body>
</html>
