
List<string> coffees = Console.ReadLine().Split().ToList();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] commandInfo = Console.ReadLine().Split();

    if (commandInfo[0] == "Include")
    {
        string coffee = commandInfo[1];  
        coffees.Add(coffee);
    }
    else if (commandInfo[0] == "Remove")
    {
        string type = commandInfo[1];
        int indexForRemoving = int.Parse(commandInfo[2]);
        if (indexForRemoving >= coffees.Count || indexForRemoving < 0)
        {
            commandInfo.Skip(0);
        }
        else
        {
            if (type == "first")
            {
                for (int k = 0; k < indexForRemoving; k++)
                {
                    coffees.RemoveAt(0);
                }
            }
            else if (type == "last")
            {
                for (int a = 0; a < indexForRemoving; a++)
                {
                    coffees.RemoveAt(coffees.Count - 1);
                }
            }
        }
    }
    else if (commandInfo[0] == "Prefer")
    {
        int indexOne = int.Parse(commandInfo[1]);
        int indexTwo = int.Parse(commandInfo[2]);

        if (indexOne < 0 || indexOne >= coffees.Count || indexTwo < 0 || indexTwo>= coffees.Count)
        {
            commandInfo.Skip(0);
        }
        else
        {
            string firstIndex = coffees[indexOne];
            coffees[indexOne] = coffees[indexTwo];
            coffees[indexTwo] = firstIndex;
        }
    }
    else if (commandInfo[0] == "Reverse")
    {
        coffees.Reverse();
    }
}
Console.WriteLine("Coffees:");
Console.WriteLine(string.Join(" ", coffees));