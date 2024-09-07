using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;
using MVC_Lab1.Repository;

namespace MVC_Lab1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public DepartmentController(IDepartmentRepository DeptRepo)
        {
            deptRepo = DeptRepo;
        }

        public IActionResult Index()
        {
            List<Department> departments = deptRepo.GetAll().ToList();

            return View(departments); 
        }

        public IActionResult Details(int id)
        {
            var departments = deptRepo.GetById(id);
            return View(departments);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            deptRepo.Create(dept);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
           deptRepo.Delete(Id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var department = deptRepo.GetById(Id);
            return View(department);

        }

        [HttpPost]
        public IActionResult Update(int Id,Department Request)
        {

           deptRepo.Update(Request);
            return RedirectToAction("Index");
        }
    }
}
