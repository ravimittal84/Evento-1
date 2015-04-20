using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public string ReviewText { get; set; }
        public DateTime? ReviewDateTime { get; set; }
        public string Helpful { get; set; }
        public string Unhelpful { get; set; }
    }
}