using System.ComponentModel.DataAnnotations;

namespace SurveyMVC.Models;


public class User
{
    [Required]
    [NoJNames]
    [MinLength(2)]
    public string? Name { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? Language { get; set; }
    [MinLength(20)]
    public string? Message { get; set; }
}

public class NoJNamesAttribute : ValidationAttribute
{
protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (((string)value).ToLower()[0] == 'j')
        {
            return new ValidationResult("NO J NAMES!");
        } else {
            return ValidationResult.Success!;
        }
    }
}