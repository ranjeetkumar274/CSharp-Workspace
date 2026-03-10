using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Booking
    {
        [Key]
        public long BookingId { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Number of person must be atleast 1.")]
        public int NoOfPersons { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public string Status { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Must be positive value.")]
        public double TotalPrice { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public long UserId { get; set; }
      
        public User? User { get; set; }
        [Required]
        public long PartyHallId { get; set; }
       
        public PartyHall? PartyHall { get; set; }
    }
}
