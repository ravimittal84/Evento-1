using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class PackageIncludedFacilities
    {
        [Key]
        public int PackageIncludedFacilitiesID { get; set; }
        public int VenuePackageID { get; set; }
        [ForeignKey("VenuePackageID")]
        public virtual VenuePackages VenuePackages { get; set; }
        public int FacilityID { get; set; }
        [ForeignKey("FacilityID")]
        public virtual Facilities Facilities { get; set; }
    }
}