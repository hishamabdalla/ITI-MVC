using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;

namespace MVC_Lab1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIEntity _context = new ITIEntity();

        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.ToList();

            return View(departments); 
        }

        public IActionResult Details(int id)
        {
            var departments = _context.Departments.FirstOrDefault(x => x.Id == id);
            return View(departments);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            var res = _context.Departments.Add(dept);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var departments = _context.Departments.FirstOrDefault(x => x.Id == Id);
            _context.Departments.Remove(departments);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var department = _context.Departments.FirstOrDefault(s => s.Id == Id);
            return View(department);

        }

        [HttpPost]
        public IActionResult Update(int Id,Department Request)
        {

            Department department = _context.Departments.SingleOrDefault(x => x.Id == Id);
            department.Name = Request.Name;
            department.MangerName = Request.MangerName;

            _context.Departments.Update(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
