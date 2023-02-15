#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace RecipeBookCRUD.Models;
public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    [MinLength(2)]
    public string FirstName {get;set;}
    [Required]
    [MinLength(2)]
    public string LastName {get;set;}
    [Required]
    public DateTime Birthday {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Recipe> AllRecipes = new List<Recipe>();
}