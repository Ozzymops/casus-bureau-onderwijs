<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="UpdateModule.aspx.cs" Inherits="BureauOnderwijs.Views.UpdateModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
<h1>Module wijzigen</h1>
    <h4>Klik op wijzigen bij een module op de gegevens op te halen</h4>
            <div>
        <asp:Label ID="LBName" runat="server" Text="Naam: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBName" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBFaculty" runat="server" Text="Faculteit: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBFaculty" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBLectureHours" runat="server" Text="Uren Hoorcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBLectureHours" runat="server" ></asp:TextBox>
        <asp:Button ID="BTUpdate" runat="server" Text="Aanpassen" style="margin-right:10px" OnClick="BTUpdate_Click" OnClientClick="return confirm('Gegevens aanpassen?')" Width="90px" />
        </div>
    <div>
        <asp:Label ID="LBModuleCode" runat="server" Text="Module Code: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBModuleCode" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBProfile" runat="server" Text="Profiel: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBProfile" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LbPracticalHours" runat="server" Text="Uren Werkcollege: " Width="120px"></asp:Label>
        <asp:TextBox ID="TBPracticalHours" runat="server" ></asp:TextBox>
        <asp:Button ID="BTCancel" runat="server" Text="Annuleren" style="margin-right:10px" OnClick="BTCancel_Click" Width="90px"/>
        </div>
    <div>
        <asp:Label ID="LBPeriod" runat="server" Text="Periode: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBPeriod" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBCredits" runat="server" Text="Credits: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBCredits" runat="server" style="margin-right:20px" ></asp:TextBox>
        <asp:Label ID="LBGeneralModule" runat="server" Text="Algemeen vak ja/nee: "></asp:Label>
        <asp:CheckBox ID="CheckBoxGeneralModule" runat="server" />
        </div>
    <div>
        <asp:Label ID="LBYear" runat="server" Text="Year: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBYear" runat="server" style="margin-right:20px" ></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBDescription" runat="server" Text="Omschrijving: " Width="95px"></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server" style="margin-right:20px" ></asp:TextBox>
        </div>
    <div>
        <asp:Label ID="LBExaminor" runat="server" Text="Examinator: " Width="95px"></asp:Label>
        <asp:DropDownList ID="DropDownListExaminor" runat="server"> 
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
    <asp:DataList ID="DLUpdateModule" runat="server" OnSelectedIndexChanged="DLUpdateModule_SelectedIndexChanged">
        <HeaderTemplate>
            <table style="border:2px solid black; text-align:left; margin-left:auto; margin-right:auto; width:1400px;">
                <thead>
                     <tr>
                        <th>Naam</th>
                        <th>Module Code</th>
                        <th>Periode</th>
                        <th>Jaar</th>
                        <th>Faculteit</th>
                        <th>Profiel</th>
                        <th>Credits</th>
                        <th>Examinator</th>
                        <th>Omschrijving</th>
                        <th>Algemeen vak</th>
                        <th>Hoorcolle uren</th>
                        <th>Praktijk uren</th>
                    </tr>
                </thead>       
            <tbody>
                </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Name") %></td>
                    <td><%#Eval("ModuleCode") %></td>
                    <td><%#Eval("Period") %></td>
                    <td><%#Eval("Year") %></td>
                    <td><%#Eval("Faculty") %></td>
                    <td><%#Eval("Profile") %></td>
                    <td><%#Eval("Credits") %></td>
                    <td><%#Eval("Examinor") %></td>
                    <td><%#Eval("Description") %></td>
                    <td><%#Eval("GeneralModule") %></td>
                    <td><%#Eval("LectureHours") %></td>
                    <td><%#Eval("PracticalHours") %></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ModuleId") %>' >Wijzigen</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
           
            <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:DataList>
</asp:Content>
