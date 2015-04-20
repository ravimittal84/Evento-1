using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }
        public int SupplierTypeID { get; set; }
        [ForeignKey("SupplierTypeID")]
        public virtual SupplierType SupplierType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}