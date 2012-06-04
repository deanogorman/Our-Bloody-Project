<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 434px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        NYC Wifi locations
    </h2>
    <p>
        New York City Wifi Hotspot List
                
        
    </p>
    <table class="style1">
        <tr>
            <td class="style2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display." Width="425px">
            <Columns>
                <asp:BoundField DataField="Space" HeaderText="Space" SortExpression="Space" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Location" HeaderText="Location" 
                    SortExpression="Location" />
                <asp:BoundField DataField="Borough" HeaderText="Borough" 
                    SortExpression="Borough" />
                <asp:BoundField DataField="Acres" HeaderText="Acres" SortExpression="Acres" />
            </Columns>
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1 %>" 
                    SelectCommand="SELECT [Space], [Name], [Location], [Acres] FROM [nycParks$]">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:Database1.mdf_DataConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [ID], [Space], [Name], [Location], [Borough], [Acres] FROM [nycParks$]">
        </asp:SqlDataSource>
        
        
    </p>
</asp:Content>
