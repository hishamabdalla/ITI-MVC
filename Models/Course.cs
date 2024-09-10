using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(30, 60)]
        public int Duration { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }

    }
}
