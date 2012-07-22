using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace MupadoodleAPI.Models
{
    //[DataContract]
    [Table(Name = "LOCATIONS")]
    public class Location
    {
        public int LocationID { get; set; }
        public double longitude { get; set; }
        public double theLong
        {
            get { return longitude; }
        }
        public double latitude { get; set; }
        public double theLat
        {
            get { return latitude; }
        }
        public string lname { get; set; }
        public string theName
        {
            get { return lname; }
        }

        public void setLatLong(double Lat, double Long)
        {
            this.latitude = Lat;
            this.longitude = Long;
        }

        public double getLat()
        {
            return this.latitude;
        }

        public double getLong()
        {
            return this.longitude;
        }

        private void setName(string Name)
        {
            this.lname = Name;
        }

        public string getName()
        {
            return this.lname;
        }

        public Location(double Lat, double Long, string Name)
        {
            setLatLong(Lat, Long);
            setName(Name);
        }
        public Location()
        {
        }
    }
}