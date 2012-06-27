using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mupadoodle1.Models
{
    //[Table (Name = "PARKS")]
    public class Park : Location
    {
        public City city; // the city in which the park is located park.City
        //double longitude;
        //double latitude;
        //string Name;
        string facilities;

        public Park(double Lat, double Long, string parkName)
            : base(Lat, Long, parkName)
        {
            this.city = null;
            this.facilities = "none";
        }
    }
}