using System.ComponentModel.Design;
using StudentManager.Models;

public class StudentController : Controller
{
    private static List<Student> list = new List<Student>();
    private static int nextId = 1;

    public ActionResult ShowAll()
    {
        return ViewTechnology(list);
    }

    // Add (GET)
    public ActionResult Add()
    {
        return View();
    }



    // Add (POST)
    public ActionResult Add(Student std)
    {
        if (ModelState.IsValid)
        {
            std.StudentId = nextId++;
            list.Add(std);
            return RedirectToAction("ShowAll");
        }
        return View();
    }

}