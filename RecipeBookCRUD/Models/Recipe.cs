#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace RecipeBookCRUD.Models;
public class Recipe
{
    [Key]
    public int RecipeId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Chef { get; set; }
    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }
    public int Calories { get; set; }
    public string Description { get; set; }

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