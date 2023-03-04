double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

SortedDictionary<double, int> numbersSorted = new SortedDictionary<double, int>();

foreach (var number in numbers)
{
    if (!numbersSorted.ContainsKey(number))
    {
        numbersSorted.Add(number, 0);
    }

    numbersSorted[number] += 1;
}

foreach (var number in numbersSorted)
{
    Console.WriteLine($"{number.Key} -> {number.Value}");
}