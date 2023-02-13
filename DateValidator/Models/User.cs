using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    [MinLength(2)]
    public string? Name { get; set; }
    [FutureDate]
    public DateTime Birthday { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object date, ValidationContext validationContext)    
    {      
        if ((DateTime)date > DateTime.Now)
        {
            return new ValidationResult("You can't have been born in the future!");
        }
        else
        {
            return ValidationResult.Success!; 
        }
    }
}