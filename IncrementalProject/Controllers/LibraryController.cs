using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
namespace dotnetapp.Controllers
{
    [Route("libraries")]
    public class LibraryController : Controller
    {
        public ApplicationDbContext db;
        public LibraryController(ApplicationDbContext obj)
        {
            db=obj;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var res = db.Libraries.ToList();
           return View(res);
        }
        [HttpGet]
        [Route("create")]
        public  IActionResult Create()
        {
           return View();  
        }
        [HttpPost]
        [Route("create")]
        public  IActionResult Create(Library library)
        {
            db.Libraries.Add(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
