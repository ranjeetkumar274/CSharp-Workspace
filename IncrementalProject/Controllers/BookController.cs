using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using System.Threading.Tasks.Dataflow;
 
namespace dotnetapp.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        public ApplicationDbContext db;
        public BookController(ApplicationDbContext obj)
        {
           db=obj;
        }
        public static List<Book> books{get;set;} = new List<Book>();
        [Route("")]
         public IActionResult Index()
        {
            return View(books);
        }
        [Route("")]
        [HttpGet]
        public IActionResult IndexDbContext()
        {
            var res = db.Books.ToList();
            return View(res);
        }
        [Route("create")]
        [HttpGet]
        public IActionResult CreateDbContext()
        {
            return View();
        }
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateDbContext(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("IndexDbContext");
        }
        [Route("create")]
        public IActionResult Create(Book book)
        {
            books.Add(book);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditDbContext(int id)
        {
            var res = db.Books.Find(id);
            return View(res);
        }
        [HttpPost]
        public IActionResult EditDbContext(int id,Book book)
        {
            var res = db.Books.Find(id);
            return RedirectToAction("IndexContextPage");
        }
       
        public IActionResult DeleteDbContext(int id)
        {
            var res = db.Books.Find(id);
            return View(res);
        }
        [HttpPost]
        public IActionResult DeleteConfirmedDbContext(int id)
        {
            var res = db.Books.Find(id);
            db.Books.Remove(res);
            db.SaveChanges();
            return RedirectToAction("IndexDbContext");
        }
 
    }
}
