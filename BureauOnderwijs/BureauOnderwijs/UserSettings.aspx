<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="BureauOnderwijs.UserSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Emailaddress" HeaderText="Emailaddress" SortExpression="Emailaddress" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bureauonderwijsdbConnectionString %>" SelectCommand="SELECT [FirstName], [LastName], [Emailaddress], [Password] FROM [user]"></asp:SqlDataSource>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Voornaam: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonUpdateFirstName" runat="server" OnClick="ButtonUpdateFirstName_Click" Text="Update" />
    </form>
</body>
</html>
