using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Bookings
    {
        [Key]
        public int BookingsID { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public string BookingStatus { get; set; }
        public int Attendees { get; set; }
        public decimal TotalCost { get; set; }
        public string PaymentStatus { get; set; }
    }
}