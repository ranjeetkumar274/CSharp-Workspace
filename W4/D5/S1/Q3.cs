WebAPI
 
W4D5S1Q3
 
 
Store WebApi
 
InventoryController.cs
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api")]
    public class InventoryController : ControllerBase
    {
        public InventoryService inventory;
 
        public InventoryController(InventoryService is1)
        {
            inventory = is1;
        }
 
        [HttpGet("Inventory")]
        public IActionResult GetAllInventories()
        {
            var res = inventory.GetAllItems();
 
            return Ok(res);
        }
 
        [HttpGet("Inventory/{itemId}")]
        public IActionResult GetInventoryById(int itemId)
        {
            var res = inventory.GetItemsById(itemId);
 
            if(res == null)
                return NotFound();
            return Ok(res);
        }
 
        [HttpPost("Inventory")]
        public IActionResult CreateInventoryItem(InventoryItem newItem)
        {
            if(newItem == null)
                return BadRequest();
 
            inventory.AddItem(newItem);
            return CreatedAtAction("CreateInventoryItem", newItem);
        }
 
 
    }
}
 
 
(Models)
ApplicationDbContext.cs
 
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Models
{
    // Write the ApplicationDbContext class here
    // Define the DbSet properties for the InventoryItem entity
 
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
 
        public DbSet<InventoryItem> InventoryItems {get; set;}
    }
}
 
InventoryItem.cs (Models)
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
 
 
 
Services/InventoryServices.cs
 
using System.Collections.Generic;
using dotnetapp.Models;
 
namespace dotnetapp.Services
{
    //Define InventoryService class here
    public class InventoryService
    {
        public ApplicationDbContext db;
 
        public InventoryService(ApplicationDbContext db1)
        {
            db = db1;
        }
 
        public List<InventoryItem> GetAllItems()
        {
            var res = db.InventoryItems.ToList();
 
            return res;
        }
 
        public InventoryItem GetItemsById(int itemId) 
        {
            var item = db.InventoryItems.Find(itemId);
 
            if(item == null)
                return null;
            return item;
        }
 
        public void AddItem(InventoryItem newItem)
        {
            db.InventoryItems.Add(newItem);
            db.SaveChanges();
        }
 
    }
}
 
Program.cs
 
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add Event services to the container.
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
string cs = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
 
builder.Services.AddDbContext<ApplicationDbContext>(p => p.UseSqlServer(cs));
builder.Services.AddScoped<InventoryService>();
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
 
app.UseAuthorization();
 
app.MapControllers();
 
app.Run();
