List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

List<int> sortedNumbers = numbers.OrderByDescending(numbers=> numbers).ToList();

if (sortedNumbers.Count > 3)
{
    Console.WriteLine(string.Join(" ", sortedNumbers.Take(3)));
}
else
{
    Console.WriteLine(string.Join(" ", sortedNumbers));
}