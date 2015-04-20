using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Facilities
    {
        [Key]
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityValue { get; set; }
    }
}