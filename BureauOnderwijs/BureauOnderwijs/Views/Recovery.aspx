<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recovery.aspx.cs" Inherits="BureauOnderwijs.Views.Recovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: lightgray;">
    <form id="form1" runat="server">
        <!-- configure SMTP server!!! -->
        <div>
            <asp:PasswordRecovery ID="PasswordRecovery" runat="server" UserNameInstructionText="Enter your e-mail to receive your password." UserNameLabelText="E-mail:" SubmitButtonText="Submit." UserNameTitleText="Forgot your password?"></asp:PasswordRecovery>
        </div>
    </form>
</body>
</html>
