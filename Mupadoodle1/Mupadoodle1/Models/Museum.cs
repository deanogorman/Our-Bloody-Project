using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mupadoodle1.Models
{
    //[Table (Name = "MUSEUMS")]
    public class Museum : Location
    {
        public City city; // the city in which the park is located museum.City
        public string cityStr;
        public string shape;
        //double longitude;
        //double latitude;
        public string name, tel, url, address1, address2, zip;


        public Museum(double Lat, double Long, string museumName, string phone, string theUrl, string add1, string add2, string zip, string city)
            : base(Lat, Long, museumName)
        {
            this.city = null;
            this.tel = phone;
            this.url = theUrl;
            this.address1 = add1;
            this.address2 = add2;
            this.zip = zip;
            this.cityStr = city;
        }
    }
}