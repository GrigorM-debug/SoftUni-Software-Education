List<int> numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

for (int i =0; i < numbers.Count-1; i++)
{
    numbers[i] += numbers.Count - 1;
    
}
Console.WriteLine(string.Join(" ", numbers));