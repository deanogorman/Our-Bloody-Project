using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;



namespace ConsoleApplication1
{
    //[Table (Name = "PARKS")]
    public class Park : Location
    {
        public City city; // the city in which the park is located park.City
        //double longitude;
        //double latitude;
        //string Name;
        string facilities;

        public Park(double Lat, double Long, string parkName) : base(Lat, Long, parkName)
        {
            this.city = null;
            this.facilities = "none";
        }
    }
}
