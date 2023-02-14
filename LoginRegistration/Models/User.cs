#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [NotEmailExists]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }
    [NotMapped]
    [MinLength(8)]
    [Compare("Password")]
    public string Confirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
// Custom annotation template
public class NotEmailExistsAttribute : ValidationAttribute
{
protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {   
        if (value == null)
        {
            return new ValidationResult("Email is required.");
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext))!;
        if (_context.Users.Any(e=>e.Email == value.ToString()))
        {
            return new ValidationResult("This email already exists");
        } else {
            return ValidationResult.Success!;
        }
    }
}