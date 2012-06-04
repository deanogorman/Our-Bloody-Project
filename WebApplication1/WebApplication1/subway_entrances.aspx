<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="subway_entrances.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        NYC subway entrances
    </h2>
    <p>
        NYC Subway Entrances</p>
    <p>
        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                NAME:
                <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("NAME") %>' />
                <br />
                LINE:
                <asp:Label ID="LINELabel" runat="server" Text='<%# Eval("LINE") %>' />
                <br />
                Shape:
                <asp:Label ID="ShapeLabel" runat="server" Text='<%# Eval("Shape") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1 %>" 
            SelectCommand="SELECT [NAME], [LINE], [Shape] FROM ['Subway Entrances$']">
        </asp:SqlDataSource>
       
    </p>
</asp:Content>
