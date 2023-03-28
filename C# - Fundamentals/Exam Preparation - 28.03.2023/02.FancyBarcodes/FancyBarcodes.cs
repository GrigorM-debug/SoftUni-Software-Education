using System.Text.RegularExpressions;

string pattern = @"@\#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@\#+";

int numberOfinputs = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfinputs; i++)
{
    string barcode = Console.ReadLine();

    Match match = Regex.Match(barcode, pattern);

    if (match.Success)
    {
        string product = match.Groups["product"].Value;
        string productGroup = string.Empty;

        foreach (char curr in product)
        {
            if (Char.IsDigit(curr))
            {
                productGroup += curr;
            }

        }
        if (productGroup == string.Empty)
        {
            productGroup = "00";
        }
        Console.WriteLine($"Product group: {productGroup}");
    }
    else
    {
        Console.WriteLine("Invalid barcode");
    }
}