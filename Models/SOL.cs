using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcSOL.Models
{
    public class SOL
    {
        [Key]
        public int caseID { get; set; }
        public string Case { get; set; }
        public string Atty { get; set; }
        public DateTime SOLDate { get; set; }
    }

    public class SOLDBContext : DbContext
    {
        public DbSet<SOL> SOLs { get; set; }
    }

}