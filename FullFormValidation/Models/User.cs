using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

public class User
{
    [Required]
    [MinLength(2)]
    public string? Name { get; set; }
    [Required]
    [EmailFormat]
    public string? Email { get; set; }
    [Required]
    [BirthCheck]
    public DateTime Birthday { get; set; }
    [Required]
    [MinLength(8)]
    public string? Password { get; set; }
    [Required]
    [OddCheck]
    public int FavoriteOddNumber { get; set; }
}

public class EmailFormatAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required");
        }
        try
        {
            MailAddress m = new MailAddress((string)value);
            return ValidationResult.Success!;
        }
        catch  (FormatException)
        {
            return new ValidationResult("Email is the wrong format!");
        }
    }
}

public class BirthCheckAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if ((DateTime?)value >= DateTime.Now)
        {
            return new ValidationResult("You can't have been born in the future!");
        }
        else
        {
            return ValidationResult.Success!;
        }
    }
}

public class OddCheckAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        int number = (int)value!;
        if (number < 2)
        {
            return new ValidationResult("Number is not prime!");
        }
        if (number == 2)
        {
            return ValidationResult.Success!;
        }
        if (number % 2 == 0)
        {
            return new ValidationResult("Number is not prime!");
        }
        for(int i = 3; i <= (int)Math.Floor(Math.Sqrt(number)); i+=2)
        {
            if (number % i == 0)
            {
                return new ValidationResult("Number is not prime!"); 
            }
        }
        return ValidationResult.Success!;
    }
}