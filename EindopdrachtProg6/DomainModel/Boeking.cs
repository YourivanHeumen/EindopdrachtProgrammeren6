using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel
{
    [Table("Boeking")]
    public class Boeking
    {
        public int BoekingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int CheckInGuestId { get; set; }
        public string Valuta { get; set; }
        public Decimal TotalPrice { get; set; }
        public string BillingAdress { get; set; }
        public string BillingPostalcode { get; set; }
        public string BillingCountry { get; set; }
        public int BankNr { get; set; }
        public int RoomId { get; set; }
    }
}