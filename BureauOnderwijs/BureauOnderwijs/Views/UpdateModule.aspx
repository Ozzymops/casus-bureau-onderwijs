<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="UpdateModule.aspx.cs" Inherits="BureauOnderwijs.Views.UpdateModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
<h1>Module wijzigen</h1>
    <h4>Klik op wijzigen bij een module op de gegevens op te halen</h4>
        <asp:GridView style="margin-left:auto; margin-right:auto;" Width="1500px" ID="GVUpdateModule" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
            <Columns>
                <asp:ButtonField Text="Aanpassen" CommandName="update"/>
            </Columns>
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
