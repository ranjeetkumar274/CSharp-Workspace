using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace dotnetapp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}