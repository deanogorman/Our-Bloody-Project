using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mupadoodle1.Models;

namespace Mupadoodle1.DataAccess
{
    public class CitiesDAL
    {
        public City addLocation(Location venue, City toCity)
        {
            //look up the City database and add the location to the city
            if (venue is Park)
            {
                toCity.parks.Add((Park)venue);
                ((Park)venue).city = toCity;
            }
            else if (venue is TrainStation)
            {
                toCity.trainStations.Add((TrainStation)venue);
                ((TrainStation)venue).city = toCity;
            }
            else if (venue is School)
            {
                toCity.schools.Add((School)venue);
                ((School)venue).city = toCity;
            }
            else if (venue is Hospital)
            {
                toCity.hospitals.Add((Hospital)venue);
                ((Hospital)venue).city = toCity;
            }
            else
            {
                toCity.venues.Add(venue);
            }
        }

        public City deleteLocation(Location venue, City fromCity)
        {
            return null;
        }

        public City findLocation(Location venue)
        {
            //Search all Cities in Database for venue and return the City
            return null;
        }
    }
}