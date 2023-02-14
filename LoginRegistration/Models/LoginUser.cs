#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace LoginRegistration.Models;
public class LoginUser
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
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