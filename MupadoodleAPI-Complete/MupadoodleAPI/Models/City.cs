using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Web;

namespace MupadoodleAPI.Models
{
    [Table (Name = "CITIES")]
    public class City : Location
    {
        //[Column(IsPrimaryKey = true")]
        public int CityID = 0;
        
        public List<TrainStation> trainStations { get; set; }
        public List<School> schools { get; set; }
        public List<Hospital> hospitals { get; set; }
        public List<Location> venues { get; set; }
        public virtual ICollection<Museum> museums { get; set; }
        public virtual ICollection<Park> parks { get; set; }
        public virtual ICollection<Market> markets { get; set; }

        public City()
        {
                parks = new List<Park>();
                trainStations = new List<TrainStation>();
                schools = new List<School>();
                hospitals = new List<Hospital>();
                museums = new List<Museum>();
                markets = new List<Market>();
        }

        public City(double Lat, double Long, string cityName)
            : base(Lat, Long, cityName)
        {
            parks = new List<Park>();
            trainStations = new List<TrainStation>();
            schools = new List<School>();
            hospitals = new List<Hospital>();
            museums = new List<Museum>();
            markets = new List<Market>();
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