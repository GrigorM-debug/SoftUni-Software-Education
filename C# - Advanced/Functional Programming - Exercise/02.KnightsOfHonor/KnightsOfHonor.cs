Action<string[]> printNames = names =>
{
    foreach(var name in names)
    {
        Console.WriteLine($"Sir {name}");
    }
};


string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printNames(names);