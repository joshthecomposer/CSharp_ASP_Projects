using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public int PersonId {get;set;}
    [Required]
    public string? Name {get;set;}

    public List<Subscription> Subscriptions {get;set;} = new List<Subscription>();
}