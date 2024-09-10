using MVC_Lab1.Models;

namespace MVC_Lab1.Repository
{
    public interface ICourseRepository:IRepository<Course>
    {
        public IEnumerable<Course> GetAllWithDepartment();

    }
}
