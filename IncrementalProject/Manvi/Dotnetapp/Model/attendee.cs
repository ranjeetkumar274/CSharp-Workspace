using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }

    public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
