using System.Text.RegularExpressions;

string phones = Console.ReadLine();

var regexPattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";

var phonesMatches = Regex.Matches(phones, regexPattern);

Console.WriteLine(string.Join(", ", phonesMatches));