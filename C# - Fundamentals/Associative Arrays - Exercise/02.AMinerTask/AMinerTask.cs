var mine = new Dictionary<string, int>();

string input = Console.ReadLine();

while (input != "stop")
{
    string resouces = input;
    int quantity = int.Parse(Console.ReadLine());

    if(!mine.ContainsKey(resouces))
    {
        mine.Add(resouces, 0);
    }

    mine[resouces] += quantity;

    input = Console.ReadLine();
}

foreach(var currentResources in mine)
{
    Console.WriteLine($"{currentResources.Key} -> {currentResources.Value}");
}



