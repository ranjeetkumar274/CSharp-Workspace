using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public long UserId { get; set; }

        [Required]
         public long PartyHallId { get; set; }
         [Required]
        public string Subject { get; set; }
         [Required]
        public string Body { get; set; }

        [Required, Range(1, 5, ErrorMessage="Rating must be between 1 to 5.")]
        public int Rating { get; set; }
         [Required]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public PartyHall? PartyHall { get; set; }
    }
}
