string[] words = Console.ReadLine().Split();

Dictionary<string, int> allWords = new Dictionary<string, int>();

foreach(string word in words)
{
    string wordsLower = word.ToLower();

    if (!allWords.ContainsKey(wordsLower))
    {
        allWords.Add(wordsLower, 0);
    }

    allWords[wordsLower]++; 
}

var result = allWords.Where(x => x.Value % 2 != 0).Select(x => x.Key).ToList();

Console.WriteLine(string.Join(" ", result));