using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Mupadoodle1.Models;
using System.Data.Entity;

namespace Mupadoodle1.DataAccess
{
    public class MuseumDAL
    {
        protected AccessDB db = new AccessDB();
        

        public MuseumDAL()
        {
            Database.SetInitializer<AccessDB>(new DropCreateDatabaseIfModelChanges<AccessDB>());
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                Console.WriteLine();
                System.Diagnostics.Debug.WriteLine("Using connectsion strings property");

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

        public bool addMuseumToDb(Museum m)
        {
            if (db.museums.Add(m) is Museum)
            {
                db.SaveChanges();
                m = db.museums.First();
                return true;
            }
            return false;
        }

        public List<Museum> findMuseumFromdB(string museumID)
        {
            // the museumID is an identifier that we've yet to decide on, probably name
            //Museum m = null;
            List<Museum> ms = null;
            List<Museum> queryResult = null;

            ms = db.museums.ToList();

            foreach (Museum m in ms)
            {
                m.theName.Equals(museumID);
                queryResult.Add(m);
            }
            return queryResult;
        }

        public List<Museum> findMuseumFromUserInput()
        {
            string val = "New York";

            List<Museum> queryResult = null;

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