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
   public class Supplier
    {
        [Key]
        public string SupplierCode { get; set; }
        public string Name { get; set; } 
    }
}
