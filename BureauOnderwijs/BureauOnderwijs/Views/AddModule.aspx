<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="BureauOnderwijs.Views.AddModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Modules Toevoegen
    </h1>
        <div>
        <asp:Label ID="LBName" runat="server" Text="Naam: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBName" runat="server" style="margin-right:20px" OnTextChanged="TBName_TextChanged"></asp:TextBox>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBFaculty" runat="server" style="margin-right:20px" OnTextChanged="TBFaculty_TextChanged"></asp:TextBox>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBLectureHours" runat="server" OnTextChanged="TBLectureHours_TextChanged"></asp:TextBox>
        <asp:Button ID="BTSend" runat="server" Text="Opslaan" style="margin-right:10px" OnClick="BTSend_Click" Width="90px" />
        </div>
    <div>
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBModuleCode" runat="server" style="margin-right:20px" OnTextChanged="TBModuleCode_TextChanged"></asp:TextBox>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBProfile" runat="server" style="margin-right:20px" OnTextChanged="TBProfile_TextChanged"></asp:TextBox>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBPracticalHours" runat="server" OnTextChanged="TBPracticalHOurs_TextChanged"></asp:TextBox>
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" style="margin-right:10px" OnClick="BTCancel_Click" Width="90px"/>
        </div>
    <div>
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBPeriod" runat="server" style="margin-right:20px" OnTextChanged="TBPeriod_TextChanged"></asp:TextBox>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBCredits" runat="server" style="margin-right:20px" OnTextChanged="TBCredits_TextChanged"></asp:TextBox>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak ja/nee: "></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModule" runat="server" OnCheckedChanged="CheckBoxGeneralModule_CheckedChanged" />
        </div>
    <div>
        <asp:Label ID="LBYear" runat="server" Text="Year: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBYear" runat="server" style="margin-right:20px" OnTextChanged="TBYear_TextChanged"></asp:TextBox>
        <asp:Label ID="LBDocent" runat="server" Text="Docent:" Width="95px"></asp:Label>
        <asp:DropDownList ID="DDDocent1" runat="server">
            <asp:ListItem>Docent 1</asp:ListItem>
            <asp:ListItem>Docent 2</asp:ListItem>
            <asp:ListItem>Docent 3</asp:ListItem>
            <asp:ListItem>Docent 4</asp:ListItem>
            <asp:ListItem>Docent 5</asp:ListItem>
        </asp:DropDownList>
        </div>
    <div>
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server" style="margin-right:20px" OnTextChanged="TBDescription_TextChanged"></asp:TextBox>
        <asp:Label ID="LBDocent2" runat="server" Text="Docent 2:" Width="95px"></asp:Label>
        <asp:DropDownList ID="DDDocent2" runat="server">
            <asp:ListItem>Docent 1</asp:ListItem>
            <asp:ListItem>Docent 2</asp:ListItem>
            <asp:ListItem>Docent 3</asp:ListItem>
            <asp:ListItem>Docent 4</asp:ListItem>
            <asp:ListItem>Docent 5</asp:ListItem>
            <asp:ListItem>N.V.T.</asp:ListItem>
        </asp:DropDownList>
        </div>
    <div>
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: " Width="95px"></asp:Label>
        <asp:TextBox ID="DropDownListExaminor" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBDocent3" runat="server" Text="Docent 3:" Width="95px"></asp:Label>
        <asp:DropDownList ID="DDDocent3" runat="server">
            <asp:ListItem>Docent 1</asp:ListItem>
            <asp:ListItem>Docent 2</asp:ListItem>
            <asp:ListItem>Docent 3</asp:ListItem>
            <asp:ListItem>Docent 4</asp:ListItem>
            <asp:ListItem>Docent 5</asp:ListItem>
            <asp:ListItem>N.V.T.</asp:ListItem>
        </asp:DropDownList>
        </div>
    <h6>Alle velden moeten worden ingevuld behalve Docent 2 en Docent 3</h6>
</asp:Content>
