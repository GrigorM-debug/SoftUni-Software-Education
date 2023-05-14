int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> numbers = new Queue<int>(inputNumbers);

string result = string.Empty;

while (numbers.Any())
{
    int number = numbers.Dequeue();

    if (number % 2 == 0)
    {
        result += $"{number}, ";
    }
}
Console.WriteLine(result.TrimEnd(',', ' ')); // We use the TrimEnd method to remove the last comma symbol and the whitespace after that

