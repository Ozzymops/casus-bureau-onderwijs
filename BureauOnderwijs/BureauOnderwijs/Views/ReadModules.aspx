<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="ReadModules.aspx.cs" Inherits="BureauOnderwijs.Views.ReadModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>
        Modules
    </h1>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="1400px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ModuleId" AllowPaging="True"  >
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="ModuleCode" HeaderText="ModuleCode" SortExpression="ModuleCode" />
                <asp:BoundField DataField="Period" HeaderText="Period" SortExpression="Period" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:BoundField DataField="Faculty" HeaderText="Faculty" SortExpression="Faculty" />
                <asp:BoundField DataField="Profile" HeaderText="Profile" SortExpression="Profile" />
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
                <asp:BoundField DataField="Examinor" HeaderText="Examinor" SortExpression="Examinor" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CheckBoxField DataField="GeneralModule" HeaderText="GeneralModule" SortExpression="GeneralModule" />
                <asp:BoundField DataField="LectureHours" HeaderText="LectureHours" SortExpression="LectureHours" />
                <asp:BoundField DataField="PracticalHours" HeaderText="PracticalHours" SortExpression="PracticalHours" />
                <asp:BoundField DataField="ModuleId" HeaderText="ModuleId" InsertVisible="False" ReadOnly="True" SortExpression="ModuleId" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BureauonderwijsdatabaseConnectionString %>" 
            SelectCommand="SELECT [Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours], [ModuleId] FROM [Module]" 
            DeleteCommand="DELETE FROM [Module] WHERE [ModuleId] = @ModuleId" 
            InsertCommand="INSERT INTO [Module] ([Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours]) VALUES (@Name, @ModuleCode, @Period, @Year, @Faculty, @Profile, @Credits, @Examinor, @Description, @GeneralModule, @LectureHours, @PracticalHours)" 
            UpdateCommand="UPDATE [Module] SET [Name] = @Name, [ModuleCode] = @ModuleCode, [Period] = @Period, [Year] = @Year, [Faculty] = @Faculty, [Profile] = @Profile, [Credits] = @Credits, [Examinor] = @Examinor, [Description] = @Description, [GeneralModule] = @GeneralModule, [LectureHours] = @LectureHours, [PracticalHours] = @PracticalHours WHERE [ModuleId] = @ModuleId">
            <DeleteParameters>
                <asp:Parameter Name="ModuleId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="ModuleCode" Type="String" />
                <asp:Parameter Name="Period" Type="Int32" />
                <asp:Parameter Name="Year" Type="String" />
                <asp:Parameter Name="Faculty" Type="String" />
                <asp:Parameter Name="Profile" Type="String" />
                <asp:Parameter Name="Credits" Type="Int32" />
                <asp:Parameter Name="Examinor" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="GeneralModule" Type="Boolean" />
                <asp:Parameter Name="LectureHours" Type="Int32" />
                <asp:Parameter Name="PracticalHours" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="ModuleCode" Type="String" />
                <asp:Parameter Name="Period" Type="Int32" />
                <asp:Parameter Name="Year" Type="String" />
                <asp:Parameter Name="Faculty" Type="String" />
                <asp:Parameter Name="Profile" Type="String" />
                <asp:Parameter Name="Credits" Type="Int32" />
                <asp:Parameter Name="Examinor" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="GeneralModule" Type="Boolean" />
                <asp:Parameter Name="LectureHours" Type="Int32" />
                <asp:Parameter Name="PracticalHours" Type="Int32" />
                <asp:Parameter Name="ModuleId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
