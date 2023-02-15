using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models;
public class Product
{
    [Key]
    public int ProductId {get;set;}
    [Required]
    [MinLength(2)]
    public string? Name {get;set;}
    [Required]
    [MinLength(2)]
    public string? Description {get;set;}
    [Required]
    [Range(0.0, 9999.0)]
    public double Price {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Association> Categories {get;set;} = new List<Association>();
}