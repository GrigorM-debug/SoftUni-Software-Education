List<string> numbers = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

numbers.Reverse();
List<string> numbersSplit = new List<string>();

foreach (var number in numbers)
{
    numbersSplit.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
}

Console.WriteLine(string.Join(" ", numbersSplit));