using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Mupadoodle1.Models
{
    //[DataContract]
    [Table (Name = "MUSEUMS")]
    public class Museum : Location
    {
        //[Column(IsPrimaryKey = true)]
        public int MuseumID {get; set;}
        // City causes dB conflicts, virtual or otherwise
        public virtual int CityID {get; set;}
        public string cityStr { get; set; }
        public string shape { get; set; } 
        public string tel { get; set; }
        public string url { get; set; }
        public string adress1 { get; set; }
        public string address2 { get; set; }
        public string zip { get; set; }

        public Museum(double Lat, double Long, string museumName, string phone, string theUrl, string add1, string add2, string zip, string city)  : base (Lat, Long, museumName)
        {
            //this.city = new City();
            this.tel = phone;
            this.url = theUrl;
            this.adress1 = add1;
            this.address2 = add2;
            this.zip = zip;
            this.cityStr = city;
        }

        public Museum()
        { 
        }
    }
}