using System.Text.RegularExpressions;

string input = Console.ReadLine();

string customer = @"(?<customer>[A-Z][a-z]+)";
string product = @"(?<product>\w+)";
string count = @"(?<count>\d+)";
string price = @"(?<price>\d+(\.\d+)?)";
string junk = @"[^|$%.]";
string pattern = @$"\%{customer}\%{junk}*\<{product}\>{junk}*\|{count}\|{junk}*?{price}\$";

decimal totalPrice = 0;

while (input != "end of shift")
{
    MatchCollection matchCollection = Regex.Matches(input, pattern);

    foreach(Match match in matchCollection)
    {
        string customerName = match.Groups["customer"].Value;
        string productName = match.Groups["product"].Value;
        int quantity = int.Parse(match.Groups["count"].Value);
        decimal singlePrice = decimal.Parse(match.Groups["price"].Value);

        decimal priceForOneClient = singlePrice * quantity;
        totalPrice+= priceForOneClient;

        Console.WriteLine($"{customerName}: {productName} - {priceForOneClient:f2}");
    }
    input = Console.ReadLine();
}
Console.WriteLine($"Total income: {totalPrice:f2}");