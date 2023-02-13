namespace FirstMVC.Models;
public class Friend
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Location { get; set; }
    public int Age { get; set; }

    public Friend(){}
    public Friend(string firstName, string lastName, string location, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Location = location;
        this.Age = age;
    }

}