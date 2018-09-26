<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BureauOnderwijs.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Aaa</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="GreetLabel"></asp:Label>
            <asp:Label runat="server" ID="aaa"></asp:Label>
        </div>    
        <p>
            <asp:TextBox runat="server" ID="LabelChangingTextBox"></asp:TextBox>
            <asp:Button runat="server" ID="LabelChangingButton" Height="16px" OnClick="LabelChangingButton_Click" Width="99px" />
            </p>

        <asp:DropDownList runat="server" ID="GreetList" autopostback="true" OnSelectedIndexChanged="GreetList_SelectedIndexChanged">
            <asp:ListItem Value="Normal">Normal</asp:ListItem>
            <asp:ListItem Value="Italic">Italic</asp:ListItem>
            <asp:ListItem Value="Bold">Bold</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>

</html>