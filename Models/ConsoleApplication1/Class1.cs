using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Class1
    {
        public static void Main(String []args){
            City dublin = new City();
            City newYork = new City();

            Park newpark = new Park();
            dublin.addToParks(newpark);
            newYork.addToParks(newpark);

            TrainStation newTrainStation = new TrainStation();
            dublin.addToTrainStations(newTrainStation);
            newYork.addToTrainStations(newTrainStation);
        }
    }

}
