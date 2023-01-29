using System.Diagnostics.CodeAnalysis;

int numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .Where(x => x % 2 == 0)
    .Sum();

Console.WriteLine(numbers);