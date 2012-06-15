using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace ConsoleApplication1
{
    [Table(Name = "CITIES")]
    public class City
    {
        [Column(IsPrimaryKey = true, Storage = "_cityID")]

        int cityID { get; }
        List<Park> parks { get; set; }
        List<TrainStation> trainStations { get; set; }

        float longitude  { get;}
        float latitude  { get; }
        string name { get; set; }

        public City(){
            parks = new List<Park>();
            trainStations = new List<TrainStation>();
        }

        public void addToParks(Park p){
            this.parks.Add(p);
        }

        public void addToTrainStations(TrainStation ts)
        {
            this.trainStations.Add(ts);
        }
    }
}
