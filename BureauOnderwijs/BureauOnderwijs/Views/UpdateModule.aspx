<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="UpdateModule.aspx.cs" Inherits="BureauOnderwijs.Views.UpdateModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
<h1>Module wijzigen</h1>
    <h4>Klik op wijzigen bij een module op de gegevens op te halen</h4>
            <div style="margin-left: 30px">
        <asp:Label ID="LBName" runat="server" Text="Naam: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBNameU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBFacultyU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBLectureHoursU" runat="server" ></asp:TextBox>
        <asp:Button ID="BTUpdate" runat="server" Text="Aanpassen" style="margin-right:10px" OnClick="BTUpdate_Click" OnClientClick="return confirm('Gegevens aanpassen?')" Width="90px" />
        </div>
    <div style="margin-left: 30px">
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBModuleCodeU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBProfileU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBPracticalHoursU" runat="server" ></asp:TextBox>
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" style="margin-right:10px" OnClick="BTCancel_Click" Width="90px"/>
        </div>
    <div style="margin-left: 30px">
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBPeriodU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBCreditsU" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak ja/nee: "></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModuleU" runat="server" />
        </div>
    <div style="margin-left: 30px">
        <asp:Label ID="LBYear" runat="server" Text="Year: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBYearU" runat="server" style="margin-right:20px" ></asp:TextBox>
        </div>
    <div style="margin-left: 30px">
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBDescriptionU" runat="server" style="margin-right:20px" ></asp:TextBox>
        </div>
    <div style="margin-left: 30px">
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: " Width="95px"></asp:Label>
        <asp:DropDownList ID="DropDownListExaminorU" runat="server"> 
        <asp:ListItem>
            Lijst examinatoren
        </asp:ListItem>
            <asp:ListItem Value="1">Dhr. NoName</asp:ListItem>
            <asp:ListItem Value="2">Peroon B</asp:ListItem>
            <asp:ListItem Value="3">Persoon C</asp:ListItem>
            <asp:ListItem Value="4">Persoon D</asp:ListItem>
        </asp:DropDownList>
        </div>
    <br />

        <asp:GridView style="margin-left:auto; margin-right:auto;" Width="1500px" ID="GVUpdateModule" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GVUpdateModule_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField Text="Aanpassen" />
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
