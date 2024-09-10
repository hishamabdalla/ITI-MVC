using MVC_Lab1.Models;

namespace MVC_Lab1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ITIEntity _context;

        public DepartmentRepository(ITIEntity context)
        {
            this._context = context;
        }
      
        public IEnumerable<Department> GetAll()
        {
            
            return _context.Departments.Where(w=>w.States==true).ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Where(w => w.States == true).FirstOrDefault(s => s.Id == id);
        }

        public void Create(Department entity)
        {
            entity.States = true;
            _context.Departments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = GetById(id);
           department.States=false;
            _context.SaveChanges();

        }
        public void Update(Department entity)
        {
            entity.States=true;
            _context.Departments.Update(entity);
            _context.SaveChanges();

        }
    }
}
