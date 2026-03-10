using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Resources;

namespace dotnetapp.Models
{
    public class PartyHall
    {
        [Key]
        public long PartyHallId { get; set; }
        [Required]
        public string HallName { get; set; }
        public string HallImageUrl { get; set; }
        [Required]
        public string HallLocation { get; set; }
        [Required]
        public string HallAvailableStatus { get; set; }
        [Required, Range(0, long.MaxValue, ErrorMessage = "Must be positive value.")]
        public long Price { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Capacity must be atleast 1.")]
        public int Capacity { get; set; }
        [Required]
        public string Description { get; set; }
        public string Theme { get; set; } = string.Empty;
        public string AdditionalImages { get; set; } = string.Empty; // JSON array of image URLs
        public string FullAddress { get; set; } = string.Empty; // Full street address for Google Maps
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }
    }
}
 