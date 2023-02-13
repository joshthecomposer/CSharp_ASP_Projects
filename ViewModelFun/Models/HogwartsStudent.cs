public class HogWartsStudent
{
    public string? Name { get; set; }
    public string? House { get; set; }
    public string? CurrentYear { get; set; }

    public HogWartsStudent(){}
    public HogWartsStudent(string name, string house, string currentYear)
    {
        Name = name;
        House = house;
        CurrentYear = currentYear;
    }
}