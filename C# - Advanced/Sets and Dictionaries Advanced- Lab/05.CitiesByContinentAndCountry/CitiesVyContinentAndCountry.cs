Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

int numberOfInputs = int.Parse(Console.ReadLine());

for (int i =0; i < numberOfInputs; i++)
{
    string[] tokens = Console.ReadLine().Split();
    string continent = tokens[0];
    string country = tokens[1];
    string city = tokens[2];

    if (!continents.ContainsKey(continent))
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
    }
    if (!continents[continent].ContainsKey(country))
    {
        continents[continent].Add(country, new List<string>());
    }

    continents[continent][country].Add(city);
}
foreach(var (continent, countreis) in continents)
{
    Console.WriteLine($"{continent}:");

    foreach(var (country, city) in countreis)
    {
        Console.WriteLine($" {country} -> {string.Join(", ", city)}");
    }
}