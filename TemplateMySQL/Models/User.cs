#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TemplateMySQL.Models;
public class User
{
    [Key]
    public string UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

//Custom annotation template
// public class ValidationNameAttribute : ValidationAttribute
// {
//   protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//     {
//         if (LogicToBreakValidation)
//         {
//             return new ValidationResult("Custom error message");
//         } else {
//             return ValidationResult.Success;
//         }
//     }
// }