<%@ Page Title="Roosteroverzicht" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roosteroverzicht.aspx.cs" Inherits="BureauOnderwijs.Views.Roosteroverzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Script manager -->
    <asp:ScriptManager ID="manager" runat="server"></asp:ScriptManager>
    <!-- On screen -->
    <div id="schedule" style="padding: 10px; float: left;">
        <p>Rooster van: <asp:DropDownList ID="userList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userList_SelectedIndexChanged"></asp:DropDownList>
           Periode: <asp:DropDownList ID="periodList" runat="server" AutoPostBack="True"></asp:DropDownList>
           Week: <asp:DropDownList ID="weekList" runat="server" AutoPostBack="True"></asp:DropDownList>
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
        <p><asp:Button ID="saveButton" runat="server" Text="Opslaan" OnClick="saveButton_Click" /></p>
    </div>
    <div id="controls" class="controls">
        <asp:Button ID="ButtonFoutControle" runat="server" OnClick="ButtonFoutControle_Click" style="margin-left: 31px" Text="Fout Controle" Width="112px" />
        <div id="wishList">
            <asp:ListBox ID="WishListBoxA" runat="server" CssClass="wishList"></asp:ListBox>
        </div>
        <div id="add_controls"> <!-- werk later bij -->
            <p>Toevoegen: <asp:Label ID="TestLabel" runat="server" Text="TestLabel" CssClass="controlsAsp"></asp:Label></p>
            <p>Dag: <asp:DropDownList ID="dayList" runat="server" CssClass="controlsAsp" AutoPostBack="True"></asp:DropDownList></p>
            <p>Vak: <asp:DropDownList ID="moduleList" runat="server" CssClass="controlsAsp"></asp:DropDownList></p>
            <p>Klas: <asp:TextBox ID="groupTextBox" runat="server" CssClass="controlsAsp"></asp:TextBox></p>
            <p>Starttijd: 
                <asp:TextBox ID="StartTimeTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Eindtijd: 
                <asp:TextBox ID="EndTimeTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Lokaal: <asp:TextBox ID="roomTextBox" runat="server" CssClass="controlsAsp"></asp:TextBox></p>
            <asp:Button ID="addButton" runat="server" Text="Toevoegen" OnClick="addButton_Click" CssClass="controlsline" />
        </div>
        <div id="edit_controls" style="display: none">

        </div>
        <div id="remove_controls" style="display: none"> <!-- werk later bij -->
            <asp:ListBox ID="LectureListBoxR" runat="server"></asp:ListBox>
            <asp:Button ID="deleteButton" runat="server" Text="Verwijderen" OnClick="deleteButton_Click" />
        </div>
    </div>
</asp:Content>
