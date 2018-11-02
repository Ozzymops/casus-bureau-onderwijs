<%@ Page Title="Roosteroverzicht" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roosteroverzicht.aspx.cs" Inherits="BureauOnderwijs.Views.Roosteroverzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Script manager -->
    <asp:ScriptManager ID="manager" runat="server"></asp:ScriptManager>
    <!-- On screen -->
    <div id="schedule" style="padding: 10px; float: left;">
        <p>Rooster van: <asp:DropDownList ID="UserDropdownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userList_SelectedIndexChanged"></asp:DropDownList>
           Periode: <asp:DropDownList ID="PeriodDropdownList" runat="server" AutoPostBack="True"></asp:DropDownList>
           Week: <asp:DropDownList ID="WeekDropdownList" runat="server" AutoPostBack="True"></asp:DropDownList>
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
    <div id="controls" class="controls_div_main">
        <div id="controls_persistent">
            <asp:DropDownList ID="PanelDropdownList" CssStyle="controls_label" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PanelDropdownList_SelectedIndexChanged">
                <asp:ListItem Value="0">Toevoegen</asp:ListItem>
                <asp:ListItem Value="1">Wijzigen</asp:ListItem>
                <asp:ListItem Value="2">Verwijderen</asp:ListItem>
            </asp:DropDownList>
            <!-- niet verwijderen! --><asp:Button ID="ButtonFoutControle" runat="server" OnClick="ButtonFoutControle_Click" style="margin-left: 31px" Text="Fout Controle" Width="112px" />
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
            <p><asp:Button ID="AddButton" runat="server" Text="Toevoegen aan rooster" /></p>
        </div>
        <div id="edit_controls" runat="server">
            <p id="edit_top">
                <asp:DataList ID="LectureDataList" runat="server" CellPadding="4" ForeColor="#333333">
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderTemplate>
                        <table style="border:2px solid black; text-align:left; width:800px;">
                            <thead>
                                 <tr>
                                    <th>Id</th>
                                    <th>Docent</th>
                                    <th>Module</th>
                                </tr>
                            </thead>       
                        <tbody>
                            </HeaderTemplate>
                        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("LectureId") %></td>
                                <td><%#Eval("TeacherId") %></td>
                                <td><%#Eval("ModuleCode") %></td>
                            </tr>
                        </ItemTemplate>
           
                        <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
           
                        <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:DataList>
            </p>
        </div>
        <div id="remove_controls" runat="server" style="display: none">

        </div>
    </div>
</asp:Content>
