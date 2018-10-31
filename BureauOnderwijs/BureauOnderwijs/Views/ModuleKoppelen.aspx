<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ModuleMaster.master" AutoEventWireup="true" CodeBehind="ModuleKoppelen.aspx.cs" Inherits="BureauOnderwijs.Views.ModuleKoppelen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedPlaceholder1" runat="server">
    <h1>Modules linken aan docenten</h1>
    <h3>Kies een module en kies de docenten</h3>
    <asp:Label ID="LBModule" runat="server" Text="Module:" Width="70px"></asp:Label>
    <asp:DropDownList ID="DDModules" runat="server" Width="140px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LBDocent1" runat="server" Text="Docent 1:" Width="70px"></asp:Label>
    <asp:DropDownList ID="DDDocent1" runat="server" Width="140px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LBDocent2" runat="server" Text="Docent 2:" Width="70px"></asp:Label>
    <asp:DropDownList ID="DDDocent2" runat="server" Width="140px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LBDocent3" runat="server" Text="Docent 3:" Width="70px"></asp:Label>
    <asp:DropDownList ID="DDDocent3" runat="server" Width="140px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LBDocent4" runat="server" Text="Docent 4:" Width="70px"></asp:Label>
    <asp:DropDownList ID="DDDocent4" runat="server" Width="140px">
    </asp:DropDownList>
    
    <br />
    <div style="margin-left:70px">
    <asp:Button ID="BTOpslaan" runat="server" Text="Opslaan" OnClick="BTOpslaan_Click" Width="90px" />
    <asp:Button ID="BTAnnuleren" runat="server" Text="Annuleren" OnClick="BTAnnuleren_Click" Width="90px" />
        </div>
</asp:Content>
