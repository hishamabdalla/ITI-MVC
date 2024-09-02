using Microsoft.EntityFrameworkCore;

namespace MVC_Lab1.Models
{
    public class ITIEntity : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Hisham\SQLEXPRESS;Initial Catalog=MVCTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
    }
}
