using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel
{
    public class BoekingContext : DbContext
    {
        public DbSet<Boeking> Boekings { get; set; }

    }
}