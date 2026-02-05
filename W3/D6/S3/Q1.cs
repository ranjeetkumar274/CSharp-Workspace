linq 1:
 
Product Controller
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class ProductController : Controller
    {
        public AppDbContext db {get;set;}
        public ProductController(AppDbContext db1){
            db=db1;
        }
        public IActionResult DisplayAllProducts(){
        var res = db.Products.Include(a=>a.Category).ToList();
        return View(res);
    }
    public IActionResult AddProduct(Product obj){
        db.Products.Add(obj);
        db.SaveChanges();
        return View();
    }
    }
 
   
}
 
 
Category.cs
 
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    // Write your Category class here...
    public class Category{
 
        [Key]
        public int CategoryId{get;set;}
 
        [Required]
        [StringLength (100)]
        public string Name{get;set;}
 
 
        [StringLength (500)]
        public string Description{get;set;}
        public ICollection<Product> Products {get;set;} = new List<Product>();
    }
}
 
 
Product.cs
 
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    // Write your Product class here...
    public class Product{
        [Key]
        public int ProductId{get;set;}
        [Required]
        public string Name{get;set;}
        public decimal Price{get;set;}
        public int Stock {get;set;}
        public int CategoryId{get;set;}
        public Category Category{get;set;}
    }
}
 
 
AppDbContext.cs
 
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Models
{
   
        //Write AppDbContext here...
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
               
        }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        protected override void OnModelCreating(ModelBuilder m){
            m.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId);
 
            m.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name="Electronics",
                    Description="Very Good"
                }
            );
        }
    }
}
 
 
