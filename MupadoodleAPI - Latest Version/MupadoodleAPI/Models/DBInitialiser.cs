using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MupadoodleAPI.Models;
using MupadoodleAPI.DataAccess;
using System.Data.Entity;
using MupadoodleAPI.Ingestion;
using MupadoodleAPI.Logic;

namespace MupadoodleAPI.DataAccess
{
    public class DBInitialiser : DropCreateDatabaseIfModelChanges<AccessDB>
    {

        protected override void Seed(AccessDB context)
        {
            BuildVenues bv = new BuildVenues();
            BuildCities bCities = new BuildCities();
            context.SaveChanges();
         
        }

       
    }
}
