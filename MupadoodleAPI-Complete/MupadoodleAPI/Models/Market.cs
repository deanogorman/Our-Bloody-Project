using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MupadoodleAPI.Models
{
    //[Table (Name = "MARKETS")]
    public class Market : Location
    {
        public int MarketID { get; set; }
        //public virtual int CityID { get; set; }
        public string cityStr { get; set; }
        public string shape { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public Market()
        {
        }

        public Market(double Lat, double Long, string marketName, string city, string location)
            : base(Lat, Long, marketName)
        {
            this.cityStr = city;
            this.location = location;
        }
    }
}