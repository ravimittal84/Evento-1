using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class SuplierReviews
    {
        [Key]
        public int SupplierReviewsID { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
        public int ReviewID { get; set; }
        [ForeignKey("ReviewID")]
        public virtual Reviews Reviews { get; set; }
    }
}