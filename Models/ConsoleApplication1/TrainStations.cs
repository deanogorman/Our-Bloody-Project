using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;



namespace ConsoleApplication1
{
    //[Table(Name = "TRAINSTATIONS")]
    public class TrainStation : Location
    {
        public City city; // the city in which the park is located park.City
        //double longitude;
        //double latitude;
        //string Name;

        public TrainStation(double Lat, double Long, string tsName)
            : base(Lat, Long, tsName)
        {
        }
        
    }
}