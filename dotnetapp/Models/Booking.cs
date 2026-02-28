using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace dotnetapp.Models
{
    public class Booking
    {
       public long? BookingId { get; set; }
       public int NoOfPersons { get; set; }
       public DateTime FromDate { get; set; }
       public DateTime ToDate { get; set; }
       public string Status { get; set; }
       public double TotalPrice { get; set; }
       public string Address { get; set; }
       public long UserId { get; set; }
       [JsonIgnore]
       public User? User { get; set; }
       public long PartyHallId { get; set; }
       [JsonIgnore]
       public PartyHall? PartyHall { get; set; }
    }
}