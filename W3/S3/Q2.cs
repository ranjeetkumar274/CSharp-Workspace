// StudentController.cs


using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class StudentController : Controller
    {
        public AppDbContext db;
        public StudentController(AppDbContext db1)
        {
            db = db1;
        }

    public IActionResult AddStudent()
        {
            // var cs = db.Courses.ToList();
            // ViewBag.Courses = new SelectList(cs,"CourseId","Title");
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student obj)
        {

    db.Students.Add(obj);
            db.SaveChanges();
            return RedirectToAction("DisplayAllStudents");
        }
        public IActionResult DisplayAllStudents()
        {
            var res = db.Students.Include(s=>s.Course).ToList();
            return View(res);
        }
        public IActionResult UpdateStudent(int id)
        {
            var res = db.Students.Find(id);

    return View(res);
        }
        [HttpPost]
        public IActionResult SearchStudentsByName(string name)
        {
            var res = db.Students.Where(s=>s.Name == name).ToList();

    return View(res);
        }
        public IActionResult UpdateStudent(Student obj)
        {
            var res = db.Students.Find(obj.StudentId);
            if(res!=null)
            {
                res.Name = obj.Name;
                res.Email = obj.Email;
                res.YearOfJoining = obj.YearOfJoining;
                res.CourseId = obj.CourseId;
                res.Course = obj.Course;
                db.SaveChanges();
                return RedirectToAction("DisplayAllStudents");
            }
            return View();
        }
    }
}





// AppDbContext.cs

using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Models
{

    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Student>().
                    HasOne(c => c.Course).
                    WithMany(s => s.Students).
                    HasForeignKey(cou => cou.CourseId);
            m.Entity<Course>().HasData
            (
                    new Course
                    {
                        CourseId = 1,
                        Title = "Mathematics 101",
                        Description = "Basic Mathematics"
                    },
                    new Course
                    {
                        CourseId = 2,
                        Title = "History 101",
                        Description = "Introduction to History"
                    }
            );
        }
    }

}



// Course.cs

using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class Course
    {

    [Key]
    public int CourseId {get;set;}
        [Required]
        [StringLength(100)]
        public string Title {get;set;}
        [Required]
        [StringLength(500)]
        public string Description{get;set;}
        public ICollection<Student> Students {get;set;}
    }
}



// Student.cs


using System.Resources;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class Student
    {
        [Key]
        public int StudentId {get;set;}

    [Required]
        [StringLength(100)]
        public string Name {get;set;}

    [Required]
        [EmailAddress]
        public string Email {get;set;}

    [Required]
        [Range(0,int.MaxValue)]
        public int YearOfJoining {get;set;}
        public int CourseId {get;set;}
        public Course Course{get;set;}
    }
}




// AddStudent.cshtml

@model dotnetapp.Models.Student

@{
    ViewData["Title"] = "Add Student";
}

<h2>Add New Student</h2>

<form asp-action="AddStudent" method="post">
    <div class="form-group">
        <label asp-for="Name" class="control-label">Name:</label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Email" class="control-label">Email:</label>
        <input asp-for="Email" class="form-control" />
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="YearOfJoining" class="control-label">Year of Joining:</label>
        <input asp-for="YearOfJoining" class="form-control" type="number" />
        <span asp-validation-for="YearOfJoining" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="CourseId" class="control-label">Course:</label>
        <select asp-for="CourseId" class="form-control" asp-items="ViewBag.Courses"></select>
        <span asp-validation-for="CourseId" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Add Student</button>
</form>




// DisplayAllStudents.cshtml


@* @model List<dotnetapp.Models.Student>

<p>
    <a asp-action="AddStudent" class="btn btn-primary">Add Student</a>
</p>

<form asp-controller="Student" asp-action="SearchStudentsByName" method="post">
    <div class="form-group">
        <label for="searchQuery">Search by Name:</label>
        <div class="button-container">
            <input type="text" id="searchQuery" name="query" class="form-control textfield" />
            <button type="submit" class="btn btn-primary">Search</button>
        </div>
    </div>
</form>

<h2>All Students</h2>

<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Year of Joining</th>
            <th>Course</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var student in Model)
        {
            <tr>
                <td>@student.Name</td>
                <td>@student.Email</td>
                <td>@student.YearOfJoining</td>
                <td>@student.Course?.Title</td>
            </tr>
        }
    </tbody>
</table> *@



@model List<dotnetapp.Models.Student>

<p>
    <a asp-action="AddStudent" class="btn btn-primary">Add Student</a>
</p>

<form asp-controller="Student" asp-action="SearchStudentsByName" method="post">
    <div class="form-group">
        <label for="searchQuery">Search by Name:</label>
        <div class="button-container">
            <input type="text" id="searchQuery" name="query" class="form-control textfield" />
            <button type="submit" class="btn btn-primary">Search</button>
        </div>
    </div>
</form>

<h2>All Students</h2>

<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Year of Joining</th>
            <th>Course</th>
            <th>Actions</th> <!-- New column for actions -->
        </tr>
    </thead>
    <tbody>
        @foreach (var student in Model)
        {
            <tr>
                <td>@student.Name</td>
                <td>@student.Email</td>
                <td>@student.YearOfJoining</td>
                <td>@student.Course?.Title</td>
                <td>
                    <!-- Update button linking to the UpdateStudent action -->
                    <a asp-action="UpdateStudent" asp-controller="Student" asp-route-id="@student.StudentId" class="btn btn-secondary">Update</a>
                </td>
            </tr>
        }
    </tbody>
</table>




// UpdateStudent.cshtml


@model dotnetapp.Models.Student

@{
    ViewData["Title"] = "Update Student";
}

<h2>Update Student</h2>

<form asp-action="UpdateStudent" method="post">
    <input type="hidden" asp-for="StudentId" />

    <div class="form-group">
        <label asp-for="Name" class="control-label"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Email" class="control-label"></label>
        <input asp-for="Email" class="form-control" />
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="YearOfJoining" class="control-label"></label>
        <input asp-for="YearOfJoining" type="number" class="form-control" />
        <span asp-validation-for="YearOfJoining" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="CourseId" class="control-label"></label>
        <select asp-for="CourseId" asp-items="ViewBag.Courses" class="form-control">
            <option value="">Select Course</option>
        </select>
        <span asp-validation-for="CourseId" class="text-danger"></span>
    </div>
    <div class="form-group">
        <button type="submit" class="btn btn-primary">Update Student</button>
    </div>
    <a asp-action="DisplayAllStudents" class="btn btn-secondary">Back to List</a>
</form>





// Program.cs


using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("user id =sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;Persist Security Info=false; Encrypt=false")
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
