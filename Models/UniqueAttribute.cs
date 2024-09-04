using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC_Lab1.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        ITIEntity _context = new ITIEntity();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var IsUnique = _context.Students.Any(s => s.Email == value);

            if (!IsUnique )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email Must Be Unique");
            }
        }
    }
}
