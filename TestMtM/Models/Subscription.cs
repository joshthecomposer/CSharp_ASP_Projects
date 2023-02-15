using System.ComponentModel.DataAnnotations;

public class Subscription
{
    [Key]
    public int SubscriptionId {get;set;}
    public int PersonId {get;set;}
    public int MagazineId {get;set;}

    public Person? Person {get;set;}
    public Magazine? Magazine {get;set;}

}