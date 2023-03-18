using System.Text.RegularExpressions;

var names = Console.ReadLine();

var regexPattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

var matchedNames = Regex.Matches(names, regexPattern);

Console.WriteLine(string.Join(" ", matchedNames));