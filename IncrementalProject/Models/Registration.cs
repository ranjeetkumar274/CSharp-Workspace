using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email{get;set;}
        [DataType(DataType.Password)]
        public string Password{get;set;}
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{get;set;}
    }
}
