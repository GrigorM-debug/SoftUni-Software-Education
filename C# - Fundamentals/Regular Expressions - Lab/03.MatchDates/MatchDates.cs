using System.Text.RegularExpressions;

var dates = Console.ReadLine();

var regexPattern = @"\b(?<day>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

var matchCollection = Regex.Matches(dates, regexPattern);

foreach(Match date in matchCollection)
{
    var day = date.Groups["day"].Value;
    var month = date.Groups["month"].Value;
    var year = date.Groups["year"].Value;

    Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
}