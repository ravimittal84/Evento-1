using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenuePhotos
    {
        [Key]
        public int VenuePhotoID { get; set; }
        public int Location { get; set; }
        public string Description { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }
    }
}