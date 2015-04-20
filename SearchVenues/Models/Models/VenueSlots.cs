using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenueSlots
    {
        [Key]
        public int VenueSlotID { get; set; }
        public int? VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public bool IsBooked { get; set; }
    }
}