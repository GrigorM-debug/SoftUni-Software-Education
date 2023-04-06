using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"[@#](?<color>[a-z]{3,})[@#][^a-zA-Z\d]*\/(?<quantity>\d+)\/*";

MatchCollection matches = Regex.Matches(input, pattern);

foreach(Match match in matches)
{
    string color = match.Groups["color"].Value;
    int amount = int.Parse(match.Groups["quantity"].Value);

    Console.WriteLine($"You found {amount} {color} eggs!");
}