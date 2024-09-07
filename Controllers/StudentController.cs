using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;
using MVC_Lab1.Repository;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace MVC_Lab1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepo;
        private readonly IDepartmentRepository deptRepo;

        public StudentController(IStudentRepository StudentRepo,IDepartmentRepository DeptRepo)
        {
            studentRepo = StudentRepo;
            deptRepo = DeptRepo;
        }

        //Unique Phone
        public IActionResult UniquePhone(string Phone)
        {
            var IsUnique=studentRepo.FindPhone(Phone);
            if (!IsUnique)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult UniqueEmail(string Email)
        {
            var IsUnique = studentRepo.FindEmail(Email);

            if (!IsUnique)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Index()
        {
            //Get All Trainees
            var StudentsModel =studentRepo.GetAllWithDepartment();

            return View(StudentsModel);
        }
        public IActionResult Details(int id)
        {
            var Student = studentRepo.GetById(id);
            return View(Student);
        }
        public IActionResult Create()
        {
            ViewBag.DeptList = deptRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Create(student);
                return RedirectToAction("Index");
            }
           return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            studentRepo.Delete(id);
           return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var student= studentRepo.GetById(Id);
            ViewBag.DeptList = deptRepo.GetAll();

            return View(student);

        }
        [HttpPost]
        public IActionResult Update(int Id,Student Request)
        {
           
           
             if (ModelState.IsValid)
             {
               studentRepo.Update(Request);
                return RedirectToAction("Index");
             }
           return RedirectToAction("Create");
           
           
        }

       
    }
}
