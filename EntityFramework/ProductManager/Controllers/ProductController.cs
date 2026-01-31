using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;


namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {

        public static ProductDbContext cont;

        public ProductController(ProductDbContext context)
        {
            cont = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Show()
        {
            var products = cont.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                cont.Products.Add(p);
                cont.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(p);
        }
    }
}