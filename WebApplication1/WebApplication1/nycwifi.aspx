<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="nycwifi.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        NYC wifi spots
    </h2>
    <p>
        List of New York City Parks
                
    
        
    </p>
    <p>
        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                NAME:
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
                <br />
                ADDRESS:
                <asp:Label ID="ADDRESSLabel" runat="server" Text='<%# Eval("ADDRESS") %>' />
                <br />
                PHONE:
                <asp:Label ID="PHONELabel" runat="server" Text='<%# Eval("PHONE") %>' />
                <br />
                Shape:
                <asp:Label ID="ShapeLabel" runat="server" Text='<%# Eval("Shape") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1 %>" 
            SelectCommand="SELECT [NAME], [ADDRESS], [PHONE], [Shape] FROM ['Wifi Hotspot Locations$']">
        </asp:SqlDataSource>
        
    
        
    </p>
</asp:Content>
