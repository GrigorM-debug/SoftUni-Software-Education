//Predicate<string> filterByUpperCase = c => c[0] == char.ToUpper(c[0]) && char.IsLetter(c[0]);

Func<string, bool> filterByUpperCase = c => c[0] == char.ToUpper(c[0]) && char.IsLetter(c[0]);

string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(c => filterByUpperCase(c)).ToArray();

foreach (string word in text)
{
    Console.WriteLine(word);
}