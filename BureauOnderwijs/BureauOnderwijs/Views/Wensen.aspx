<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WensenMaster.Master" AutoEventWireup="true" CodeBehind="Wensen.aspx.cs" Inherits="BureauOnderwijs.Views.Wensen" %>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedPlaceHolder1" runat="server">
    
    <asp:DataList ID="DataListWensen" runat="server">
        <HeaderTemplate>
            <table style="border:2px solid black; text-align:left; width:800px;">
                <thead>
                     <tr>
                        <th>Wens nummer</th>
                        <th>Dag</th>
                        <th>Week</th>
                        <th>Blok</th>
                        <th>Start uur</th>
                        <th>Start minuut</th>
                        <th>Eind uur</th>
                        <th>Eind minuut</th>
                    </tr>
                </thead>       
            <tbody>
                </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("WishId") %></td>
                    <td><%#Eval("Day") %></td>
                    <td><%#Eval("Week") %></td>
                    <td><%#Eval("Period") %></td>
                    <td><%#Eval("StartHour") %></td>
                    <td><%#Eval("StartMinute") %></td>
                    <td><%#Eval("EndHour") %></td>
                    <td><%#Eval("EndMinute") %></td>
                </tr>
            </ItemTemplate>
           
            <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:DataList>
</asp:Content>