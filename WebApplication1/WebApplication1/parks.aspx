<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="parks.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        NYC Parks
    </h2>
    <p>
        List of New York City Parks
                
    
        
    </p>
    <p>
        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                Name:
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                Location:
                <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("Location") %>' />
                <br />
                Borough:
                <asp:Label ID="BoroughLabel" runat="server" Text='<%# Eval("Borough") %>' />
                <br />
                Space:
                <asp:Label ID="SpaceLabel" runat="server" Text='<%# Eval("Space") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1 %>" 
            SelectCommand="SELECT [Name], [Location], [Borough], [Space] FROM [nycParks$]">
        </asp:SqlDataSource>
        
    
        
    </p>
</asp:Content>
