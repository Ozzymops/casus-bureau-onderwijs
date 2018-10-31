<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn2FaCode.aspx.cs" Inherits="BureauOnderwijs.Views.LogIn2FaCode" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>
            Twee staps verificatie code:
            <asp:TextBox ID="TextBox2FaCode" runat="server"></asp:TextBox>
        </h4>
        <div>
            <asp:Button ID="ButtonSubmit2FaCode" runat="server" Text="Inloggen" OnClick="ButtonSubmit2FaCode_Click" />
            <asp:Button ID="ButtonCancelLogin" runat="server" Text="Annuleren" OnClick="ButtonCancelLogin_Click" />
        </div>
        <div>

        </div>
        <h4>
            Sessienummer:
            <asp:Label ID="LabelSessionNumberActive" runat="server" Text=""></asp:Label>
        </h4>   
        <h4>
            Twee staps verificatie code:
            <asp:Label ID="LabelGenerated2FaCodeActive" runat="server" Text=""></asp:Label>
        </h4>
    </form>
</body>
</html>
