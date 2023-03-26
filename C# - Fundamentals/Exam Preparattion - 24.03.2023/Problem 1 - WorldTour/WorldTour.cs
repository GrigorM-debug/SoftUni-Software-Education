string stops = Console.ReadLine();

string input = Console.ReadLine();

while (input != "Travel")
{
    string[] commandArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

    string command = commandArgs[0];

    if (command == "Add Stop")
    {
        int index = int.Parse(commandArgs[1]);
        string stopToReplace = commandArgs[2];

        if (index >= 0 && index <= stops.Length-1)
        {
            stops = stops.Insert(index, stopToReplace);
        }
        Console.WriteLine(stops);
    }
    else if (command == "Remove Stop")
    {
        int startIndex = int.Parse(commandArgs[1]);
        int endIndex = int.Parse(commandArgs[2]);

        if (startIndex >= 0 && endIndex >= 0 && startIndex <= stops.Length-1 && endIndex <= stops.Length-1)
        {
            stops = stops.Remove(startIndex, endIndex + 1 - startIndex);
        }

        Console.WriteLine(stops);
    }
    else if (command == "Switch")
    {
        string oldString = commandArgs[1];
        string newString = commandArgs[2];

        if (stops.Contains(oldString))
        {
            stops = stops.Replace(oldString, newString);
        }

        Console.WriteLine(stops);
    }
    input = Console.ReadLine();
}

Console.WriteLine($"Ready for world tour! Planned stops: {stops}");