<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="DeleteModule.aspx.cs" Inherits="BureauOnderwijs.Views.DeleteModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    Voer een ID in:
    <asp:TextBox ID="TBDelete" runat="server"></asp:TextBox><asp:Button ID="DeleteModuleButton" runat="server" Text="Delete" OnClick="DeleteId_Click" />
    <asp:GridView ID="GVDeleteModule" runat="server"></asp:GridView>
</asp:Content>

