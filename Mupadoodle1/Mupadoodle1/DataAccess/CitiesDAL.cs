﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mupadoodle1.Models;
using System.Data;

namespace Mupadoodle1.DataAccess
{
    public class CitiesDAL
    {
        // for writing to the dB
        protected AccessDB db = new AccessDB();
        // for reading from the dB and showing graphically
        protected AccessDB dbr = new AccessDB(false);

        public void addLocation(Location venue, City toCity)
        {
            //look up the City database and add the location to the city
            /*
            if (venue is School)
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
             * */
        }

        public City deleteLocation(Location venue, City fromCity)
        {
            return null;
        }

        public bool updateCityInDb(City c)
        {
            db.Entry(c).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                // do something
                return false;
            }
        }

        public List<City> getAllCitiesFromDb()
        {
            return (getAllCitiesFromDb(false));
        }

        public List<City> getAllCitiesFromDb(bool forVisual)
        {
            if (forVisual)
            {
                return (dbr.cities.ToList());
            }
            else
            {
                return (db.cities.ToList());
            }
        }

        public bool addCityToDb(City c)
        {
            City inc = new City();
            try
            {
                
                inc = db.cities.Add(c);
            }

            catch (Exception e)
            {
                Exception j = e;
                return false;
                //do something
            }

            if (inc is City)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<City> findCityFromdB(string cityName)
        {
            // the museumID is an identifier that we've yet to decide on, probably name
            //Museum m = null;
            List<City> cs = null;
            List<City> queryResult = new List<City>();

            cs = db.cities.ToList();

            foreach (City c in cs)
            {
                c.theName.Equals(cityName);
                queryResult.Add(c);
            }
            return queryResult;
        }

        public List<City> findCityFromUserInput()
        {
            // just a test using hardcoded string for cityStr
            string val = "New York";

            List<City> queryResult = new List<City>();

            // Query for all cities in db using LINQ 

            var each = from c in db.cities
                       where c.lname.Equals(val) // == val
                       //orderby mus.Name
                       select c;

            foreach (var item in each)
            {
                queryResult.Add(item);
            }
            return queryResult;
        }
    }
}