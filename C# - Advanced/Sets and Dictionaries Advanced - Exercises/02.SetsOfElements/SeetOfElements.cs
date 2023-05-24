int[] counts = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

HashSet<int> first = new();
HashSet<int> second = new();

for (int i = 0; i < counts[0]; i++)
{
    first.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < counts[1]; i++)
{
    second.Add(int.Parse(Console.ReadLine()));
}

first.IntersectWith(second);

Console.WriteLine($"{string.Join(" ", first)}");