using System.Net.Http.Headers;

List<decimal> input = Console.ReadLine().Split(" ").Select(decimal.Parse).ToList();

Dictionary<decimal, int> numberOfOccurrences = new Dictionary<decimal, int>();

foreach(  var item in input )
{
    if (!numberOfOccurrences.ContainsKey(item))
    {
        numberOfOccurrences.Add(item, 0);
    }

    numberOfOccurrences[item]++;
}

foreach(var number in numberOfOccurrences)
{
    Console.WriteLine($"{number.Key} - {number.Value} times");
}  