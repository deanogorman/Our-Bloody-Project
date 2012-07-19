using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MupadoodleAPI.Models
{
    //[Table (Name = "PARKS")]
    public class Park : Location
    {
        public int ParkID { get; set; }
        //public virtual int CityID { get; set; }
        public string cityStr { get; set; }
        public string shape { get; set; }
        public double acres { get; set; }
        public string place { get; set; }

        public Park()
        {
        }

        public Park(double Lat, double Long, string parkName, string city, double size, string place)
            : base(Lat, Long, parkName)
        {
            this.lname = parkName;
            this.cityStr = city;
            this.acres = size;
            this.place = place;
        }
    }
}