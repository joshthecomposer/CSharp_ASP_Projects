using System.ComponentModel.DataAnnotations;
public class Magazine
{
    [Key]
    public int MagazineId {get;set;}
    [Required]
    public string? Title {get;set;}

    public List<Subscription> Readers {get;set;} = new List<Subscription>();
}