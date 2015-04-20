using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public int AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
    }
}