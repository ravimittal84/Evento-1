using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class SupplierSlots
    {
        [Key]
        public int SupplierSlotsID { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public bool IsBooked { get; set; }
    }
}