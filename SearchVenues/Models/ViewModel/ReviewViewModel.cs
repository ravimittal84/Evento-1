using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.ViewModel
{
    public class ReviewViewModel
    {
        public int ReviewID { get; set; }
        public int? CustomerID { get; set; }
        public string ReviewText { get; set; }
        public DateTime? ReviewDateTime { get; set; }
        public string Helpful { get; set; }
        public string Unhelpful { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int VenueID { get; set; }
    }
}