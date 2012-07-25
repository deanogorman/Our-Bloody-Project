using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MupadoodleAPI.Models
{
    public class AccessDB : DbContext
    {
        public DbSet<Museum> museums { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Park> parks { get; set; }
        public DbSet<Market> markets { get; set; }

        //public DbSet<ExchangeUI> ExchangeUIs { get; set; }

        public AccessDB()
            : base()
        {
            // used for writing to the dB
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public AccessDB(bool isProxyCreationEnabled)
            : base()
        {
            // should be used when reading from the dB and should pass a 'false parameter
            this.Configuration.ProxyCreationEnabled = isProxyCreationEnabled;
        }
    }


}