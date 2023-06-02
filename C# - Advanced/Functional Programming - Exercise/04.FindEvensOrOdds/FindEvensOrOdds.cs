using System.Data;
using System.Text.Unicode;

Func<int, int, List<int>> generateRange = (start, end) =>
{
    List<int> range = new();

    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }

    return range;
};

//The default value is false. IF the number is even it returs true. Else it returns false
Predicate<int> evenOrOdd = number =>
{
    return number % 2 == 0;
};


int[] ranges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

int start = ranges[0];
int end = ranges[1];

string command = Console.ReadLine();

List<int> numbers = generateRange(start, end);

foreach(var number in numbers)
{
    if (command == "even" && evenOrOdd(number))
    {
        Console.Write($"{number} ");
    }
    else if (command == "odd" && !evenOrOdd(number))
    {
        Console.Write($"{number} ");
    }
}