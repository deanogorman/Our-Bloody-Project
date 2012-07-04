// tutorial source
//http://blogs.msdn.com/b/adonet/archive/2011/09/28/ef-4-2-code-first-walkthrough.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelToDB
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }

    // fluent API
    // override convention and make name of supplier compulsary 
    /* protected override void OnModelCreating(DbModelBuilder modelBuilder) 
  {  
    modelBuilder.Entity<Supplier>()  
      .Property(s => s.Name)   
      .IsRequired(); 
  } */
}
