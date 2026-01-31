using Microsoft.AspNetCore.Mvc;
using GymPass.Models;

namespace GymPass.Controllers
{
    public class PassController: Controller
    {
        public PassDbContext cont;

        public PassController(PassDbContext context)
        {
            cont = context;
        }

        public IActionResult Index()
        {
            var list = cont.Passes.ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Pass p)
        {
            if (ModelState.IsValid)
            {
                cont.Passes.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }


        public IActionResult ShowAll()
        {
            return RedirectToAction("Index");
        }

    }
}