#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> Users { get; set; }
    public DbSet<Wedding> Weddings {get;set;}
    public DbSet<RSVPList> RSVPLists {get;set;}
}