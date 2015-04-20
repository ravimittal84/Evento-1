using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class InvoicePayments
    {
        [Key]
        public int InvoicePaymentID { get; set; }
        public int BookingInvoiceID { get; set; }
        [ForeignKey("BookingInvoiceID")]
        public virtual BookingInvoice BookingInvoice { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaidBy { get; set; }
    }
}