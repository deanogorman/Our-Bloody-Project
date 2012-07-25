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
    public class MuseumDAL
    {
        // for writing to the dB
        protected AccessDB db = new AccessDB();
        // for reading from the dB and showing graphically
        protected AccessDB dbr = new AccessDB(false);

        public MuseumDAL()
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

        public bool updateMuseumInDb(Museum m)
        {
            db.Entry(m).State = EntityState.Modified;
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

        public bool addMuseumToDb(Museum m)
        {
            Museum inm = new Museum();
            try
            {
                inm = db.museums.Add(m);
            }
            
            catch (Exception e)
            {
                Exception j = e;
                return false;
                //do something
            }

            if (inm is Museum)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Museum> findMuseumFromdB(string museumID)
        {
            // the museumID is an identifier that we've yet to decide on, probably name
            //Museum m = null;
            List<Museum> ms = null;
            List<Museum> queryResult = new List<Museum>();

            ms = db.museums.ToList();

            foreach (Museum m in ms)
            {
                m.theName.Equals(museumID);
                queryResult.Add(m);
            }
            return queryResult;
        }

        public List<Museum> getAllMuseumsFromDb()
        {
            return (getAllMuseumsFromDb(false));
        }

        public List<Museum> getAllMuseumsFromDb(bool forVisual)
        {
            if (forVisual)
            {
                return (dbr.museums.ToList());
            }
            else
            {
                return (db.museums.ToList());
            }
        }


        public List<Museum> findMuseumFromUserInput()
        {
            // just a test using hardcoded string for cityStr
            string val = "New York";

            List<Museum> queryResult = new List<Museum>();

            // Query for all museums in db using LINQ 
           
            var each = from mus in db.museums
                       where mus.cityStr.Equals(val) // == val
                       //orderby mus.Name
                       select mus;
            
            foreach (var item in each)
            {
                queryResult.Add(item);
            }
            return queryResult;
        }
    }
}