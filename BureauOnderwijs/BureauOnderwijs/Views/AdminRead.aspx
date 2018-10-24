<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminRead.aspx.cs" Inherits="BureauOnderwijs.Views.AdminRead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Gebruikers
    </h1>

    <div>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Emailadress" HeaderText="Email-adres" />
                <asp:BoundField DataField="Firstname" HeaderText="Voornaam" />
                <asp:BoundField DataField="Lastname" HeaderText="Achternaam" />
                <asp:BoundField DataField="Role" HeaderText="Functie" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
