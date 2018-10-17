<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="DeleteModule.aspx.cs" Inherits="BureauOnderwijs.Views.DeleteModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>Module Verwijderen</h1>
    <div style="text-align:center">
    <p >
    Voer een Module ID in: 
    <asp:TextBox ID="TBDelete" runat="server"></asp:TextBox><asp:Button ID="DeleteModuleButton" runat="server" Text="Delete" OnClick="DeleteId_Click" OnClientClick="return confirm('Weet je het zeker?')" Width="116px" />
    </p>
        </div>
    <asp:GridView style="margin-left:auto; margin-right:auto;" Width="1500px" ID="GVDeleteModule" runat="server"></asp:GridView>
</asp:Content>

