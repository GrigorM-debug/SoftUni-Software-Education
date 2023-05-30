
Func<string, int> stringToInt = n => int.Parse(n);

int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(stringToInt)
    .ToArray();

Console.WriteLine(numbers.Count());
Console.WriteLine(numbers.Sum());