using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}