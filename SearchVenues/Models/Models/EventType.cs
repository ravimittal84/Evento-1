using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SearchVenues.Models.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeID { get; set; }
        public string EventTypeName { get; set; }
    }
}