using Microsoft.AspNetCore.Mvc;
using MVC_Lab1.Models;

namespace MVC_Lab1.Controllers
{
    public class StudentController : Controller
    {
        ITIEntity _context=new ITIEntity();
        public IActionResult Index()
        {
            //Get All Trainees
            List<Student> traineesModel = _context.Students.ToList();

            return View(traineesModel);
        }
        public IActionResult Details(int id)
        {
            var Student = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(Student);
        }
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Content("Added");
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Content("Delete");
        }

        public IActionResult Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

            return Content("Updated");
        }

       
    }
}
