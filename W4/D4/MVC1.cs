// DepartmentController.cs


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

    public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index() => View(_context.Departments.ToList());

    public IActionResult Details(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

    public IActionResult Create() => View();

    [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    public IActionResult Edit(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

    [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    public IActionResult Delete(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

    [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dept = _context.Departments.Find(id);

            if(dept==null)
            return NotFound();
            _context.Departments.Remove(dept);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}




// EmployeeController.cs


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
        {
            return View(_context.Employees.Include(e => e.Department).ToList());
        }

    public IActionResult Details(int id)
        {
            var emp = _context.Employees.Include(e => e.Department)
                                        .FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

    public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View();
        }

    [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    
    public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return NotFound();
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name", emp.DepartmentId);
            return View(emp);
        }

    [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Include(e => e.Department)
                                        .FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

    [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = _context.Employees.Find(id);
            if(emp==null)
            return NotFound();
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}




// Department.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

    [Required]
        public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
    }
}





// Employee.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

    [Required]
        public string FirstName { get; set; }

    [Required]
        public string LastName { get; set; }

    [ForeignKey("Department")]
        public int DepartmentId { get; set; }

    public Department Department { get; set; }
    }
}


// ErrorViewModels.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    
    

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
    



// Program.cs

using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=appdb;User Id=sa;Password=examMySql@123;Trusted_Connection=False;Persist Security Info=False;Encrypt=False"));

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




// ApplicationDbContext.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace dotnetapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
