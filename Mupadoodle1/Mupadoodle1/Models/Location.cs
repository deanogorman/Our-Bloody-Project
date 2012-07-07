using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace Mupadoodle1.Models
{
    [DataContract]
    [Table(Name = "LOCATIONS")]
    public class Location
    {
        [DataMember]
        [Column(Name = "LNG")]
        double longitude;
        public double theLong
        {
            get { return longitude; }
        }
        [DataMember]
        [Column(Name = "LAT")]
        double latitude;
        public double theLat
        {
            get { return latitude; }
        }
        [DataMember]
        [Column(Name = "NAME")]
        string name;
        public string theName
        {
            get { return name; }
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
            this.name = Name;
        }

        public string getName()
        {
            return this.name;
        }

        public Location(double Lat, double Long, string Name)
        {
            setLatLong(Lat, Long);
            setName(Name);
        }
    }
}