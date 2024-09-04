using Microsoft.AspNetCore.Mvc;
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
        [Required]
        [Remote("UniquePhone", "Student", ErrorMessage = "Phone Must be Unique")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only.")]
        

        public string Phone { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address.")]
        [Remote("UniqueEmail", "Student", ErrorMessage = "Email Must be Unique")]
        [Required]
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
