﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="BureauOnderwijs.Views.AddModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <%--Header van de pagina--%>
    <h1>
        Modules Toevoegen
    </h1>
    <%--De verschillende labels en tekstboxes op de pagina--%>
        <div>
        <asp:Label ID="LBName" runat="server" Text="Naam: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBName" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: " Width="95px"></asp:Label>
            <asp:DropDownList ID="DDFaculty" runat="server" style="margin-right:20px" Width="174px">
                <asp:ListItem>---------------Select---------------</asp:ListItem>
                <asp:ListItem>ICT</asp:ListItem>
            </asp:DropDownList>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBLectureHours" runat="server" ></asp:TextBox>
        <asp:Button ID="BTSend" runat="server" Text="Opslaan" style="margin-right:10px" OnClick="BTSend_Click" Width="90px" />
        </div>
    <div>
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBModuleCode" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: " Width="95px"></asp:Label>
        <asp:DropDownList ID="DDProfile" runat="server" style="margin-right:20px" Width="174px">
            <asp:ListItem>---------------Select---------------</asp:ListItem>
            <asp:ListItem>Bachelor</asp:ListItem>
            <asp:ListItem>Asociate-Degree</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBPracticalHours" runat="server" ></asp:TextBox>
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" style="margin-right:10px" OnClick="BTCancel_Click" Width="90px"/>
        </div>
    <div>
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBPeriod" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBCredits" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak:" Width="120px"></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModule" runat="server" />
        </div>
    <div>
        <asp:Label ID="LBYear" runat="server" Text="Year: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBYear" runat="server" style="margin-right:20px"  ></asp:TextBox>
        <asp:Label ID="LBDocent" runat="server" Text="Docent:" Width="95px"></asp:Label>
        <asp:TextBox ID="TBDocent" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server" style="margin-right:20px" ></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: " Width="95px"></asp:Label>
        <asp:DropDownList ID="DDExaminer" runat="server" Width="174px">
            <asp:ListItem>---------------Select---------------</asp:ListItem>
            <asp:ListItem Value="1">Dhr. test1</asp:ListItem>
            <asp:ListItem Value="2">Dhr. Test2</asp:ListItem>
        </asp:DropDownList>
        </div>
    <%--Header gebruikt als footer voor een requirement weer te geven voor een update uitgevoerd kan worden--%>
    <h6>Alle velden moeten worden ingevuld</h6>
</asp:Content>
