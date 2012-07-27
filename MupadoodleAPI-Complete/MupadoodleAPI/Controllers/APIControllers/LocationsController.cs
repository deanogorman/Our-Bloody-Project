using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MupadoodleAPI.Models;

namespace MupadoodleAPI.Controllers
{
    public class LocationsController : ApiController
    {

        Location[] locations = new Location[] 
        { 
            new Location { LocationID = 1, longitude = 61, latitude = 51, lname = "London" }, 
            new Location { LocationID = 2, longitude = 63, latitude = 53, lname = "Dublin" }, 
            new Location { LocationID = 3, longitude = 65, latitude = 55, lname = "New York" } 
        };

        public IEnumerable<Location> GetAllLocations()
        {
            return locations;
        }

        public Location GetLocationById(int id)
        {
            var location = locations.FirstOrDefault((l) => l.LocationID == id);
            if (location == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return location;
        }

        public IEnumerable<Location> GetLocationsByName(string name)
        {
            return locations.Where(
                (l) => string.Equals(l.lname, name, 
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
