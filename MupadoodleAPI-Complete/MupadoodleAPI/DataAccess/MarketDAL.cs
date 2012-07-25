using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MupadoodleAPI.Models;
using System.Data.Entity;
using System.Data;

namespace MupadoodleAPI.DataAccess
{
    public class MarketDAL
    {
        // for writing to the dB
        protected AccessDB db = new AccessDB();
        // for reading from the dB and showing graphically
        protected AccessDB dbr = new AccessDB(false);

        public MarketDAL()
        {
            Database.SetInitializer<AccessDB>(new DropCreateDatabaseIfModelChanges<AccessDB>());
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                Console.WriteLine();
                System.Diagnostics.Debug.WriteLine("Using connection strings property");

                // Get the collection elements
                foreach (ConnectionStringSettings connection in connections)
                {
                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;

                    System.Diagnostics.Debug.WriteLine("Name:           {0}", name);
                    System.Diagnostics.Debug.WriteLine("Connection String:           {0}", connectionString);
                    System.Diagnostics.Debug.WriteLine("Provider:           {0}", provider);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No connection string is defined");
            }
        }

        public bool updateMarketInDb(Market mk)
        {
            db.Entry(mk).State = EntityState.Modified;
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

        public bool addMarketToDb(Market mk)
        {
            Market inmk = new Market();
            try
            {
                inmk = db.markets.Add(mk);
            }

            catch (Exception e)
            {
                Exception j = e;
                return false;
                //do something
            }

            if (inmk is Market)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Market> findMarketFromdB(string marketID)
        {
            // the museumID is an identifier that we've yet to decide on, probably name
            //Museum m = null;
            List<Market> mks = null;
            List<Market> queryResult = new List<Market>();

            mks = db.markets.ToList();

            foreach (Market mk in mks)
            {
                mk.theName.Equals(marketID);
                queryResult.Add(mk);
            }
            return queryResult;
        }

        public List<Market> getAllMarketsFromDb()
        {
            return (getAllMarketsFromDb(false));
        }

        public List<Market> getAllMarketsFromDb(bool forVisual)
        {
            if (forVisual)
            {
                return (dbr.markets.ToList());
            }
            else
            {
                return (db.markets.ToList());
            }
        }


        public List<Market> findMarketFromUserInput()
        {
            // just a test using hardcoded string for cityStr
            string val = "New York";

            List<Market> queryResult = new List<Market>();

            // Query for all markets in db using LINQ 

            var each = from mks in db.markets
                       where mks.cityStr.Equals(val) // == val
                       //orderby mus.Name
                       select mks;

            foreach (var item in each)
            {
                queryResult.Add(item);
            }
            return queryResult;
        }
    }
}