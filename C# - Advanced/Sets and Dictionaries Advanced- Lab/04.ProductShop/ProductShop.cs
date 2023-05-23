using System.Security.Cryptography.X509Certificates;

Dictionary<string, Dictionary<string, double>> productShop = new Dictionary<string, Dictionary<string, double>>();

string command = Console.ReadLine();

while(command != "Revision")
{
    string[] tokens = command.Split(", ");
    string shop = tokens[0];
    string product = tokens[1];
    double price = double.Parse(tokens[2]);

    if (!productShop.ContainsKey(shop))
    {
        productShop.Add(shop,  new Dictionary<string, double>());
    }
    if (!productShop[shop].ContainsKey(product))
    {
        productShop[shop].Add(product,price);
    }

    productShop[shop][product] = price;
    command= Console.ReadLine();
}

productShop = productShop.OrderBy(x => x.Key).ToDictionary(x => x.Key,x => x.Value);

foreach( var (shop,products) in productShop)
{
    Console.WriteLine($"{shop}-> ");

    foreach (var (product, price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}