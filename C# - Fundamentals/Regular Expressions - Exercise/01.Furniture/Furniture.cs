using System.Text;
using System.Text.RegularExpressions;

string input = Console.ReadLine();

decimal totalprice = 0;

Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)");

var boughtFurniture = new StringBuilder();

while (input != "Purchase")
{
    Match match= regex.Match(input);

    if (match.Success)
    {
        string name = match.Groups["name"].Value;
        decimal price = decimal.Parse(match.Groups["price"].Value);
        int quantity = int.Parse(match.Groups["quantity"].Value);

        decimal priceForOneFurniture = price * quantity;
        totalprice += priceForOneFurniture;

        boughtFurniture.AppendLine(name);
    }
    input = Console.ReadLine(); 
}
Console.WriteLine("Bought furniture:");

if (boughtFurniture.Length > 0)
{
    Console.WriteLine(boughtFurniture.ToString());
}

Console.Write($"Total money spend: {totalprice:f2}");

//Need to be fixed