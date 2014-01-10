using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel
{
    [Table("Guest")]
    public class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Nullable<int> ToBookRoomId { get; set; }
    }
}