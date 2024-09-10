using Microsoft.AspNetCore.Mvc;
using MVC_Lab1.Models;
using MVC_Lab1.Repository;

namespace MVC_Lab1.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IDepartmentRepository _deptRepo;
        public CourseController(ICourseRepository courseRepo, IDepartmentRepository deptRepo)
        {
            this._courseRepo = courseRepo;
            _deptRepo = deptRepo;
        }
        public IActionResult Index()
        {
            //Get All Trainees
            var CourseModel = _courseRepo.GetAllWithDepartment();

            return View(CourseModel);
        }
        public IActionResult Details(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }
        public IActionResult Create()
        {
            ViewBag.DeptList = _deptRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Create(course);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            _courseRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var course = _courseRepo.GetById(Id);
            ViewBag.DeptList = _deptRepo.GetAll();

            return View(course);

        }
        [HttpPost]
        public IActionResult Update(int Id, Course Request)
        {

            if (ModelState.IsValid)
            {
                _courseRepo.Update(Request);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");


        }

    }
}
