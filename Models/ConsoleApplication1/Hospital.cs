using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    //[Table(Name = "HOSPITALS")]
    public class Hospital : Location
    {
        public City city; // the city in which the School is located school.City
        //double longitude inhereted;
        //double latitude inhereted;
        //string Name inhereted;
        bool wheelchairAccess;
        bool taxiRank;
        bool carPark;
        bool bankFacilities;
        bool flourist;

        public Hospital(double Lat, double Long, string tsName)
            : base(Lat, Long, tsName)
        {
            this.city = null;
            this.wheelchairAccess = true;
			this.taxiRank = true;
			this.carPark = true;
            this.bankFacilities = true;
            this.flourist = true;
        }
    }
}