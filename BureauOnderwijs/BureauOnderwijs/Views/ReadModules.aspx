<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="ReadModules.aspx.cs" Inherits="BureauOnderwijs.Views.ReadModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Modules
    </h1>
<asp:DataList ID="DLModules" runat="server">
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
                </tr>
            </ItemTemplate>
           
            <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:DataList>
</asp:Content>
