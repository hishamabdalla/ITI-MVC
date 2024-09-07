using Microsoft.EntityFrameworkCore;
using MVC_Lab1.Models;

namespace MVC_Lab1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ITIEntity _context;
        public StudentRepository(ITIEntity context)
        {
            this._context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public IEnumerable<Student> GetAllWithDepartment()
        {
            // Using Include to load related Department data
            return _context.Students.Include(s => s.Department).ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
      
        public void Create(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

            }

        }

        public void Update(Student entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();
        }

        public bool FindPhone(string phone)
        {
            return _context.Students.Any(s => s.Phone == phone);
        }

        public bool FindEmail(string email)
        {
            return _context.Students.Any(s => s.Email == email);
        }
    }
}
