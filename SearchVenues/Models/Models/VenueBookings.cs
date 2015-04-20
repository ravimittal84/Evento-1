using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenueBookings
    {
        [Key]
        public int VenueBookingID { get; set; }
        public int VenueSlotID { get; set; }
        [ForeignKey("VenueSlotID")]
        public virtual VenueSlots VenueSlots { get; set; }
        public int BookingsID { get; set; }
        [ForeignKey("BookingsID")]
        public virtual Bookings Bookings { get; set; }
    }
}