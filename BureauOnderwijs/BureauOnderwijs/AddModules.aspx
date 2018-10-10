<%@ Page Title="" Language="C#" MasterPageFile="~/NestedModule.master" AutoEventWireup="true" CodeBehind="AddModules.aspx.cs" Inherits="BureauOnderwijs.TestNest" %>
<asp:Content ID="NestedContent" ContentPlaceHolderID="NestedContentHolder" runat="server">
    <div>
        <asp:Label ID="LBName" runat="server" Text="Naam: "></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: "></asp:Label>
        <asp:TextBox ID="TBModuleCode" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: "></asp:Label>
        Datumprikker
        </div>
    <div>
        <asp:Label ID="LBYear" runat="server" Text="Year: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: "></asp:Label>
        <asp:TextBox ID="TBFaculty" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: "></asp:Label>
        <asp:TextBox ID="TBProfile" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: "></asp:Label>
        <asp:TextBox ID="TBCredits" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: "></asp:Label>
        <asp:DropDownList ID="DropDownListExaminor" runat="server">
            <asp:ListItem>LIJST EXAMINATOREN</asp:ListItem>
        </asp:DropDownList>
        </div>
    <div>
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: "></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak ja/nee: "></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModule" runat="server" />
        </div>
    <div>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: "></asp:Label>
        <asp:TextBox ID="TBLectureHOurs" runat="server"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: "></asp:Label>
        <asp:TextBox ID="TBPracticalHOurs" runat="server"></asp:TextBox>
        </div>
</asp:Content>