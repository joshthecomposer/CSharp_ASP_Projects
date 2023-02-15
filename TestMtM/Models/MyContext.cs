#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace TestMtM.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }    

    public DbSet<Person> People { get; set; } 
    public DbSet<Magazine> Magazines { get; set; } 
    public DbSet<Subscription> Subscriptions { get; set; } 
}
