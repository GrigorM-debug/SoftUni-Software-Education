int count = int.Parse(Console.ReadLine());

SortedSet<string> periodicTable = new SortedSet<string>();  

for (int i = 0; i < count; i++)
{
    string[] elements = Console.ReadLine().Split(" ");

    periodicTable.UnionWith(elements);
}

Console.WriteLine($"{string.Join(" ", periodicTable)}");
