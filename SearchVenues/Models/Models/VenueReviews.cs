using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenueReviews
    {
        [Key]
        public int VenueReviewID { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }
        public int ReviewID { get; set; }
        [ForeignKey("ReviewID")]
        public virtual Reviews Reviews { get; set; }
    }
}