using System.ComponentModel.DataAnnotations;


namespace StudentManager.Models
{

public class Student
{
    [Key]
    [Required]
    public int StudentId {get; set;}

    [Required]
    public string StudentName{get; set;} = "";

    [Required]
    [Range(5,100,ErrorMessage ="Age must be between 5 to 100")]
    public int Age{get; set;}

    [Required]
    [EmailAddress]
    public string Email{get; set;} = "";
}
}