using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class SupplierBookings
    {
        [Key]
        public int SupplierBookingsID { get; set; }
        public int? SupplierSlotsID { get; set; }
        [ForeignKey("SupplierSlotsID")]
        public virtual SupplierSlots SupplierSlots { get; set; }
        public int BookingsID { get; set; }
        [ForeignKey("BookingsID")]
        public virtual Bookings Bookings { get; set; }
    }
}