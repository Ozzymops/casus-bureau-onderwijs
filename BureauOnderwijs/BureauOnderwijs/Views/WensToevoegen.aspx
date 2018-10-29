<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WensenMaster.master" AutoEventWireup="true" CodeBehind="WensToevoegen.aspx.cs" Inherits="BureauOnderwijs.Views.WensToevoegen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <div>
        <h1>
            Wens toevoegen
        </h1>


        <asp:GridView ID="gvUserWishes" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="WishId" ShowHeaderWhenEmpty="true" 
            
            OnRowCommand="gvUserWishes_RowCommand"
            
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="gvUserWishes_SelectedIndexChanged">
            <%-- THEME VAN DE GV --%>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />

            <Columns>
                <%-- Wens ID --%>
                <asp:TemplateField HeaderText="Wens ID">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("WishId")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        
                    </EditItemTemplate>
                    <FooterTemplate>
                        
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Blok periode --%>
                <asp:TemplateField HeaderText="Blok">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Period")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxPeriod" Text='<%# Eval("Period")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListPeriod" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Week --%>
                <asp:TemplateField HeaderText="Week">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Week")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxWeek" Text='<%# Eval("Week")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListWeek" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Dag --%>
                <asp:TemplateField HeaderText="Dag">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Day")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxDay" Text='<%# Eval("Day")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListDag" runat="server">
                            <asp:ListItem>Maandag</asp:ListItem>
                            <asp:ListItem>Dinsdag</asp:ListItem>
                            <asp:ListItem>Woensdag</asp:ListItem>
                            <asp:ListItem>Donderdag</asp:ListItem>
                            <asp:ListItem>Vrijdag</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Start uur --%>
                <asp:TemplateField HeaderText="Start uur">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("StartHour")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxWStartTimeHour" Text='<%# Eval("StartHour")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListStartTijdUur" runat="server">
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Start minuut --%>
                <asp:TemplateField HeaderText="Start minuut">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("StartMinute")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxWStartTimeMinute" Text='<%# Eval("StartMinute")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListStartTijdMinuut" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Eind tijd --%>
                <asp:TemplateField HeaderText="Eind tijd">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("EndHour")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxEndTime" Text='<%# Eval("EndHour")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListEindTijdUur" runat="server">
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%-- Eind minuut --%>
                <asp:TemplateField HeaderText="Eind minuut">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("EndMinute")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textboxEndTimeMinute" Text='<%# Eval("EndMinute")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListEndTijdMinuut" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <%-- Logo's --%> 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Resources/Edit logo.jpg" runat="server" CommandName="UserEdit" ToolTip="Wijzigen" Width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/Resources/Delete logo.jpg" runat="server" CommandName="Delete" ToolTip="Verwijderen" Width="20px" Height="20px"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Resources/Opslaan logo.jpg" runat="server" CommandName="Update" ToolTip="Opslaan" Width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/Resources/Annuleren logo.png" runat="server" CommandName="Cancel" ToolTip="Annuleren" Width="20px" Height="20px"/>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Resources/Toevoegen logo.jpg" runat="server" CommandName="AddNew" ToolTip="Toevoegen" Width="20px" Height="20px"/>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="LabelSuccesvol" runat="server" Text="In afwachting..."></asp:Label>
    </div>
</asp:Content>
