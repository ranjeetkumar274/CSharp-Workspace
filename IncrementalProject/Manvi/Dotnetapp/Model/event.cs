using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public decimal Budget { get; set; }

    public ICollection<Attendee>? Attendees { get; set; }
    }
}
