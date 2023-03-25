using System.Numerics;
using System.Text.RegularExpressions;

string regexPattern = @"(=|/)([A-Z][A-Za-z]{2,})\1";

string input = Console.ReadLine();

MatchCollection matchCollection = Regex.Matches(input, regexPattern);

var result = matchCollection.Select(x => x.Value.Trim('=').Trim('/'));

Console.WriteLine("Destinations: " + string.Join(", ", result));

Console.WriteLine($"Travel Points: {result.Sum(x => x.Length)}");