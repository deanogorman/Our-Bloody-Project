﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mupadoodle1.Models;
using Mupadoodle1.DataAccess;

namespace Mupadoodle1.Logic
{
    public class BuildCities
    {
        public BuildCities()
        {
            // list of all museums in dB
            // list of all other venues to follow
            List<Museum> ms = new List<Museum>();
            List<Park> ps = new List<Park>();
            // temporary list of cities
            List<City> cs = new List<City>();
            MuseumDAL mDal = new MuseumDAL();
            ParkDAL pDal = new ParkDAL();

            ms = mDal.getAllMuseumsFromDb();

            foreach (Museum m in ms)
            {
                bool notFound = true;
                foreach (City c in cs)
                {  
                    if (m.cityStr.Equals(c.lname))
                    {
                        // Add museum to list of this city's museums
                        c.museums.Add(m);
                        notFound = false;
                        break;
                    }
                }
                if (notFound)
                {
                    City addCity = new City();
                    addCity.lname = m.cityStr;
                    addCity.latitude = m.latitude;
                    addCity.longitude = m.longitude;
                    // Add museum to list of this city's museums
                    //addCity.museums = new List<Museum>();
                    addCity.museums.Add(m);
                    cs.Add(addCity);
                }
            }

            // Do this again for each other venue
            ps = pDal.getAllParksFromDb();
            foreach (Park p in ps)
            {
                bool notFound = true;
                foreach (City c in cs)
                {
                    if (p.cityStr.Equals(c.lname))
                    {
                        // Add museum to list of this city's museums
                        c.parks.Add(p);
                        notFound = false;
                        break;
                    }
                }
                if (notFound)
                {
                    City addCity = new City();
                    addCity.lname = p.cityStr;
                    addCity.latitude = 79.0;
                    addCity.longitude = 79.0;
                    // Add museum to list of this city's museums
                    //addCity.museums = new List<Museum>();
                    addCity.parks.Add(p);
                    cs.Add(addCity);
                }
            }
            
            // We have created our temporary list of cities, now add them to the dB
            CitiesDAL cDal = new CitiesDAL();
            List<City> lCitiesInDB = new List<City>();
            lCitiesInDB = cDal.getAllCitiesFromDb();
            bool result = false, notIndB = true;
            foreach (City c in cs)
            {
                foreach (City dcb in lCitiesInDB)
                {
                    if (dcb.lname.Equals(c.lname))
                    {
                        notIndB = false;
                        break;
                    }
                }
                if (notIndB)
                {
                    result = cDal.addCityToDb(c);
                    if (result.Equals(false))
                    {
                        //do something
                    }
                }
                notIndB = true;
                // see if it has an id now
            }
        }

    }
}