using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class InvoiceItems
    {
        [Key]
        public int InvoiceItemID { get; set; }
        public int BookingInvoiceID { get; set; }
        [ForeignKey("BookingInvoiceID")]
        public virtual BookingInvoice BookingInvoice { get; set; }
        public string ItemName { get; set; }
        public decimal ItemAmount { get; set; }
    }
}