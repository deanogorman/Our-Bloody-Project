using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Location
    {
        double longitude;
        double latitude;
        string name;

        private void setLatLong(double Lat, double Long)
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
