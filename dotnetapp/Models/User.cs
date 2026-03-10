using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be atleast 6 characters.")]
        // [JsonIgnore]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, StringLength(10, ErrorMessage = "Must be 10 digits.")]
        public string MobileNumber { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}