#pragma warning disable CS8618
namespace RecipeBookCRUD.Models;
using Microsoft.EntityFrameworkCore;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Chef> Chefs {get;set;}
}