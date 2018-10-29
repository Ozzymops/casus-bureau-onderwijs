<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminDelete.aspx.cs" Inherits="BureauOnderwijs.Views.AdminDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Gebruiker Verwijderen
    </h1>

    <div>
        <asp:Label ID="LBSelect" runat="server" style="margin-left:10px" Text="User-ID van de te verwijderen persoon: " ></asp:Label>
        <br />
        <asp:TextBox ID="TBUsername" runat="server" Width="145px" style="margin-left:10px" OnTextChanged="TBUsername_TextChanged"></asp:TextBox>
        <asp:Button ID="BTSelect" runat="server" Text="Selecteer" style="margin-left:10px" OnClick="BTSelect_Click" Width="90px"/>
        <br />
        <br />
        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Emailadress" HeaderText="Email-adres" />
                <asp:BoundField DataField="Firstname" HeaderText="Voornaam" />
                <asp:BoundField DataField="Lastname" HeaderText="Achternaam" />
                <asp:BoundField DataField="Role" HeaderText="Functie" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="BTDelete" runat="server" Text="Verwijder" style="margin-left:10px" OnClick="BTDelete_Click" Width="90px"/>
    </div>

</asp:Content>
