<%@ Page Title="" Language="C#" MasterPageFile="~/BO.Master" AutoEventWireup="true" CodeBehind="Wensen.aspx.cs" Inherits="BureauOnderwijs.Wensen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Wens toevoegen
        </h1>
        <h4>
            Blok: <asp:DropDownList ID="DropDownListBlokperiode" runat="server"></asp:DropDownList>
        </h4>
        <h4>
            Week: <asp:DropDownList ID="DropDownListWeek" runat="server"></asp:DropDownList>
        </h4>
        <h4>
            Dag: <asp:DropDownList ID="DropDownListDag" runat="server"></asp:DropDownList>
        </h4>
    </div>



</asp:Content>