using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(String []args){
            City dublin = new City(53.353, -6.267, "Dublin");
            City newYork = new City(40.727, -74.007, "New York");

            Park newpark = new Park(53.362, -6.328, "Phoenix Park");
            dublin.addLocation(newpark);
            //dublin.addToParks(newpark);
            //newYork.addToParks(newpark);
            
            TrainStation newTrainStation = new TrainStation(53.3513, -6.2498, "Connolly Station / Amiens Street Station");
            dublin.addLocation(newTrainStation);
            //dublin.addToTrainStations(newTrainStation);
            //newYork.addToTrainStations(newTrainStation);

            School newSchool = new School(53.3513, -6.2498, "Loreto College, Crumlin");
            dublin.addLocation(newSchool);

            Console.WriteLine("The name of the city is " + newpark.city.getName());

            Console.WriteLine("The name of the Park is " + newpark.getName());
            Console.WriteLine("The name of the train station is " + newTrainStation.getName());
            Console.WriteLine("The name of the school is " + newSchool.getName());
            Console.ReadLine();
            
        }
    }

}
