using MVC_Lab1.Models;

namespace MVC_Lab1.Repository
{
    public interface IStudentRepository: IRepository<Student>
    {
        public IEnumerable<Student> GetAllWithDepartment();
       bool FindPhone(string phone,int Id);
       bool FindEmail(string Email, int Id);

    }
}
