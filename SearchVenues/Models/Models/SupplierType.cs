using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class SupplierType
    {
        [Key]
        public int SupplierTypeID { get; set; }
        public string SupplierTypeName { get; set; }
    }
}