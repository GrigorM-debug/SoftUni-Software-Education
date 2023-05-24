string text = Console.ReadLine();

SortedDictionary<char, int> occurrencesCount = new();

foreach (var ch in text)
{
    if (!occurrencesCount.ContainsKey(ch))
    {
        occurrencesCount.Add(ch, 0);
    }

    occurrencesCount[ch]++;
}

foreach(var occurrence in occurrencesCount)
{
    Console.WriteLine($"{occurrence.Key}: {occurrence.Value} time/s");
}