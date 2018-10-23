<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminCreate.aspx.cs" Inherits="BureauOnderwijs.Views.AdminCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Gebruiker toevoegen
    </h1>

    <div>
        <asp:Label ID="LBUsername" runat="server" Text="Username: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBUsername" runat="server" style="margin-right:20px" OnTextChanged="TBUsername_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LBPassword" runat="server" Text="Password: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBPassword" runat="server" style="margin-right:20px" OnTextChanged="TBPassword_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LBEmail" runat="server" Text="E-mailadres: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server" style="margin-right:20px" OnTextChanged="TBEmail_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LBFirstName" runat="server" Text="Voornaam: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBFirstName" runat="server" style="margin-right:20px" OnTextChanged="TBEmail_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LBLastName" runat="server" Text="Achternaam: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBLastName" runat="server" style="margin-right:20px" OnTextChanged="TBEmail_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LBRole" runat="server" Text="Role: " Width="120px"></asp:Label>
        <asp:DropDownList ID="DropDownListRole" runat="server" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged"> 
        <asp:ListItem Value="0">Docent</asp:ListItem>
        <asp:ListItem Value="1">Roostermaker</asp:ListItem>
        <asp:ListItem Value="2">Examinator</asp:ListItem>
        <asp:ListItem Value="3">Administrator</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <br />
        <asp:Button ID="BTSend" runat="server" Text="Opslaan" style="margin-left:10px" OnClick="BTSend_Click" Width="90px" />
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" style="margin-left:20px" OnClick="BTCancel_Click" Width="90px"/>
        <br />
    </div>
</asp:Content>
