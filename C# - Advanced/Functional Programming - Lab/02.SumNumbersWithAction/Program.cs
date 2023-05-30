Action<string> stringToInt = n => int.Parse(n);

int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => stringToInt(n))
    .ToArray();

Console.WriteLine(numbers.Count());
Console.WriteLine(numbers.Sum());