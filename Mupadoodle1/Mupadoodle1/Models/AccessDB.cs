using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mupadoodle1.Models
{
    public class AccessDB : DbContext
    {
        public DbSet<Museum> museums { get; set; }
        public DbSet<City> cities { get; set; }

        //public DbSet<ExchangeUI> ExchangeUIs { get; set; }
    }
}