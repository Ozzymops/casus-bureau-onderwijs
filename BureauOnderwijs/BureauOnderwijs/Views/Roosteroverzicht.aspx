<%@ Page Title="Roosteroverzicht" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roosteroverzicht.aspx.cs" Inherits="BureauOnderwijs.Views.Roosteroverzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Script manager -->
    <asp:ScriptManager ID="manager" runat="server"></asp:ScriptManager>
    <!-- On screen -->
    <div id="schedule" style="padding: 10px; float: left;">
        <p>Rooster van: <asp:DropDownList ID="UserDropdownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UserDropdownList_SelectedIndexChanged"></asp:DropDownList>
           Periode: <asp:DropDownList ID="PeriodDropdownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PeriodDropdownList_SelectedIndexChanged"></asp:DropDownList>
           Week: <asp:DropDownList ID="WeekDropdownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="WeekDropdownList_SelectedIndexChanged"></asp:DropDownList>
        </p>
        <asp:GridView ID="MainGridView" runat="server" Width="1000px" CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="schedule">
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
    <div id="controls" class="controls_div_main" style="float: left;">
        <div id="controls_persistent">
            <asp:DropDownList ID="PanelDropdownList" CssStyle="controls_label" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PanelDropdownList_SelectedIndexChanged">
                <asp:ListItem Value="0">Toevoegen</asp:ListItem>
                <asp:ListItem Value="1">Wijzigen/Verwijderen</asp:ListItem>
            </asp:DropDownList>
            <!-- niet verwijderen! --><asp:Button ID="ButtonFoutControle" runat="server" style="margin-left: 31px" Text="Fout Controle" Width="112px" OnClick="ButtonFoutControle_Click" />
        </div>
        <div id="add_controls" runat="server">          
            <p id="add_top">
                <asp:Label ID="DayLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Dag:"></asp:Label>
                <asp:DropDownList ID="DayDropdownList" CssClass="controls_dropdownlist" Width="100px" runat="server"></asp:DropDownList>
                <asp:Label ID="ModuleLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Module:"></asp:Label>
                <asp:DropDownList ID="ModuleDropdownList" CssClass="controls_dropdownlist" Width="100px" runat="server"></asp:DropDownList>
            </p>
            <p id="add_mid">
                <asp:Label ID="ClassroomLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Lokaal:"></asp:Label>
                <asp:TextBox ID="ClassroomTextBox" CssClass="controls_textbox" Width="97px" runat="server"></asp:TextBox>
                <asp:Label ID="StudentGroupLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Klas:"></asp:Label>
                <asp:TextBox ID="StudentGroupTextBox" CssClass="controls_textbox" Width="96px" runat="server"></asp:TextBox>
            </p>
            <p id="add_bot">
                <asp:Label ID="TimeStartLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Start:"></asp:Label>
                <asp:TextBox ID="TimeStartHourTextBox" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:TextBox ID="TimeStartMinuteTextBox" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:Label ID="TimeEndLabel" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Eind:"></asp:Label>
                <asp:TextBox ID="TimeEndHourTextBox" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:TextBox ID="TimeEndMinuteTextBox" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
            </p>
            <p><asp:Button ID="AddButton" runat="server" Text="Toevoegen aan rooster" OnClick="AddButton_Click"/></p>
        </div>
        <div id="edit_controls" runat="server">
            <p id="edit_top">
                <asp:Label ID="LectureLabel" runat="server" Text="Lessen voor xxx:"></asp:Label>
                <asp:GridView ID="EditGridView" runat="server" Width="600px" CellPadding="4" ForeColor="#333333" GridLines="Both">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="False" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" /></asp:GridView>
            </p>
            <p id="edit_topmid" runat="server">
                <asp:Label ID="LectureIdLabel" Font-Bold="true" CssClass="controls_label" runat="server" Text="LesId:"></asp:Label>
                <asp:DropDownList ID="LectureIdDropdownList" CssClass="controls_dropdownlist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LectureIdDropdownList_SelectedIndexChanged"></asp:DropDownList>
            </p>
            <p id="edit_mid" runat="server">
                <asp:Label ID="DayLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Dag:"></asp:Label>
                <asp:DropDownList ID="DayDropdownList_E" CssClass="controls_dropdownlist" Width="100px" runat="server"></asp:DropDownList>
                <asp:Label ID="ModuleLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Module:"></asp:Label>
                <asp:DropDownList ID="ModuleDropdownList_E" CssClass="controls_dropdownlist" Width="100px" runat="server"></asp:DropDownList>
            </p>
            <p id="edit_botmid" runat="server">
                <asp:Label ID="ClassroomLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Lokaal:"></asp:Label>
                <asp:TextBox ID="ClassroomTextBox_E" CssClass="controls_textbox" Width="97px" runat="server"></asp:TextBox>
                <asp:Label ID="StudentGroupLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Klas:"></asp:Label>
                <asp:TextBox ID="StudentGroupTextBox_E" CssClass="controls_textbox" Width="96px" runat="server"></asp:TextBox>
            </p>
            <p id="edit_bot" runat="server">
                <asp:Label ID="TimeStartLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Start:"></asp:Label>
                <asp:TextBox ID="TimeStartHourTextBox_E" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:TextBox ID="TimeStartMinuteTextBox_E" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:Label ID="TimeEndLabel_E" Font-Bold="true" CssClass="controls_label" Width="50px" runat="server" Text="Eind:"></asp:Label>
                <asp:TextBox ID="TimeEndHourTextBox_E" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
                <asp:TextBox ID="TimeEndMinuteTextBox_E" CssClass="controls_textbox" Width="45px" runat="server"></asp:TextBox>
            </p>
            <p id="edit_but" runat="server"><asp:Button ID="EditButton" runat="server" Text="Wijzigen in rooster" OnClick="EditButton_Click"/><asp:Button ID="DeleteButton" runat="server" Text="Verwijderen uit rooster" OnClick="DeleteButton_Click"/></p>
        </div>
    </div>
</asp:Content>
