﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WensenMaster.master" AutoEventWireup="true" CodeBehind="WensToevoegen.aspx.cs" Inherits="BureauOnderwijs.Views.WensToevoegen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
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
