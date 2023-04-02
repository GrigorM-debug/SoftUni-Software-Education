using System.Net.NetworkInformation;

int n = int.Parse(Console.ReadLine());

Dictionary<string, Plant> plants = new Dictionary<string, Plant>(); 

for (int i = 0; i < n; i++)
{
    string[] plantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

    string name = plantInfo[0];
    int rarity = int.Parse(plantInfo[1]);
    
    if (!plants.ContainsKey(name))
    {
        plants[name].Add(name);
    }
    else
    {
        plants[name].Rarity = rarity;
    }
        
}

string input = Console.ReadLine();

while (input != "Exhibition")
{
    string[] cmdArgs = input.Split(new char[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

    string command = cmdArgs[0];
    string name = cmdArgs[1];

    if (command == "Rate")
    {
        double rating = double.Parse(cmdArgs[2]);

        if (plants.ContainsKey(name))
        {
            plants[name].Rating += rating;
        }
        else
        {
            Console.WriteLine("error");
        }
    }
    else if (command == "Update")
    {
        int newRarity = int.Parse(cmdArgs[2]);

        if (plants.ContainsKey(name))
        {
            plants[name].Rarity = newRarity;
        }
        else
        {
            Console.WriteLine("error");
        }
    }
    else if (command == "Reset")
    {
        if (plants.ContainsKey(name))
        {
            plants[name].Rating = 0;
        }
        else
        {
            Console.WriteLine("error");
        }
    }
    input = Console.ReadLine();
}

foreach (var plant in plants.Values)
{
    //string aveargeRating = plant[name].Ratint;
    Console.WriteLine("Plants for the exhibition:");
    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating:f2}");
}
class Plant
{
    public string Name { get; set; }

    public int Rarity { get; set; }

    public double Rating { get; set; }

    public Plant (string name, int rarity, double rating)
    {
        Name = name;
        Rarity = rarity;
        Rating = rating;
    }
}
//TODO