Employee.cs
 
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace dotnetapp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
 
        [Required(ErrorMessage = "The Name field is required.")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
 
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [UniqueEmail(ErrorMessage = "Email must be unique.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "The Date of Birth field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MinAge(25, ErrorMessage = "Employee must be 25 years or older.")]
        public DateTime Dob { get; set; }
 
        [Required(ErrorMessage = "The Dept field is required.")]
        [Display(Name = "Department")]
        public string Dept { get; set; }
 
        [Required(ErrorMessage = "The Salary field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary should be greater than 0")]
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
 
 
 
Models/UniqueEmailAttribute.cs
 
 
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using dotnetapp.Data;
 
namespace dotnetapp.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (context == null)
            {
                return ValidationResult.Success;
            }
 
            var email = value?.ToString();
            if (string.IsNullOrEmpty(email))
                return ValidationResult.Success;
 
            // Get the current employee being validated
            var employee = validationContext.ObjectInstance as Employee;
            // Check if email exists for other employees
            var existingEmployee = context.Employees
                .FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
 
            // For new employee (Id = 0) or for updates, check if email belongs to another employee
            if (existingEmployee != null && (employee == null || existingEmployee.Id != employee.Id))
            {
                return new ValidationResult(ErrorMessage ?? "Email must be unique.");
            }
 
            return ValidationResult.Success;
        }
    }
}
 
 
Models/MinAgeAttribute.cs
 
 
using System;
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;
 
        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }
 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;
                // Check if birthday hasn't occurred this year
                if (dateOfBirth.Date > today.AddYears(-age))
                    age--;
 
                if (age < _minAge)
                {
                    return new ValidationResult(ErrorMessage ?? $"Employee must be at least {_minAge} years old.");
                }
            }
            else if (value != null)
            {
                return new ValidationResult("Invalid date format");
            }
 
            return ValidationResult.Success;
        }
    }
}
