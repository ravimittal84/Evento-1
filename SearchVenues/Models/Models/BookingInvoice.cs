using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class BookingInvoice
    {
        [Key]
        public int BookingInvoiceID { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int BookingsID { get; set; }
        [ForeignKey("BookingsID")]
        public virtual Bookings Bookings { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CreatedBy { get; set; }
    }
}