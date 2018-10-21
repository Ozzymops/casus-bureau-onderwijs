<%@ Page Title="Roosteroverzicht" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roosteroverzicht.aspx.cs" Inherits="BureauOnderwijs.Views.Roosteroverzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 1232px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Script manager -->
    <asp:ScriptManager ID="manager" runat="server"></asp:ScriptManager>
    <!-- On screen -->
    <div id="schedule" style="padding: 10px; float: left;">
        <p>Rooster van: <asp:DropDownList ID="userList" runat="server">
            <asp:ListItem Value="0">Docent 1</asp:ListItem>
            <asp:ListItem Value="1">Docent 2</asp:ListItem>
            <asp:ListItem Value="2">Docent 3</asp:ListItem>
        </asp:DropDownList></p>
        <!-- Table -->
        <asp:Table ID="table" runat="server" Width="1140px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Tijd</asp:TableCell>
                <asp:TableCell runat="server">Maandag</asp:TableCell>
                <asp:TableCell runat="server">Dinsdag</asp:TableCell>
                <asp:TableCell runat="server">Woensdag</asp:TableCell>
                <asp:TableCell runat="server">Donderdag</asp:TableCell>
                <asp:TableCell runat="server">Vrijdag</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">09:00</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">09:30</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="controls">
        <p>Toevoegen:</p>
        <!-- Wordt dynamisch aangepast op basis van beschikbaarheid docent! -->
        <p>Dag: <asp:DropDownList ID="dayList" runat="server">
            <asp:ListItem Value="0">Maandag</asp:ListItem>
            <asp:ListItem Value="1">Dinsdag</asp:ListItem>
            <asp:ListItem Value="2">Woensdag</asp:ListItem>
            <asp:ListItem Value="3">Donderdag</asp:ListItem>
            <asp:ListItem Value="4">Vrijdag</asp:ListItem>
            </asp:DropDownList></p>
        <!-- Wordt dynamisch aangepast op basis van docent! -->
        <p>Vak: <asp:DropDownList ID="moduleList" runat="server">
            <asp:ListItem Value="0">Vak 1</asp:ListItem>
            <asp:ListItem Value="1">Vak 2</asp:ListItem>
            <asp:ListItem Value="2">Vak 3</asp:ListItem>
            </asp:DropDownList></p>
        <p>Starttijd: <asp:TextBox ID="startTextBox" runat="server"></asp:TextBox></p>
        <p>Eindtijd: <asp:TextBox ID="endTextBox" runat="server"></asp:TextBox></p>
        <p>Lokaal: <asp:TextBox ID="roomTextBox" runat="server"></asp:TextBox></p>
        <asp:Button ID="addButton" runat="server" Text="Toevoegen" />
    </div>
</asp:Content>
