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
        public City city; // the city in which the TrainStation is located trainStation.City
        //double longitude;
        //double latitude;
        //string Name;
		string wheelchairFriendly;
		string taxiRank;
        string carPark;

        public TrainStation(double Lat, double Long, string tsName) : base(Lat, Long, tsName)
        {
		    this.city = null;
            this.wheelchairFriendly = "0";
			this.taxiRank = "0";
			this.carPark = "0";		
			
        }
        
    }
}