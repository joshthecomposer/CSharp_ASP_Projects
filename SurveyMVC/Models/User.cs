using System.ComponentModel.DataAnnotations;

namespace SurveyMVC.Models;


public class User
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? Language { get; set; }
    [MaxLength(255)]
    public string? Message { get; set; }
}