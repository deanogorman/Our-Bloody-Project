using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Mupadoodle1.Models;
using System.Data.Entity;
using System.Data;

namespace Mupadoodle1.DataAccess
{
    public class ParkDAL
    {
        protected AccessDB db = new AccessDB();
        
        public ParkDAL()
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

        public bool updateParkInDb(Park p)
        {
            db.Entry(p).State = EntityState.Modified;
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

        public bool addParkToDb(Park p)
        {
            Park inp = new Park();
            try
            {
                inp = db.parks.Add(p);
            }

            catch (Exception e)
            {
                Exception j = e;
                return false;
                //do something
            }

            if (inp is Park)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Park> getAllParksFromDb()
        {
            return (db.parks.ToList());
        }
    }
}