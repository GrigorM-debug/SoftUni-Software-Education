using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

string[] partisipants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

var results = new Dictionary<string, int>();

foreach(var partisipant in partisipants)
{
    results.Add(partisipant, 0);
}

string input = Console.ReadLine();  

while (input != "end of race")
{
    var nameCollection = Regex.Matches(input, @"[A-Za-z]");
    var distanceCollection = Regex.Matches(input, @"[0-9]");

    string name = string.Join(string.Empty, nameCollection);
    
    if (results.ContainsKey(name))
    {
        results[name] += distanceCollection.Select(x => int.Parse(x.Value)).Sum();
    }
    input = Console.ReadLine();
}

var finalists = results.OrderByDescending(x => x.Value).Take(3);

int counter = 1;
foreach (var finalist in finalists)
{
    string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
    Console.WriteLine($"{counter}{suffix} place: {finalist.Key}");
    counter++;
}