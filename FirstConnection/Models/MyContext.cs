#pragma warning disable CS8618
namespace FirstConnection.Models;
using Microsoft.EntityFrameworkCore;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<Pet> Pets { get; set; }
}