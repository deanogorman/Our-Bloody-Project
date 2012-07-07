using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Mupadoodle1.Models
{
    [DataContract]
    [Table (Name = "MUSEUMS")]
    public class Museum : Location
    {
        [Column(IsPrimaryKey = true)]
        public int id {get; set;}
        [Column(Name = "CITY")]
        public City city; // the city in which the park is located museum.City
        [DataMember]
        [Column(Name = "CITYSTR")]
        public string cityStr;
        [DataMember]
        [Column(Name = "SHAPE")]
        public string shape; //{
            //get
            //{
                //return shape;
            //}
            //set
            //{
                // split and assign from lat and long
                // strip off the first a last characters in the string as these are braces
                //string shape2 = shape.Substring(1, shape.Length - 2);
                // split the string into 2 strings
               // string[] split = shape2.Split(new Char[] { ',' });
                //double lat = Convert.ToDouble(split[0]);
                //double lng = Convert.ToDouble(split[1]);
                //this.setLatLong(lat, lng);
            //}
        //}
        // Inherited from Location class
        //double longitude;
        //double latitude;
        // string name
        [DataMember]
        [Column(Name = "TEL")]
        public string tel;
        [DataMember]
        [Column(Name = "URL")]
        public string url;
        [DataMember]
        [Column(Name = "ADD1")]
        public string adress1;
        [DataMember]
        [Column(Name = "ADD2")]
        public string address2;
        [DataMember]
        [Column(Name = "ZIP")]
        public string zip;


        public Museum(double Lat, double Long, string museumName, string phone, string theUrl, string add1, string add2, string zip, string city)
            : base(Lat, Long, museumName)
        {
            this.city = null;
            this.tel = phone;
            this.url = theUrl;
            this.adress1 = add1;
            this.address2 = add2;
            this.zip = zip;
            this.cityStr = city;
        }
    }
}