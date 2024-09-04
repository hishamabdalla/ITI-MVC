using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;

namespace MVC_Lab1.Controllers
{
    public class StudentController : Controller
    {
        ITIEntity _context=new ITIEntity();
        public IActionResult Index()
        {
            //Get All Trainees
            var StudentsModel = _context.Students.Include(s=>s.Department).ToList();

            return View(StudentsModel);
        }
        public IActionResult Details(int id)
        {
            var Student = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(Student);
        }
        public IActionResult Create()
        {
            ViewBag.DeptList=_context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null) {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
           return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var student= _context.Students.FirstOrDefault(s=>s.Id == Id);
            ViewBag.DeptList = _context.Departments.ToList();

            return View(student);

        }
        [HttpPost]
        public IActionResult Update(int Id,Student Request)
        {
            Student DbStudent = _context.Students.SingleOrDefault(x => x.Id==Id);
            DbStudent.Name=Request.Name;
            DbStudent.Address=Request.Address;

            _context.Students.Update(DbStudent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       
    }
}
