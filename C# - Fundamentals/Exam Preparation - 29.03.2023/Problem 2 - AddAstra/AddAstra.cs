using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

string pattern = @"([#|\|])(?<product>[A-Za-z \s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, pattern);

int totalCalories = 0;

foreach (Match match in matches)
{
    totalCalories += int.Parse(match.Groups["calories"].Value);
}

int caloriesForOneDay = 2000;

int days = totalCalories/ caloriesForOneDay;

Console.WriteLine($"You have food to last you for: {days} days!");

foreach(Match match in matches)
{
    string product = match.Groups["product"].Value;
    string date = match.Groups["date"].Value;
    int calories = int.Parse(match.Groups["calories"].Value);

    Console.WriteLine($"Item: {product}, Best before: {date}, Nutrition: {calories}");
}