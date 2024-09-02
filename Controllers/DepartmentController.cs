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
            var departments = _context.Departments.ToList();
            return View(departments);

        }

        public IActionResult GetDepartment(int id)
        {
            var departments = _context.Departments.FirstOrDefault(x => x.Id == id);
            return View(departments);
        }
        public IActionResult Create(Department dept)
        {
            var res = _context.Departments.Add(dept);
            _context.SaveChanges();
            return Content("department added");
        }

        public IActionResult Delete(int Id)
        {
            var departments = _context.Departments.FirstOrDefault(x => x.Id == Id);
            _context.Departments.Remove(departments);
            _context.SaveChanges();
            return Content("department removed");
        }

        public IActionResult Update(Department dept)
        {
            _context.Departments.Update(dept);
            _context.SaveChanges();

            return Content("Department Updated");
        }
    }
}
