Func<HashSet<int>, int> minNumber = numbers =>
{
    int minNumber = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < minNumber)
        {
            minNumber = number;
        }
    }
    return minNumber;
};


HashSet<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

Console.WriteLine(minNumber(numbers));