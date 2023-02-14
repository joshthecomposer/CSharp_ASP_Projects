#pragma warning disable CS8618
namespace LoginRegistration.Models;
using Microsoft.EntityFrameworkCore;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> Users { get; set; }
}