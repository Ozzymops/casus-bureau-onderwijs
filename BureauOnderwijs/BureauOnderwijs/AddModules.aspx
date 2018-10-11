<%@ Page Title="" Language="C#" MasterPageFile="~/NestedModule.master" AutoEventWireup="true" CodeBehind="AddModules.aspx.cs" Inherits="BureauOnderwijs.TestNest" %>
<asp:Content ID="NestedContent" ContentPlaceHolderID="NestedContentHolder" runat="server">
    <div>
        <asp:Label ID="LBName" runat="server" Text="Naam: " style="margin-right:50px"></asp:Label>
        <asp:TextBox ID="TBName" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: " style="margin-right:5px"></asp:Label>
        <asp:TextBox ID="TBFaculty" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: " style="margin-right:20px"></asp:Label>
        <asp:TextBox ID="TBLectureHours" runat="server"></asp:TextBox>
        <asp:Button ID="BTSend" runat="server" Text="Opslaan" align="right" />
        </div>
    <div>
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: " style="margin-right:2px"></asp:Label>
        <asp:TextBox ID="TBModuleCode" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: " style="margin-right:16px"></asp:Label>
        <asp:TextBox ID="TBProfile" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: " style="margin-right:19px"></asp:Label>
        <asp:TextBox ID="TBPracticalHOurs" runat="server"></asp:TextBox>
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" align="right"/>
        </div>
    <div>
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: " style="margin-right:40px"></asp:Label>
        <asp:TextBox ID="TBPeriod" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: " style="margin-right:14px"></asp:Label>
        <asp:TextBox ID="TBCredits" runat="server" style="margin-right:20px"></asp:TextBox>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak ja/nee: "></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModule" runat="server" />
        </div>
    <div>
        <asp:Label ID="LBYear" runat="server" Text="Year: " style="margin-right:60px"></asp:Label>
        <asp:TextBox ID="TBYear" runat="server" style="margin-right:20px"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: " style="margin-right:1px"></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server" style="margin-right:20px"></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: " style="margin-right:15px"></asp:Label>
        <asp:DropDownList ID="DropDownListExaminor" runat="server"> 
        <asp:ListItem>LIJST EXAMINATOREN</asp:ListItem>
        </asp:DropDownList>
        </div>
</asp:Content>