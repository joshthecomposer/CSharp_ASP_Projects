using System.ComponentModel.DataAnnotations;

public class User
{
    public string Name { get; set; }

    public User() { Name = "Anonymous"; }
    public User(string name) { Name = name; }
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


