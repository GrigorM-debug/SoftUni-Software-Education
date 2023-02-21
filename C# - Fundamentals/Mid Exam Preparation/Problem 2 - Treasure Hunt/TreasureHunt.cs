using System.Reflection;

List<string> items = Console.ReadLine().Split('|').ToList();

string command = Console.ReadLine();    

while (command != "Yohoho!")
{
    string[] commandInfo = command.Split();

    if (commandInfo[0] == "Loot")
    {
        foreach(var item in commandInfo.Skip(1))
        {
            if (!items.Contains(item))
            {
                items.Insert(0, item);
            }
        }         
    }
    else if (commandInfo[0] == "Drop")
    {
        int index = int.Parse(commandInfo[1]);
        if (index >= 0 && index < items.Count)
        {
            string item = items[index];
            items.RemoveAt(index);
            items.Add(item);
        }
    }
    else if (commandInfo[0] == "Steal")
    {
        List<string> stealedItems= new List<string>();
        int count = int.Parse(commandInfo[1]);

        while (count > 0 && items.Count > 0)
        {
            string currItem = items[items.Count - 1];
            stealedItems.Add(currItem);
            items.RemoveAt(items.Count-1);

            count--;    
        }

        stealedItems.Reverse();

        Console.WriteLine(string.Join(", ", stealedItems));
    }
    command = Console.ReadLine();
}

if (items.Count== 0)
{
    Console.WriteLine("Failed treasure hunt.");
}
else
{
    double sum = 0;
    foreach (var item in items)
    {
        sum += item.Length;
    }

    double averageGain = sum / (double)items.Count;
    Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
}
