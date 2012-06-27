﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mupadoodle1.Models
{
    //[Table(Name = "TRAINSTATIONS")]
    public class TrainStation : Location
    {
        public City city; // the city in which the TrainStation is located trainStation.City
        //double longitude;
        //double latitude;
        //string Name;
        bool wheelchairFriendly;
        bool taxiRank;
        bool carPark;

        public TrainStation(double Lat, double Long, string tsName)
            : base(Lat, Long, tsName)
        {
            this.city = null;
            this.wheelchairFriendly = true;
            this.taxiRank = true;
            this.carPark = true;

        }

    }
}