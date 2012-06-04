<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="moregmaps.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Testing Google Maps
    </h2>
    <p>
        Trying to get google maps working
                
    
        
    </p>

    <p>
    
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<style type="text/css">
  html { height: 100% }
  body { height: 100%; margin: 0px; padding: 0px }
  #map_canvas { height: 100% }
</style>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
    function initialize() {
        var latlng = new google.maps.LatLng(53.397, -6.644);
        var myOptions = { zoom: 10, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP };
        var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        var map = new google.maps.Map(document.getElementById("map_canvas"),
        myOptions);

    }

</script>
    
    </p>
</asp:Content>
