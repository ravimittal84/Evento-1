using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class VenuePackages
    {
        [Key]
        public int VenuePackageID { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }
        public decimal CostPerPerson { get; set; }
        public int Capacity { get; set; }
    }
}