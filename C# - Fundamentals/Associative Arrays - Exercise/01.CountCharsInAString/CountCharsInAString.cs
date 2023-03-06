using System.Diagnostics.Tracing;

var letters = new Dictionary<char, int>();

string word = Console.ReadLine();

foreach (var currChar in word)
{
    if (currChar == ' ')
    {
        continue;
    }

    if(!letters.ContainsKey(currChar))
    {
        letters.Add(currChar, 0);
    }

    letters[currChar]++;
}

foreach(var item in letters)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}