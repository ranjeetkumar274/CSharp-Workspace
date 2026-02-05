WebAPI
 
W4D5S1Q1
 
 
productController.cs
 
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
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        public ProductService ps;
        public ProductController(ProductService p)
        {
            ps = p;
        }
 
        [HttpGet]
        public IActionResult GettAllProducts()
        {
            var res = ps.GetAllProducts();
 
            return Ok(res);
        }
 
        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var res = ps.GetProductById(productId);
 
            if(res == null)
                return NotFound();
 
            return Ok(res);
        }
 
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newPro)
        {
            ps.AddProduct(newPro);
            return StatusCode(201, newPro);
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var res = ps.GetProductById(id);
            if (res == null)
            {
                return NotFound();
            }
 
            ps.UpdateProduct(id, updatedProduct);
            return Ok(updatedProduct);
        }
 
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var res = ps.GetProductById(id);
 
            if (res == null)
            {
                return NotFound();
            }
 
            ps.DeleteProduct(id);
 
            return NoContent();
        }
 
    }
}
 
 
Models/Product.cs
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace dotnetapp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
 
        public Product(){}
    }
}
 
 
Services/ProductService.cs
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
 
namespace dotnetapp.Services
{
    public class ProductService
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product{Id = 1, Name = "Product1", Price= 10.99m},
            new Product{Id = 2, Name = "Product2", Price= 20.49m},
            new Product{Id = 3, Name = "Product3", Price= 15.99m},
        };
 
        public List<Product> GetAllProducts()
        {
            var res = Products.ToList();
 
            return res;
        }
 
        public Product GetProductById(int id)
        {
            var res = Products.FirstOrDefault(p => p.Id == id);
 
            if (res == null)
            {
                return null;
            }
 
            return res;
        }
 
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
 
        public void UpdateProduct(int id, Product pr)
        {
            var res = Products.Find(p => p.Id == id);
 
            if (res == null)
                return;
 
            res.Name = pr.Name;
            res.Price = pr.Price;
            res.Description = pr.Description;
        }
 
        public void DeleteProduct(int id)
        {
            var res = Products.Find(p => p.Id == id);
 
            Products.Remove(res);
        }
    }
}
 
 
program.cs
 
using dotnetapp.Services;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add Event services to the container.
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService>();
 
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
