<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="DeleteModule.aspx.cs" Inherits="BureauOnderwijs.Views.DeleteModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>Module Verwijderen</h1>
    <div>
    <p >
    Voer een Module ID in: 
    <asp:TextBox ID="TBDelete" runat="server"></asp:TextBox><asp:Button ID="DeleteModuleButton" runat="server" Text="Delete" OnClick="DeleteId_Click" OnClientClick="return confirm('Weet je het zeker?')" Width="116px" />
    </p>
        </div>
    <asp:GridView Width="1500px" ID="GVDeleteModule" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
</asp:Content>

