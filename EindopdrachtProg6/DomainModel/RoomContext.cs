using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel
{
    public class RoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

    }
}