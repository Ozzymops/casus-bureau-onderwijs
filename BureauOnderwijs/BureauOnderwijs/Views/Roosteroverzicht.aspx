<%@ Page Title="Roosteroverzicht" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roosteroverzicht.aspx.cs" Inherits="BureauOnderwijs.Views.Roosteroverzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Script manager -->
    <asp:ScriptManager ID="manager" runat="server"></asp:ScriptManager>
    <!-- On screen -->
    <div id="schedule" style="padding: 10px; float: left;">
        <p>Rooster van: <asp:DropDownList ID="userList" runat="server">
        </asp:DropDownList>
            <asp:Button ID="RefreshButton" runat="server" OnClick="RefreshButton_Click" Text="Refresh" />
        </p>
        <asp:GridView ID="gr_schedule" runat="server" Width="1140px" CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="schedule">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
    <div id="controls">
        <p>Toevoegen:
            <asp:Label ID="TestLabel" runat="server" Text="TestLabel"></asp:Label>
        </p>
        <!-- Wordt dynamisch aangepast op basis van beschikbaarheid docent! -->
        <p>Dag: <asp:DropDownList ID="dayList" runat="server">
            <asp:ListItem Value="1">Maandag</asp:ListItem>
            <asp:ListItem Value="2">Dinsdag</asp:ListItem>
            <asp:ListItem Value="3">Woensdag</asp:ListItem>
            <asp:ListItem Value="4">Donderdag</asp:ListItem>
            <asp:ListItem Value="5">Vrijdag</asp:ListItem>
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
        <asp:Button ID="addButton" runat="server" Text="Toevoegen" OnClick="addButton_Click" />
    </div>
</asp:Content>
