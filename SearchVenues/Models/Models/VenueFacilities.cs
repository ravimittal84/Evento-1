using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenueFacilities
    {
        [Key]
        public int VenueFacilityID { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Vanue { get; set; }
        public int FacilityID { get; set; }
        [ForeignKey("FacilityID")]
        public virtual Facilities Facilities { get; set; }
    }
}