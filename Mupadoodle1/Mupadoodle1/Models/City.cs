using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mupadoodle1.Models
{
    //[Table(Name = "CITIES")]
    public class City : Location
    {
        //[Column(IsPrimaryKey = true, Storage = "_cityID")]

        private static int theID = 0;
        private int cityID = 0;
        public int theCityID
        {
            get { return cityID; }
            set { cityID = value; }
        }
        public List<Park> parks { get; set; }
        public List<TrainStation> trainStations { get; set; }
        public List<School> schools { get; set; }
        public List<Hospital> hospitals { get; set; }
        public List<Location> venues { get; set; }

        // do we need to declare these?
        //double longitude  { get;}
        //double latitude  { get; }
        //string name { get; set; }

        public City(double Lat, double Long, string cityName)
            : base(Lat, Long, cityName)
        {
            theID++;
            this.theCityID = theID;
            parks = new List<Park>();
            trainStations = new List<TrainStation>();
            schools = new List<School>();
            hospitals = new List<Hospital>();
        }

        /*public void addLocation(Location venue)
        {
            if (venue is Park)
            {
                parks.Add((Park)venue);
                ((Park)venue).city = this;
            }
            else if (venue is TrainStation)
            {
                this.trainStations.Add((TrainStation)venue);
                ((TrainStation)venue).city = this;
            }
            else if (venue is School)
            {
                this.schools.Add((School)venue);
                ((School)venue).city = this;
            }
            else if (venue is Hospital)
            {
                this.hospitals.Add((Hospital)venue);
                ((Hospital)venue).city = this;
            }
            else
            {
                this.venues.Add(venue);
            }
        }
        */
        //public void addToParks(Park p){
        //    this.parks.Add(p);
        //}

        //public void addToTrainStations(TrainStation ts)
        //{
        //    this.trainStations.Add(ts);
        //}
    }
}