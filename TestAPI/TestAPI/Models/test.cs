using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class unitType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unitTypeID { get; set; }
        public String typeName { get; set; }
    }
    public class TestDBContext : DbContext
    {
        public DbSet<unitType> unitType { get; set; }
       
    }
}