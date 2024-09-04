using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
