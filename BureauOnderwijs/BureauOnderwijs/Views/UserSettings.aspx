<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="BureauOnderwijs.Views.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-area">
        
        <div id="content-row">
            <asp:Label ID="Label1" runat="server" Text="Voornaam:  "></asp:Label>
            &nbsp;
            &nbsp;
            <asp:TextBox ID="TextBoxVoornaam" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSaveVoornaam" runat="server" Text="Update" Height="25px" OnClick="ButtonSaveVoornaam_Click" />
        </div>
        
        <div id="empty">

        </div>
        
        <div id="content-row">
            <asp:Label ID="Label2" runat="server" Text="Achternaam:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBoxAchternaam" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSaveAchternaam" runat="server" Height="21px" Text="Update" OnClick="ButtonSaveAchternaam_Click" />
        </div>      
        
        <div id="empty">

        </div>

        <div id="content-row">
            <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSaveEmail" runat="server" Height="24px" style="margin-top: 0px" Text="Update" OnClick="ButtonSaveEmail_Click" />
        </div>

        <div id="empty">

        </div>

        <div id="content-row">

            <asp:Label ID="Label4" runat="server" Text="Nieuw Wachtwoord:  "></asp:Label>
            <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Huidig Wachtwoord:"></asp:Label>
            <asp:TextBox ID="TextBoxCurrentPassword" runat="server"></asp:TextBox>

        </div>

        <div id="empty">

        </div>

        <div id="content-row">

            <asp:Label ID="Label5" runat="server" Text="Nieuw Wachtwoord Opnieuw:"></asp:Label>
            <asp:TextBox ID="TextBoxNewPassword2" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSavePassword" runat="server" Height="24px" Text="Update" OnClick="ButtonSavePassword_Click" />

        </div>

    </div> <!-- einde content-area -->
    
    
</asp:Content>
