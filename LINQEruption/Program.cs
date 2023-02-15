List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

Eruption FirstInChile = eruptions.FirstOrDefault(c => c.Location == "Chile");
if (FirstInChile == null)
{
    Console.WriteLine("nO CHILE Found");
}
else 
{
    Console.WriteLine(FirstInChile);
}

Eruption FirstHawaiianIs = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
if (FirstHawaiianIs == null)
{
    Console.WriteLine("No Hawaii Eruption Found");
}
else 
{
    Console.WriteLine(FirstHawaiianIs);
}

Eruption FirstGreenland = eruptions.FirstOrDefault(c => c.Location == "Greenland");
if (FirstGreenland == null)
{
    Console.WriteLine("No Greenland one found");
}
else
{
    Console.WriteLine(FirstGreenland);
}

Eruption NZ = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
if (NZ == null)
{
    Console.WriteLine("NONE from nz after 1900");
}
else
{
    Console.WriteLine(NZ);
}

IEnumerable<Eruption> Elevations = eruptions.Where(c => c.ElevationInMeters > 2000).ToList();
PrintEach(Elevations, "Elevations above 2000");

IEnumerable<Eruption> StartsWithL = eruptions.Where(c => char.ToLower(c.Volcano[0]) == 'l');
Console.WriteLine(StartsWithL.Count() + " found that start with L");
PrintEach(StartsWithL, "Eruptions that start with l"); 

int HighestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(HighestElevation);
string HighestName = eruptions.FirstOrDefault(e=>e.ElevationInMeters == HighestElevation).Volcano;
Console.WriteLine(HighestName);

IEnumerable<Eruption> NamesAlphabetical = eruptions.OrderBy(e => e.Volcano);
foreach(Eruption e in NamesAlphabetical)
{
    Console.WriteLine(e.Volcano);
}

int SumOfElevations = eruptions.Sum(e=>e.ElevationInMeters);
Console.WriteLine(SumOfElevations);

bool Year2000 = eruptions.Any(e=>e.Year==2000);
Console.WriteLine(Year2000);

IEnumerable<Eruption> FirstThreeStratoVolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(2);
PrintEach(FirstThreeStratoVolcanoes, "First Two Strato Volcanoes");

IEnumerable<string> query = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
foreach(string v in query)
{
    Console.WriteLine(v);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
