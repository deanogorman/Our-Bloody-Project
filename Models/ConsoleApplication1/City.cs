using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace ConsoleApplication1
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
        List<Park> parks { get; set; }
        List<TrainStation> trainStations { get; set; }
        List<School> schools { get; set; }
        List<Location> venues {get; set; }

        // do we need to declare these?
        //double longitude  { get;}
        //double latitude  { get; }
        //string name { get; set; }

        public City(double Lat, double Long, string cityName) : base(Lat, Long, cityName)
        {
            theID++;
            this.theCityID = theID;
            parks = new List<Park>();
            trainStations = new List<TrainStation>();
        }

        public void addLocation(Location venue)
        {
            if (venue is Park)
            {
                parks.Add((Park)venue);
                ((Park)venue).city = this;
            } else if (venue is TrainStation)
            {
                this.trainStations.Add((TrainStation)venue);
                ((TrainStation)venue).city = this;
            } else if (venue is TrainStation)
            {
                this.schools.Add((School)venue);
                ((School)venue).city = this;
            } else
            {
                this.venues.Add(venue);
            }
        }

        //public void addToParks(Park p){
        //    this.parks.Add(p);
        //}

        //public void addToTrainStations(TrainStation ts)
        //{
        //    this.trainStations.Add(ts);
        //}
    }
}
