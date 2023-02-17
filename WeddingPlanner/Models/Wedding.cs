#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;
public class Wedding
{   
    [Key]
    public int WeddingId {get;set;}
    public int UserId {get;set;}
    [Required]
    public string NameOne {get;set;}
    [Required]
    public string NameTwo   {get;set;}
    [Required]
    public DateTime Date {get;set;}
    [Required]
    public string Address {get;set;}

    public DateTime CreatedAt {get;set;} = new DateTime();
    public DateTime UpdatedAt {get;set;} = new DateTime();

    public List<RSVPList> Guests {get;set;} = new List<RSVPList>();
    public User Creator {get;set;}
}