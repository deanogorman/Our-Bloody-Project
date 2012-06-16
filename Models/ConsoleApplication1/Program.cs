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

            Console.WriteLine("The name of the city is " + newpark.city.getName());
            Console.ReadLine();
            //dublin.addToParks(newpark);
            //newYork.addToParks(newpark);

            TrainStation newTrainStation = new TrainStation(53.548, -6.250, "Random Station Name");
            //dublin.addToTrainStations(newTrainStation);
            //newYork.addToTrainStations(newTrainStation);
        }
    }

}
