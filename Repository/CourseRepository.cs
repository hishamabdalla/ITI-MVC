using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;

namespace MVC_Lab1.Repository
{

    public class CourseRepository:ICourseRepository

    {
        private readonly ITIEntity _context;

        public CourseRepository(ITIEntity context)
        {
            this._context = context;
        }
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }
        public IEnumerable<Course> GetAllWithDepartment()
        {
            // Using Include to load related Department data
            return _context.Courses.Include(s => s.Department).ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Include(d=>d.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Create(Course entity)
        {
            _context.Courses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();

            }

        }

        public void Update(Course entity)
        {
            _context.Courses.Update(entity);
            _context.SaveChanges();
        }
    }
}
