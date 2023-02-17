#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class RSVPList
{
    [Key]
    public int RSVPListId {get;set;}
    public int UserId {get;set;}
    public int WeddingId {get;set;}

    [NotMapped]
    public User User {get;set;}
    [NotMapped]
    public Wedding Wedding {get;set;}
}