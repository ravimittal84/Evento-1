using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Area
    {
        [Key]
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public virtual City City { get; set; }
    }
}