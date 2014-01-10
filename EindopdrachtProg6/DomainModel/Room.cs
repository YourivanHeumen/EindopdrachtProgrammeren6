using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel
{
    [Table("Room")]
    public class Room
    {
        public int RoomId { get; set; }
        public decimal MinPrice { get; set; }
        public decimal Price { get; set; }
        public int NrGuests { get; set; }
        public Nullable<DateTime> StartPeriodHigherPrice { get; set; }
        public Nullable<DateTime> EndPeriodHigherPrice { get; set; }
    }
}