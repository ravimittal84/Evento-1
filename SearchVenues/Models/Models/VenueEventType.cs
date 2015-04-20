using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenueEventType
    {
        [Key]
        public int VenueEventTypeID { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }
        public int EventTypeID { get; set; }
        [ForeignKey("EventTypeID")]
        public virtual EventType EventType { get; set; }
    }
}