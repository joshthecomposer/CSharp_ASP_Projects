#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EFCoreTest.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(1)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(1)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    public DateTime CreatedAt = DateTime.Now;
    public DateTime UpdatedAt = DateTime.Now;
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


